extends CharacterBody2D

const States = {
	WALK = "walk",
	ATTACK = "attack",
	IDLE = "idle",
	FLY = "fly",
}

var FLY_SPEED: int = 50  # Velocidade de voo horizontal
var altitude: float = 200.0  # Altitude fixa do voo
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

	if time_since_direction_change >= direction_change_timer:
		velocity.x = -velocity.x  # Inverte a direção
		time_since_direction_change = 0.0

	if _state == States.FLY:
		velocity.x = FLY_SPEED  # Define a velocidade de voo horizontal

		# Oscilação vertical para simular o voo
		position.y = altitude + sin(oscillation_time * oscillation_speed) * oscillation_amplitude

		if is_on_wall():
			velocity.x = -velocity.x  # Inverte a direção ao colidir com uma parede

		# Ajusta a direção da animação
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
		States.FLY:
			return "fly"
		States.ATTACK:
			return "attack"
		States.IDLE:
			return "idle"
	return ""
