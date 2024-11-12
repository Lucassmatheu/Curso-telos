class_name JumpingEnemy
extends CharacterBody2D

const States = {
	IDLE = "idle",
	JUMP = "jump",
	WALK = "walk",
	CHASE = "chase"  # Novo estado para seguir o jogador
}

@onready var animated_sprite: AnimatedSprite2D = $AnimatedSprite2D
@onready var attack_area: Area2D = $AttackArea
@onready var floor_detector_left: RayCast2D = $FloorDetectorLeft
@onready var floor_detector_right: RayCast2D = $FloorDetectorRight
@onready var player: CharacterBody2D = null  # Referência ao jogador

# Atributos do inimigo
var health: int = 100
var _state: String = States.IDLE
var visible_state: bool = true  
var WALK_SPEED: float = 50.0  
var CHASE_SPEED: float = 100.0  # Velocidade ao perseguir
var JUMP_FORCE: float = 300.0 
var jump_timer: float = 2.0  
var time_since_jump: float = 0.0 
var detection_radius: float = 200.0  # Distância de detecção para perseguir o jogador

func _ready() -> void:
	add_to_group("Enemies")
	animated_sprite.play("idle")
	# Assumindo que o jogador está no mesmo nível na cena, ajuste o caminho se necessário
	player = get_node("/root/Level/SkeletalPlayer")

func _process(delta: float) -> void:
	time_since_jump += delta

	if player and position.distance_to(player.position) < detection_radius:
		_state = States.CHASE  # Muda para o estado de perseguição se o jogador estiver próximo

	if _state == States.CHASE:
		chase_player()
	elif time_since_jump >= jump_timer and is_on_floor():
		jump()
		time_since_jump = 0.0
	else:
		move()

	var animation := get_new_animation()
	if animation != animated_sprite.animation:
		animated_sprite.play(animation)

func jump() -> void:
	if is_on_floor():
		velocity.y = -JUMP_FORCE
		_state = States.JUMP

func chase_player() -> void:
	# Move em direção ao jogador
	if position.x < player.position.x:
		velocity.x = CHASE_SPEED  # Move para a direita
	else:
		velocity.x = -CHASE_SPEED  # Move para a esquerda
	move_and_slide()

func move() -> void:
	velocity.x = WALK_SPEED if _state == States.WALK else 0
	move_and_slide()

func get_new_animation() -> StringName:
	match _state:
		States.WALK:
			return "walk"
		States.JUMP:
			return "jump"
		States.IDLE:
			return "idle"
		States.CHASE:
			return "walk"
	return ""

func receiveDamage(damage: int) -> void:
	health -= damage
	if isDead():
		die()

func isDead() -> bool:
	return health <= 0

func die() -> void:
	print("O inimigo morreu!")
	queue_free()

func _on_attack_area_body_entered(body: Node2D) -> void:
	if body.is_in_group("Player"):
		body.receiveDamage(10)
		print("Jogador atacado!")
