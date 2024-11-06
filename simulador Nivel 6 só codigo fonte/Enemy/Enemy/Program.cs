using System;

namespace SimulatorTelosLevel6
{
    public class Enemy
    {
        private int health;
        private float velocity;

        public Enemy(int initialHealth, float initialVelocity)
        {
            health = initialHealth;
            velocity = initialVelocity;
        }

        public int GetHealth() => health;
        public void ReceiveDamage(int damage) => health = Math.Max(0, health - damage);
        public bool IsDead() => health <= 0;

        public virtual void Move()
        {
            Console.WriteLine("Enemy está se movendo com velocidade " + velocity);
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Health: {health}, Velocity: {velocity}");
        }
    }

    public class EnemyWithAttack : Enemy
    {
        private int attack;

        public EnemyWithAttack(int health, float velocity, int attackDamage) : base(health, velocity)
        {
            attack = attackDamage;
        }

        public void AttackPlayer(int damage)
        {
            Console.WriteLine($"Enemy atacou o jogador, causando {damage} de dano.");
        }

        public override void Move()
        {
            base.Move();
            Console.WriteLine("EnemyWithAttack se movimenta e busca atacar.");
        }
    }

    public class FlyingEnemy : Enemy
    {
        private int altitude;

        public FlyingEnemy(int health, float velocity, int initialAltitude) : base(health, velocity)
        {
            altitude = initialAltitude;
        }

        public void Fly()
        {
            Console.WriteLine("FlyingEnemy está voando a uma altitude de " + altitude);
        }

        public override void Move()
        {
            Fly();
            Console.WriteLine("FlyingEnemy está se movendo e voando.");
        }
    }

    public class JumpingEnemy : Enemy
    {
        private int altitude;

        public JumpingEnemy(int health, float velocity, int initialAltitude) : base(health, velocity)
        {
            altitude = initialAltitude;
        }

        public void Jump()
        {
            Console.WriteLine("JumpingEnemy saltou para uma altitude de " + altitude);
        }

        public override void Move()
        {
            Jump();
            Console.WriteLine("JumpingEnemy está se movendo e saltando.");
        }
    }

    public class BossEnemy : Enemy
    {
        private bool isInfuriated;

        public BossEnemy(int health, float velocity) : base(health, velocity)
        {
            isInfuriated = false;
        }

        public void Infuriate()
        {
            if (!isInfuriated && GetHealth() < 50)
            {
                isInfuriated = true;
                Console.WriteLine("O Boss entrou em modo de fúria!");
            }
        }

        public override void Move()
        {
            Infuriate();
            Console.WriteLine(isInfuriated ? "Boss se move com raiva aumentada." : "Boss está se movendo normalmente.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Simulator Télos - Nível 6!");

            // Testando a classe Enemy
            Enemy basicEnemy = new Enemy(100, 1.5f);
            basicEnemy.DisplayStatus();
            basicEnemy.Move();
            basicEnemy.ReceiveDamage(20);
            basicEnemy.DisplayStatus();
            Console.WriteLine("Enemy is dead: " + basicEnemy.IsDead());

            // Testando EnemyWithAttack
            EnemyWithAttack attacker = new EnemyWithAttack(80, 1.2f, 15);
            attacker.DisplayStatus();
            attacker.Move();
            attacker.AttackPlayer(15);
            attacker.ReceiveDamage(30);
            attacker.DisplayStatus();

            // Testando FlyingEnemy
            FlyingEnemy flyer = new FlyingEnemy(70, 2.0f, 10);
            flyer.DisplayStatus();
            flyer.Move();
            flyer.ReceiveDamage(40);
            flyer.DisplayStatus();

            // Testando JumpingEnemy
            JumpingEnemy jumper = new JumpingEnemy(60, 1.8f, 5);
            jumper.DisplayStatus();
            jumper.Move();
            jumper.ReceiveDamage(25);
            jumper.DisplayStatus();

            // Testando BossEnemy
            BossEnemy boss = new BossEnemy(200, 1.0f);
            boss.DisplayStatus();
            boss.Move();
            boss.ReceiveDamage(160);
            boss.DisplayStatus();
            boss.Move();

            Console.WriteLine("Simulação finalizada.");
        }
    }
}
