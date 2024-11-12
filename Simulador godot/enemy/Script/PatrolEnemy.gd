extends CharacterBody2D

const States = {
	PATROL = "patrol",
	CHASE = "chase",
	ATTACK = "attack",
	JUMP = "jump",
	FLY = "fly",
}

@onready var animated_sprite: AnimatedSprite2D = $AnimatedSprite2D
@onready var attack_area: Area2D = $AttackArea  # Área que detecta e causa dano
@onready var floor_detector_left: RayCast2D = $FloorDetectorLeft
@onready var floor_detector_right: RayCast2D = $FloorDetectorRight

var _state: String = States.PATROL
var visible_state: bool = true  # O inimigo começa visível
var patrol_speed: float = 50.0  # Velocidade de patrulha
var chase_speed: float = 100.0  # Velocidade de perseguição
var jump_force: float = -200.0  # Força do pulo
var fly_speed: float = 60.0  # Velocidade do voo
var direction: int = 1  # 1 para direita, -1 para esquerda
var player = null  # Referência ao jogador
var is_flying: bool = false  # Variável para verificar se o inimigo está voando

func _ready() -> void:
	# Obtém referência ao jogador
	player = get_node("/root/Level/SkeletalPlayer")  # Ajuste o caminho se necessário
	if player == null:
		print("Jogador não encontrado!")

	animated_sprite.play("idle")

func _process(delta: float) -> void:
	if visible_state:
		match _state:
			States.PATROL:
				patrol()
				if is_player_in_range():
					_state = States.CHASE

			States.CHASE:
				chase_player()
				if not is_player_in_range():
					_state = States.PATROL

			States.JUMP:
				jump()

			States.FLY:
				fly()

		update_animation()

func patrol() -> void:
	velocity.x = patrol_speed * direction  # Move na direção atual

	# Verifica se há chão e muda a direção se necessário
	if not floor_detector_left.is_colliding() and not floor_detector_right.is_colliding():
		direction *= -1  # Inverte a direção
	if is_on_wall():
		direction *= -1  # Inverte a direção ao colidir com uma parede

	move_and_slide()

func chase_player() -> void:
	if player:
		if position.x < player.position.x:
			velocity.x = chase_speed  # Move para a direita
		else:
			velocity.x = -chase_speed  # Move para a esquerda

		# Verifica se o jogador está em uma posição mais alta para voar ou pular
		if position.y < player.position.y:
			_state = States.FLY  # Começa a voar
		elif position.y > player.position.y:
			_state = States.JUMP  # Começa a pular

		move_and_slide()

func jump() -> void:
	# Impede que o inimigo pule se já estiver no ar
	if is_on_floor():
		velocity.y = jump_force  # Pulo para cima
		print("Inimigo pulou!")
		_state = States.PATROL  # Volta para o estado de patrulha após o pulo

	move_and_slide()

func fly() -> void:
	# O inimigo voa em direção ao jogador
	if player:
		if position.x < player.position.x:
			velocity.x = fly_speed  # Move para a direita
		else:
			velocity.x = -fly_speed  # Move para a esquerda

		# Ajuste para voar para a mesma altura do jogador
		if position.y < player.position.y:
			velocity.y = fly_speed  # Move para cima
		elif position.y > player.position.y:
			velocity.y = -fly_speed  # Move para baixo

		move_and_slide()

func is_player_in_range() -> bool:
	# Verifica se o jogador está dentro de um determinado alcance
	return position.distance_to(player.position) < 200.0  # Ajuste o valor conforme necessário

func update_animation() -> void:
	if velocity.x != 0:
		animated_sprite.scale.x = direction  # Olha na direção do movimento
		animated_sprite.play("walk")
	else:
		animated_sprite.play("idle")

# Função para lidar com a entrada na área de ataque
func _on_attack_area_body_entered(body):
	if body.is_in_group("Player"):
		body.receiveDamage(10)  # Aplica dano ao jogador
		print("Jogador atacado!")
