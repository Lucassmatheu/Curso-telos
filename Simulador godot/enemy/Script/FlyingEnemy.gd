extends CharacterBody2D

const States = {
	WALK = "walk",
	ATTACK = "attack",
	IDLE = "idle",
	FLY = "fly",
}

var FLY_SPEED: int = 50  # Velocidade de voo horizontal
var altitude: float = 100.0  # Altitude fixa do voo
var oscillation_amplitude: float = 5.0  # Amplitude da oscilação
var oscillation_speed: float = 3.0  # Velocidade da oscilação vertical

var _state: String = States.FLY
var direction_change_timer: float = 2.0
var time_since_direction_change: float = 0.0
var oscillation_time: float = 0.0  # Tempo acumulado para a oscilação

@onready var animated_sprite: AnimatedSprite2D = $AnimatedSprite2D
@onready var sword_area: Area2D = $SwordArea  # Referência à área de dano da espada

func _ready() -> void:
	animated_sprite.play(get_new_animation())
	# Conectar o sinal da área de dano da espada
	sword_area.connect("body_entered", Callable(self, "_on_sword_area_body_entered"))
	position.y = altitude  # Define a altura inicial do voo

func _on_sword_area_body_entered(body):
	if body.is_in_group("Player"):
		print("Jogador detectado pela área da espada!")
		body.receiveDamage(10)  
	else:
		print("Outro corpo detectado, mas não é o jogador.")  

func _process(delta: float) -> void:
	time_since_direction_change += delta
	oscillation_time += delta  # Acumula o tempo para a oscilação

	# Define a velocidade de voo horizontal
	velocity.x = FLY_SPEED

	if time_since_direction_change >= direction_change_timer:
		# Inverte a direção quando o tempo de mudança expira
		velocity.x = -velocity.x
		time_since_direction_change = 0.0

	if _state == States.FLY:
		# Oscilação vertical para simular o voo
		position.y = altitude + sin(oscillation_time * oscillation_speed) * oscillation_amplitude

		# Verifica se o inimigo está em uma parede
		if is_on_wall():
			velocity.x = -velocity.x  # Inverte a direção ao colidir com uma parede
			time_since_direction_change = 0.0  # Reinicia o temporizador de mudança de direção
			# Ajusta a posição para fora da parede
			if velocity.x > 0:
				position.x -= 1  # Move o inimigo para fora da parede à direita
			else:
				position.x += 1  # Move o inimigo para fora da parede à esquerda

		# Ajusta a direção da animação
		if velocity.x > 0.0:
			animated_sprite.scale.x = 1.0
		elif velocity.x < 0.0:
			animated_sprite.scale.x = -1.0

	move_and_slide()  # Chamada sem argumentos

	var animation := get_new_animation()  # Garantir que a função seja acessível
	if animation != animated_sprite.animation:
		animated_sprite.play(animation)

# Função para obter a nova animação
func get_new_animation() -> StringName:
	match _state:
		States.FLY:
			return "fly"
		States.ATTACK:
			return "attack"
		States.IDLE:
			return "idle"
	return ""
