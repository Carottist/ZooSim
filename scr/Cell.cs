using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a cell with animals in the zoo
/// </summary>
public class Cell
{
    private List<Animal> _animals; // list of animals in the cell

    //id field and property
    private int _id;
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    //property to get the list of animals
    public List<Animal> Animals
    {
        get { return _animals; }
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
        _animals = new List<Animal>();
    }

    public void AddAnimal(Animal animal)
    {
        if(animal.Size <= GetFreeSpace())
        {
        _animals.Add(animal);
        }
    }

    public void RemoveAnimal(Animal animal)
    {
        _animals.Remove(animal);
    }

    /*
    private int GetFreeSpace()
    {
        return Capacity - _animals.Sum(animal => animal.Size);
    }*/

    public int GetFreeSpace()
    {
        int occupiedSpace = 0;
        foreach (Animal animal in _animals)
        {
            //long way to do the same thing:
            //occupiedSpace = occupiedSpace + animal.Size;
            occupiedSpace += animal.Size;
        }

        return Capacity - occupiedSpace; 
    }
    
    public void RelocateAnimalToUndistributedList(Animal animal, Zoo zoo)
    {
        //check if animal is in the cell
        if (_animals.Contains(animal))
        {
            //remove animal from the cell
            _animals.Remove(animal);
            //add animal to the undistributed list
            zoo.AddAnimalToZooUndistributedList(animal);
        }
    }
   
} 