public abstract class Animal : ISize, ICellContainment
{
    private string _name;

    protected int _size;

    private readonly int _max_mood = 100;

    protected int _mood;

    protected int _max_health;

    private int _health;

    protected int _max_hunger;

    private int _hunger;

    protected int _attractiveness;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Size
    {
        get { return _size; }
        set { _size = value; }
    }

    public int Mood
    {
        get { return _mood; }
        set 
        { 
            _mood = value;
            //if mood is greater than max mood, set mood to max mood
            if (_mood > _max_mood)
            {
                _mood = _max_mood;
            }
        }
    }

    public int Health
    {
        get { return _health; }
        set 
        { 
            _health = value;
            //if health is greater than max health, set health to max health
            if (_health > _max_health)
            {
                _health = _max_health;
            } 
        }
    }

    public int Hunger
    {
        get { return _hunger; }
        set 
        { 
            _hunger = value;
            //if hunger is greater than max hunger, set hunger to max hunger
            if (_hunger > _max_hunger)
            {
                _hunger = _max_hunger;
            } 
        }
    }

    public int Attractiveness
    {
        get { return _attractiveness; }
        set { _attractiveness = value; }
    }

    //constructor
    public Animal(string name)
    {
        _name = name;
    }

    //activity would be different for each animal and rely on interfaces
    public abstract void Activity();
}