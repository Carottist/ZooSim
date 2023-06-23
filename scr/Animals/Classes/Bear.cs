public class Bear : Animal, IRoar, IClimb
{
    public Bear(string name) : base(name)
    {
        _size = 150;
        //write in console "Bear is created"
        Console.WriteLine("Bear is created");
    }

    public override void Activity()
    {
        Roar();
        Climb();
    }

    public int Roar()
    {
        Console.WriteLine($"{Name} is scary!");
        return 10;
    }
    public void Climb()
    {
        
    }
}