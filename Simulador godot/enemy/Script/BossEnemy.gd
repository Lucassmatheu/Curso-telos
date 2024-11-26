extends Enemy  # Herda da classe base Enemy

class_name BossEnemy

var special_attack_power: int = 20  # Poder do ataque especial do boss
var enraged: bool = false  # Estado que indica se o boss está enfurecido
var health_threshold: int = 50  # Limite de saúde para ativar o ataque especial
var detection_radius: float = 300.0  # Raio de detecção do jogador para iniciar a perseguição
var jump_force: float = 300.0  # Força do pulo do boss

@onready var navigation_agent: NavigationAgent2D = $NavigationAgent2D
@onready var target_to_chase: CharacterBody2D = null  # Referência ao jogador
@onready var floor_detector: RayCast2D = $FloorDetector  # Ajuste o caminho se necessário
const SPEED = 180.0

func _ready() -> void:
	# Chama a função de inicialização da classe pai usando super()
	super._ready()
	print("Boss está pronto para a batalha!")

	# Atribui o jogador programaticamente se não estiver atribuído no editor
	if target_to_chase == null:
		target_to_chase = get_node("/root/Level/SkeletalPlayer")  # Ajuste o caminho conforme necessário
		print("Alvo para perseguir atribuído: ", target_to_chase)

func _physics_process(_delta: float) -> void:  # Usando _delta para evitar o erro de parâmetro não usado
	if target_to_chase == null:
		print("Erro: O target_to_chase não foi atribuído!")
		return

	# Verifica a distância entre o Boss e o Jogador
	var distance_to_player = global_position.distance_to(target_to_chase.global_position)

	if distance_to_player <= detection_radius:
		# Se o jogador estiver dentro do raio de detecção, o boss começa a persegui-lo
		move_towards_player()
	else:
		# Se o jogador estiver fora do raio de detecção, o boss não faz nada
		velocity = Vector2.ZERO

	# Verifica se o boss está no chão e decide se ele precisa pular
	if not floor_detector.is_colliding():
		# O boss precisa pular se não estiver no chão
		jump()

	move_and_slide()

func move_towards_player() -> void:
	# Move o Boss em direção ao jogador
	var direction_to_player = global_position.direction_to(target_to_chase.global_position)
	velocity = direction_to_player * SPEED
	
	# Verifica a posição do jogador (acima ou no mesmo nível)
	if target_to_chase.position.y < position.y:
		# O jogador está mais baixo, o boss vai descer ou seguir o caminho
		velocity.y = 0
	elif target_to_chase.position.y > position.y:
		# O jogador está mais alto, o boss vai tentar subir ou pular
		if floor_detector.is_colliding():
			velocity.y = -jump_force  # Pular para alcançar o jogador mais alto

	move_and_slide()

func jump() -> void:
	# Pula o Boss
	if velocity.y == 0:  # Se o boss não estiver no ar (somente pode pular quando estiver no chão)
		velocity.y = jump_force  # Aplica a força de pulo no eixo Y

func receiveDamage(damage: int) -> void:
	# Reduz a saúde e ativa o modo enfurecido se necessário
	health -= damage
	if health <= health_threshold and not enraged:
		infuriate()  # Ativa o modo enfurecido

func infuriate() -> void:
	enraged = true
	special_attack_power *= 2  # Aumenta o poder do ataque especial
	print("O boss ficou enfurecido! Poder de ataque especial: ", special_attack_power)

func performSpecialAttack(target: Node) -> void:
	# Método para executar um ataque especial no jogador
	if target.is_in_group("Player"):
		print("Boss ataca o jogador com ataque especial!")
		target.receiveDamage(special_attack_power)  # Aplica dano ao jogador

func displayStatus() -> void:
	# Exibe o status do boss e chama a função da classe pai
	super.displayStatus()  # Acesso à função displayStatus da classe pai, caso exista
	print("Estado do Boss: ", health, " de ", max_health)  # Acessa health e max_health da classe pai, se definido
	if enraged:
		print("O boss está enfurecido!")
