namespace DesignPatterns.Creational.Factory;

class Program
{
    static void Main(string[] args)
    {
        Character warrior = CharacterFactory.CreateCharacter("warrior");
        Character mage = CharacterFactory.CreateCharacter("mage");

        warrior.Attack();
        mage.Attack();

        Console.ReadKey();
    }


    abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }


        public Character(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public abstract void Attack();
    }

    class Warrior : Character
    {
        public Warrior(string name, int health) : base(name, health)
        {

        }

        public override void Attack()
        {
            Console.WriteLine($"Warrior {Name} attacked");
        }
    }

    class Mage : Character
    {

        public Mage(string name, int health) : base(name, health)
        {

        }

        public override void Attack()
        {
            Console.WriteLine($"Mage {Name} attacked");
        }
    }

    static class CharacterFactory
    {
        public static Character CreateCharacter(string name)
        {
            switch (name)
            {
                case "warrior":
                    return new Warrior("warrior", 100);
                case "mage":
                    return new Mage("mage", 90);
                default:
                    throw new ArgumentNullException("no character with this name");
            }
        }
    }
}
