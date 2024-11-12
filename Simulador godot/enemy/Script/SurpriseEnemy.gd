class_name SurpriseEnemy
extends CharacterBody2D

const States = {
	IDLE = "idle",
	ATTACK = "attack",
	WALK = "walk"
}

@onready var animated_sprite: AnimatedSprite2D = $AnimatedSprite2D
@onready var attack_area: Area2D = $AttackArea  # Área que detecta e causa dano
@onready var platform_detector: RayCast2D = $PlataformaDectector
@onready var floor_detector_left: RayCast2D = $FloorDetectorLeft
@onready var floor_detector_right: RayCast2D = $FloorDetectorRight

var _state: String = States.WALK
var visible_state: bool = false  # Para rastrear a visibilidade
var WALK_SPEED: float = 50.0  # Velocidade de movimento
var direction_change_timer: float = 2.0  # Tempo para mudar de direção
var time_since_direction_change: float = 0.0  # Cronômetro para a mudança de direção

func _ready() -> void:
	add_to_group("Enemies")
	hide()  # Começa invisível
	attack_area.connect("body_entered", Callable(self, "_on_body_entered"))
	attack_area.connect("body_exited", Callable(self, "_on_body_exited"))
	animated_sprite.play("idle")

# Detecta o jogador entrando na área de ataque
func _on_body_entered(body):
	if body.is_in_group("Player"):
		appear_and_attack()

# Aplica dano ao jogador quando ele permanece na área de ataque
func _on_body_exited(body):
	if body.is_in_group("Player"):
		print("Jogador saiu da área de ataque!")

# Torna o inimigo visível e muda para o estado de ataque
func appear_and_attack() -> void:
	if not visible_state:
		visible_state = true
		show()
		_state = States.WALK  # Muda para o estado de WALK ao aparecer
		animated_sprite.play("walk")

# Comportamento de movimento e animação do inimigo
func _process(_delta: float) -> void:
	if visible_state:
		time_since_direction_change += _delta
		if time_since_direction_change >= direction_change_timer:
			velocity.x = -velocity.x  # Inverte a direção
			time_since_direction_change = 0.0

		if _state == States.WALK:
			if velocity.is_zero_approx():
				velocity.x = WALK_SPEED

			# Verifica se há chão e muda a direção se necessário
			if not floor_detector_left.is_colliding() and not floor_detector_right.is_colliding():
				velocity.x = -velocity.x  # Muda de direção se não há chão

			if is_on_wall():
				velocity.x = -velocity.x  # Inverte a direção ao colidir com uma parede

			if velocity.x > 0.0:
				animated_sprite.scale.x = 1.0  # Olha para a direita
			elif velocity.x < 0.0:
				animated_sprite.scale.x = -1.0  # Olha para a esquerda

		move_and_slide()

		var animation := get_new_animation()
		if animation != animated_sprite.animation:
			animated_sprite.play(animation)

func get_new_animation() -> StringName:
	match _state:
		States.WALK:
			return "walk"
		States.ATTACK:
			return "attack"
		States.IDLE:
			return "idle"
	return ""

# Função para lidar com a entrada na área de ataque sem usar o parâmetro
func _on_sword_area_body_entered(body):
	if body.is_in_group("Player"):
		print("Jogador detectado pela área da espada!")  
		body.receiveDamage(10)  
	else:
		print("Outro corpo detectado, mas não é o jogador.")  


func _on_attack_area_body_entered(body: Node2D) -> void:
	if body.is_in_group("Player"):
		print("Jogador detectado pela área da espada!")  
		body.receiveDamage(10)  # Aplica dano ao jogador
	else:
		print("Outro corpo detectado, mas não é o jogador.") 
