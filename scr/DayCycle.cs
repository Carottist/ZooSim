//this class 
public static class DayCycle
{
    public static void StartDayCycleForZoo(Zoo zoo)
    {
        //iterate all animals in zoo
        //to do it, get all cell from zoo
        //and iterate all animals in each cell
        foreach (var cell in zoo.Cells)
        {
            foreach (var animal in cell.Animals)
            {
                animal.Activity();
            }
        }

        
    }
}