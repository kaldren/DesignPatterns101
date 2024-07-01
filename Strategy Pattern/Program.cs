public abstract class Hero
{
    public string Name { get; protected set; }
    public int Level { get; protected set; }
    public int Health { get; protected set; }
}

public class Warrior : Hero
{
    public Warrior(string name, int level, int health)
    {
        Name = name;
        Level = level;
        Health = health;
    }
}

public class Mage : Hero
{
    public Mage(string name, int level, int health)
    {
        Name = name;
        Level = level;
        Health = health;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Hero warrior = new Warrior("Warrior", 1, 100);
        Hero mage = new Mage("Mage", 1, 100);

        Console.WriteLine($"Warrior: {warrior.Name}, Level: {warrior.Level}, Health: {warrior.Health}");
        Console.WriteLine($"Mage: {mage.Name}, Level: {mage.Level}, Health: {mage.Health}");
    }
}