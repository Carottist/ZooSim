public class Improvement : ISize, ICellContainment
{
    public string Name { get; }

    public int Size { get; }

    public int Cost { get; }

    public Improvement(string name, int size, int cost)
    {
        Name = name;
        Size = size;
        Cost = cost;
    }
}

public static class ImprovementFactory
{
    public static SortedDictionary<int, Improvement> Improvements { get; }

    //populate dictionary with pool and tree improvements
    static ImprovementFactory()
    {
        Improvements = new SortedDictionary<int, Improvement>
        {
            {1, new Improvement("Pool", 2, 1000)},
            {2, new Improvement("Tree", 1, 500)}
        };
    }

    internal static Improvement GetImprovementByName(string nameOrId)
    {
        //if nameOrId is null, return null
        if (nameOrId == null)
        {
            //log human readable error
            Console.WriteLine("No improvement name or id provided");
            return null;
        }

        //if nameOrId is a key in the dictionary, return the improvement
        //to do so, try to parse nameOrId as an int
        if (int.TryParse(nameOrId, out int id))
        {
            if (Improvements.ContainsKey(id))
            {
                return Improvements[id];
            }

            //log human readable error that the id was not found
            Console.WriteLine($"Improvement with id {id} not found");
        }
        else
        {
            //try to find the improvement by name
            foreach (var improvement in Improvements.Values)
            {
                if (improvement.Name == nameOrId)
                {
                    return improvement;
                }
            }
        }

        //log human readable error that the name was not found
        Console.WriteLine($"Improvement with name or id {nameOrId} not found");
        return null;

    }
}