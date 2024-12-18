class_name Player
extends CharacterBody2D

# Keep this in sync with the AnimationTree's state names.
const States = {
	IDLE = "idle",
	WALK = "walk",
	RUN = "run",
	FLY = "fly",
	FALL = "fall",
}

const WALK_SPEED = 200.0
const ACCELERATION_SPEED = WALK_SPEED * 6.0
const JUMP_VELOCITY = -400.0
const TERMINAL_VELOCITY = 400

var health: int = 100  # Saúde inicial do jogador
var falling_slow = false
var falling_fast = false
var no_move_horizontal_time = 0.0

@onready var gravity = ProjectSettings.get_setting("physics/2d/default_gravity")
@onready var sprite = $Sprite2D
@onready var sprite_scale = sprite.scale.x

func _ready():
	$AnimationTree.active = true
	add_to_group("Player")  # Adiciona o jogador ao grupo "Player"

func _physics_process(delta: float) -> void:
	var is_jumping = false
	if Input.is_action_just_pressed("jump"):
		is_jumping = try_jump()
	elif Input.is_action_just_released("jump") and velocity.y < 0.0:
		# O jogador soltou o pulo antes, reduzindo a velocidade vertical.
		velocity.y *= 0.6
	
	# Queda.
	velocity.y = min(TERMINAL_VELOCITY, velocity.y + gravity * delta)

	# Movimento horizontal.
	if no_move_horizontal_time <= 0.0:
		var direction := Input.get_axis("move_left", "move_right") * WALK_SPEED
		velocity.x = move_toward(velocity.x, direction, ACCELERATION_SPEED * delta)
	else:
		velocity.x = 0.0
		no_move_horizontal_time -= delta

	# Animação do movimento horizontal.
	if not is_zero_approx(velocity.x):
		if velocity.x > 0.0:
			sprite.scale.x = 1.0 * sprite_scale
		else:
			sprite.scale.x = -1.0 * sprite_scale

	move_and_slide()

	# Atualizando a animação após o movimento.
	if velocity.y >= TERMINAL_VELOCITY:
		falling_fast = true
		falling_slow = false
	elif velocity.y > 300:
		falling_slow = true

	if is_jumping:
		$AnimationTree["parameters/jump/request"] = AnimationNodeOneShot.ONE_SHOT_REQUEST_FIRE

	if is_on_floor():
		# Transições de animação quando o jogador toca no chão.
		if falling_fast:
			$AnimationTree["parameters/land_hard/request"] = AnimationNodeOneShot.ONE_SHOT_REQUEST_FIRE
			no_move_horizontal_time = 0.4
		elif falling_slow:
			$AnimationTree["parameters/land/request"] = AnimationNodeOneShot.ONE_SHOT_REQUEST_FIRE

		if abs(velocity.x) > 50:
			$AnimationTree["parameters/state/transition_request"] = States.RUN
			$AnimationTree["parameters/run_timescale/scale"] = abs(velocity.x) / 60
		elif velocity.x:
			$AnimationTree["parameters/state/transition_request"] = States.WALK
			$AnimationTree["parameters/walk_timescale/scale"] = abs(velocity.x) / 12
		else:
			$AnimationTree["parameters/state/transition_request"] = States.IDLE

		falling_fast = false
		falling_slow = false
	else:
		if velocity.y > 0:
			$AnimationTree["parameters/state/transition_request"] = States.FALL
		else:
			$AnimationTree["parameters/state/transition_request"] = States.FLY

func try_jump() -> bool:
	if is_on_floor() and velocity.y >= 0:
		velocity.y = JUMP_VELOCITY
		return true
	return false

# Método para receber dano
func receiveDamage(damage: int) -> void:
	health -= damage
	print("O jogador recebeu dano! Saúde restante: ", health)
	
	# Verifica se o jogador está morto
	if isDead():
		die()

# Verifica se o jogador está morto
func isDead() -> bool:
	return health <= 0

# Método para tratar a morte do jogador
func die() -> void:
	print("O jogador morreu!")
	call_deferred("reload_scene")  # Chama o método para recarregar a cena

# Método para recarregar a cena atual
func reload_scene() -> void:
	get_tree().reload_current_scene()  # Recarrega a cena atual

# Função para detectar colisões com a área de ataque
func _on_attack_area_body_entered(_body: Node2D) -> void:
	# Exemplo de dano ao inimigo
	if _body.is_in_group("Enemy"):
		_body.receiveDamage(10)  # Dano do ataque

# Função para detectar colisões com a área da espada
func _on_sword_area_body_entered(_body: Node2D) -> void:
	# Exemplo de dano ao inimigo
	if _body.is_in_group("Enemy"):
		_body.receiveDamage(15)  # Dano da espada
