using System;

public static class Control
{
    public static void MainZooControl(Zoo zoo)
    {
        Console.WriteLine("Введите номер действия, которое хотите совершить:");
        Console.WriteLine("1. Построить новую клетку");
        Console.WriteLine("2. Удалить клетку");
        Console.WriteLine("3. Приобрести медведя");
        Console.WriteLine("4. Переселить животное в клетку");

        Console.WriteLine("0. Выйти из программы");

        string action = Console.ReadLine();

        switch (action)
        {
            case "1":
                Console.WriteLine("Начинаю строительство новой клетки...");
                BuildNewCell(zoo);
                MainZooControl(zoo);
                break;
            case "2":
                Console.WriteLine("Начинаю снос клетки");
                DeleteCell(zoo);
                MainZooControl(zoo);
                break;
            case "3":
                Console.WriteLine("Начинаю покупку медведя...");
                PurchaseAnimalTooZoo(zoo);
                MainZooControl(zoo);
                break;
            case "4":
                Console.WriteLine("Начинаю переселение животного...");
                RelocateAnimalToCell(zoo);
                MainZooControl(zoo);
                break;
            case "0":
                Console.WriteLine("До свидания! Будем рады видеть вас снова!");
                System.Environment.Exit(0);
                break;
            default:
                Console.WriteLine("I don't understand this command:(");
                //recursion
                MainZooControl(zoo);
                break;
        }
    }
    public static void BuildNewCell(Zoo zoo)
    {
        Console.Write("Введите длину новой клетки: ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Введите ширину новой клетки: ");
        int width = int.Parse(Console.ReadLine());

        //let's build a new cell in the zoo
        Cell newCell = zoo.BuildCell(length, width);

        Console.WriteLine($"Клетка построена! Её ID: {newCell.Id}");
    }

    public static void DeleteCell(Zoo zoo)
    {
        //ensure that zoo has cells
        if (zoo.Cells.Count == 0)
        {
            Console.WriteLine("В зоопарке нет клеток!");
            return;
        }

        //let's show all cells
        Console.WriteLine("Все клетки в зоопарке:");
        foreach (Cell cell in zoo.Cells)
        {
            Console.WriteLine($"ID: {cell.Id}, в ней живут: {cell.Animals.Count} животных");
        }
        Console.Write("Введите ID клетки, которую хотите удалить: ");
        int id = int.Parse(Console.ReadLine());

        //let's delete the cell
        zoo.DeleteCell(id);

        Console.WriteLine($"Клетка с ID {id} удалена!");
    }

    //purchase new bear
    public static void PurchaseAnimalTooZoo(Zoo zoo)
    {
        Animal newAnimal = AnimalGenerator.GenerateVinnieBear();

        zoo.AddAnimalToZooUndistributedList(newAnimal);
    }

    public static void RelocateAnimalToCell(Zoo zoo)
    {
        //ensure that zoo has cells
        if (zoo.Cells.Count == 0)
        {
            Console.WriteLine("В зоопарке нет клеток!");
            return;
        }

        //ensure that zoo has animals
        if (zoo.Animals.Count == 0)
        {
            Console.WriteLine("В зоопарке нет животных!");
            return;
        }

        //let's show all cells
        Console.WriteLine("Все клетки в зоопарке:");
        foreach (Cell cell in zoo.Cells)
        {
            Console.WriteLine($"ID: {cell.Id}, в ней живут: {cell.Animals.Count} животных");
        }
        Console.Write("Введите ID клетки, в которую хотите переселить животное: ");
        int id = int.Parse(Console.ReadLine());

        //get cell by id
        Cell chosenCell = zoo.GetCellById(id);

        //choose animal same way
        Console.WriteLine("Все животные в зоопарке:");
        foreach (Animal animal in zoo.Animals)
        {
            Console.WriteLine($"Имя: {animal.Name}");
        }

        Console.Write("Введите имя животного, которое хотите переселить: ");
        string name = Console.ReadLine();

        //get animal by name (no method)
        Animal chosenAnimal = null;
        foreach (Animal animal in zoo.Animals)
        {
            if (animal.Name == name)
            {
                chosenAnimal = animal;
                break;
            }
        }

        //if animal not found return
        if (chosenAnimal == null)
        {
            Console.WriteLine("Животное не найдено!");
            return;
        }

        


        //let's relocate the animal from undistributed list to the cell
        zoo.RelocateAnimalToCell(chosenAnimal, chosenCell);

        Console.WriteLine($"Животное {chosenAnimal.Name} переселено в клетку {chosenCell.Id}!");
    }
}