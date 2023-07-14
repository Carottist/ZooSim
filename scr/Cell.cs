using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a cell with animals in the zoo
/// </summary>
public class Cell
{
    private List<ICellContainment> _cellContainment; // list of animals in the cell

    //id field and property
    private int _id;
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    //property to get the list of animals
    //get all animals in the cell containment list
    public List<Animal> Animals
    {
        get
        {
            List<Animal> animals = new();
            foreach (ICellContainment cellContainment in _cellContainment)
            {
                if (cellContainment is Animal animal)
                {
                    animals.Add(animal);
                }
            }
            return animals;
        }
    }

    //property to get the list of improvements
    //get all improvements in the cell containment list
    public List<Improvement> Improvements
    {
        get
        {
            List<Improvement> improvements = new();
            foreach (ICellContainment cellContainment in _cellContainment)
            {
                if (cellContainment is Improvement improvement)
                {
                    improvements.Add(improvement);
                }
            }
            return improvements;
        }
    }

    //capacity field and property
    private int _capacity;
    public int Capacity
    {
        get { return _capacity; }
        set { _capacity = value; }
    }

    

    public Cell(int capacity, int id)
    {
        _id = id;
        _capacity = capacity;
    }

    public void AddAnimal(Animal animal)
    {
        if(animal.Size <= GetFreeSpace())
        {
        _cellContainment.Add(animal);
        }
    }

    public void AddImprovement(Improvement improvement)
    {
        //check if the improvement size is less than the free space
        if (improvement.Size > GetFreeSpace())
        {
            //log in console
            Console.WriteLine("Improvement size is too big for the cell");
            return;
        }

        //check if the improvement with the similar name is already in the cell
        if (Improvements.Any(imp => imp.Name == improvement.Name))
        {
            //log in console
            Console.WriteLine("Improvement with the same name is already in the cell");
            return;
        }

        //add improvement to the cell
        Improvements.Add(improvement);
    }

    public void RemoveAnimal(Animal animal)
    {
        _cellContainment.Remove(animal);
    }

    /*
    private int GetFreeSpace()
    {
        return Capacity - _animals.Sum(animal => animal.Size);
    }*/

    public int GetFreeSpace()
    {
        int occupiedSpace = 0;

        //for each ISize in both animals and improvements, add the size to the occupiedSpace
        foreach (ISize size in _cellContainment)
        {
            occupiedSpace += size.Size;
        }

        return Capacity - occupiedSpace; 
    }
    
    public void RelocateAnimalToUndistributedList(Animal animal, Zoo zoo)
    {
        //check if animal is in the cell
        if (_cellContainment.Contains(animal))
        {
            //remove animal from the cell
            _cellContainment.Remove(animal);
            //add animal to the undistributed list
            zoo.AddAnimalToZooUndistributedList(animal);
        }
    }
   
} 