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
        Console.WriteLine("5. Посмотреть на размеры животного по названию вида");
        Console.WriteLine("6. Показать статус зоопaрка");
        Console.WriteLine("7. Купить улучшение для клетки");

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
            case "5":
                Console.WriteLine("Начинаю проверку размеров...");
                CheckAnimalSize();
                MainZooControl(zoo);
                break;
            case "6":
                Console.WriteLine("Начинаю показ статуса зоопарка...");
                ShowZooInfo(zoo);
                MainZooControl(zoo);
                break;
            case "7":
                Console.WriteLine("Начинаю покупку улучшения для клетки...");
                BuyCellImprovement(zoo);
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

    private static void BuyCellImprovement(Zoo zoo)
    {
        //ensure that zoo has cells
        if (zoo.Cells.Count == 0)
        {
            Console.WriteLine("В зоопарке нет клеток!");
            return;
        }

        //let's choose a cell
        Console.WriteLine("Все клетки в зоопарке:");
        foreach (Cell cell in zoo.Cells)
        {
            Console.WriteLine($"ID: {cell.Id}, в ней живут: {cell.Animals.Count} животных");
        }
        Console.Write("Введите ID клетки, для которой хотите купить улучшение: ");
        int id = int.Parse(Console.ReadLine());

        Cell chosenCell = zoo.GetCellById(id);

        //let's choose an improvement
        Console.WriteLine("Все улучшения:");
        //get keys from improvement factory improvements dictionary
        foreach (int key in ImprovementFactory.Improvements.Keys)
        {
            Console.WriteLine($"Название: {ImprovementFactory.Improvements[key].Name}, цена: {ImprovementFactory.Improvements[key].Cost}");
        }

        Console.Write("Введите название или ID улучшения, которое хотите купить: ");
        string nameOrId = Console.ReadLine();
        //lets try to find by name
        Improvement improvement = ImprovementFactory.GetImprovementByName(nameOrId);

        //if null, log error
        if (improvement == null)
        {
            //log error
            Console.WriteLine("Улучшение не найдено!");
            return;
        }

        //check if we have enough money
        if (zoo.Money < improvement.Cost)
        {
            Console.WriteLine("У вас недостаточно денег!");
            return;
        }

        //let's buy an improvement
        zoo.SpendMoney(improvement.Cost);

        //add improvement to cell
        chosenCell.AddImprovement(improvement);

        Console.WriteLine($"Улучшение {improvement.Name} куплено!");
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

        //check if any animals live in the cell
        Cell chosenCell = zoo.GetCellById(id);
        if (chosenCell.Animals.Count > 0)
        {
            Console.WriteLine("В клетке живут животные! Сначала переселите их в другую клетку!");
            return;
        }

        //let's delete the cell
        zoo.DeleteCell(id);

        Console.WriteLine($"Клетка с ID {id} удалена!");
    }

    //purchase new bear
    public static void PurchaseAnimalTooZoo(Zoo zoo)
    {
        //ensure that we have enough money
        if (zoo.Money <= 100)
        {
            Console.WriteLine("У вас недостаточно денег для покупки медведя!");
            return;
        }

        //spend a money
        zoo.SpendMoney(100);

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

    public static void CheckAnimalSize()
    {
        //let user to input animal name
        Console.Write("Введите название вида животного: ");
        string name = Console.ReadLine();

        //get data from data manager
        List<string> animalData = DataManager.GetAnimalData(name);

        //check if data exists
        if (animalData == null)
        {
            Console.WriteLine("Данные не найдены!");
            return;
        }

        //if data exists, let's show it
        Console.WriteLine($"Название: {animalData[0]}");
        Console.WriteLine($"Размер: {animalData[1]}");
        Console.WriteLine($"Ожидаемая продолжительность жизни: {animalData[2]}");
    }

    //show zoo info
    public static void ShowZooInfo(Zoo zoo)
    {
        Console.WriteLine($"В зоопарке {zoo.Animals.Count} животных и {zoo.Cells.Count} клеток");
        Console.WriteLine($"Денег в зоопарке: {zoo.Money}");
    }

}