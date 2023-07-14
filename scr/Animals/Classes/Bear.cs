public class Bear : Animal, IRoar, IClimb, ISwim
{
    
    private readonly int _probabilityToRoar = 10;

    private readonly int _probabilityToClimb = 15;

    public Bear(string name) : base(name)
    {
        _size = 150;
        //write in console "Bear is created"
        Console.WriteLine("Bear is created");
    }

    public override void Activity()
    {
        //start random activity from following list:
        //1. Climb
        //2. Roar
        //3. Swim

        //use Random class
        Random random = new Random();

        int activity = random.Next(1, 4);

        switch (activity)
        {
            case 1:
                Climb();
                break;
            case 2:
                Roar();
                break;
            case 3:
                Swim();
                break;
            default:
                break;
        }
        

    }

    public int Roar()
    {
        Console.WriteLine($"{Name} is scary!");
        return 10;
    }
    public void Climb()
    {
        
    }

    public int Swim()
    {
        Console.WriteLine($"{Name} is swimming!");
        return 10;
    }
}