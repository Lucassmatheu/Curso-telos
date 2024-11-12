extends Enemy  # Herda da classe base Enemy

class_name BossEnemy

var special_attack_power: int = 20  # Poder do ataque especial do boss
var enraged: bool = false  # Estado que indica se o boss está enfurecido
var health_threshold: int = 50  # Limite de saúde para ativar o ataque especial

func _ready() -> void:
	# Chama a função de inicialização da classe pai usando super()
	super._ready()
	print("Boss está pronto para a batalha!")

func receiveDamage(damage: int) -> void:
	# Reduz a saúde e ativa o modo enfurecido se necessário
	health -= damage  # Verifica se a variável health existe na classe pai
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
