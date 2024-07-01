public abstract class IceCream
{
    protected string _description = "Ice Cream";
    public abstract double Cost();
    public string Description
    {
        get { return _description; }
    }
}

public class VanillaIceCream : IceCream
{
    public override double Cost()
    {
        return 1.0;
    }
}

public class ChocolateIceCream : IceCream
{
    public override double Cost()
    {
        return 1.5;
    }
}

public abstract class IceCreamDecorator : IceCream
{
    protected IceCream _iceCream;
    public IceCreamDecorator(IceCream iceCream)
    {
        _iceCream = iceCream;
    }
    public override double Cost()
    {
        return _iceCream.Cost();
    }
}

public class NutsDecorator : IceCreamDecorator
{
    public NutsDecorator(IceCream iceCream) : base(iceCream)
    {
        _description += ", Nuts";
    }
    public override double Cost()
    {
        return _iceCream.Cost() + 0.2;
    }
}

public class SprinklesDecorator : IceCreamDecorator
{
    public SprinklesDecorator(IceCream iceCream) : base(iceCream)
    {
        _description += ", Sprinkles";
    }
    public override double Cost()
    {
        return _iceCream.Cost() + 0.1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        IceCream iceCream = new VanillaIceCream();
        Console.WriteLine(iceCream.Cost());

        iceCream = new NutsDecorator(new SprinklesDecorator(new SprinklesDecorator(new SprinklesDecorator(new NutsDecorator(new SprinklesDecorator(new SprinklesDecorator((iceCream))))))));
        Console.WriteLine(iceCream.Cost());
        Console.WriteLine(iceCream.Description);
    }
}