class_name Enemy
extends CharacterBody2D

const States = {
	WALK = "walk",
	ATTACK = "attack",
	IDLE = "idle",
}

var WALK_SPEED: int = 50 
var _state: String = States.WALK
var direction_change_timer: float = 2.0
var time_since_direction_change: float = 0.0

@onready var gravity = ProjectSettings.get_setting("physics/2d/default_gravity")
@onready var Plataforma_dectector: RayCast2D = $PlataformaDectector
@onready var floor_detector_left2: RayCast2D = $FloorDetectorLeft
@onready var floor_detector_right: RayCast2D = $FloorDetectorRight
@onready var animated_sprite: AnimatedSprite2D = $AnimatedSprite2D
@onready var sword_area: Area2D = $SwordArea  # Referência à área de dano da espada

var health: int = 100  # Exemplo de saúde para o inimigo
var max_health: int = 100  # Saúde máxima do inimigo
var is_signal_connected: bool = false  # Variável para controlar a conexão do sinal

func _ready() -> void:
	animated_sprite.play(get_new_animation())

	# Verifica se o sinal já foi conectado
	if not is_signal_connected:
		# Agora estamos passando o Callable corretamente para conectar o sinal
		sword_area.connect("body_entered", Callable(self, "_on_sword_area_body_entered"))  # Conecta o sinal à função
		is_signal_connected = true  # Marca que o sinal foi conectado

func _on_sword_area_body_entered(body: Node) -> void:
	# Verifica se o corpo detectado é o jogador
	if body.is_in_group("Player"):
		print("Jogador detectado pela área da espada!")  
		body.receiveDamage(10)  # Aplica dano ao jogador
	else:
		print("Outro corpo detectado, mas não é o jogador.")  

func _process(delta: float) -> void:
	time_since_direction_change += delta
	if time_since_direction_change >= direction_change_timer:
		velocity.x = -velocity.x
		time_since_direction_change = 0.0

	if _state == States.WALK:
		if velocity.is_zero_approx():
			velocity.x = WALK_SPEED

		if not floor_detector_left2.is_colliding() and not floor_detector_right.is_colliding():
			velocity.x = -velocity.x  

		if is_on_wall():
			velocity.x = -velocity.x  

		if velocity.x > 0.0:
			animated_sprite.scale.x = 1.0
		elif velocity.x < 0.0:
			animated_sprite.scale.x = -1.0

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

# Método para exibir o status do inimigo
func displayStatus() -> void:
	print("Estado do Inimigo: ", health, " de ", max_health)
