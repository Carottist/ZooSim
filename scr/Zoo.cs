using System;
using System.Collections.Generic;
using System.Linq;

public class Zoo
{
    //list of cells
    private List<Cell> _cells;

    //list of animals without cell
    private List<Animal> _animals;

    public List<Animal> Animals
    {
        get { return _animals; }
    }

    public List<Cell> Cells
    {
        get { return _cells; }
    }
    //build new cell with certain capacity
    public Cell BuildCell(int width, int height)
    {
        int newCellID = 1;
        //if cells list len is more than 0
        if(_cells.Count > 0)
        {
            //find max id and increment
            newCellID = _cells.Max(x => x.Id) + 1;
        }

        //calculate capacity
        int capacity = width * height;

        //create new cell
        Cell newCell = new Cell(capacity, newCellID);

        //add new cell to list
        _cells.Add(newCell);

        //return new cell
        return newCell;
    }

    //delete cell by id
    public void DeleteCell(int id)
    {
        //check if cell exists
        if(!_cells.Exists(x => x.Id == id))
        {
            Console.WriteLine("Cell with id {0} does not exist", id);
            return;
        }

        int animalsCount = _cells.Find(x => x.Id == id).Animals.Count;
        //check if no animals in cell
        if(animalsCount > 0)
        {
            Console.WriteLine("Cell with id {0} has {1} animals in it", id, animalsCount);
            return;
        }

        //remove cell from list
        _cells.RemoveAll(x => x.Id == id);
    }

    //construct new zoo
    public Zoo()
    {
        _cells = new List<Cell>();

        _animals = new List<Animal>();
    }

    //add animal to zoo
    public void AddAnimalToZooUndistributedList(Animal animal)
    {
       _animals.Add(animal);

        Console.WriteLine("Animal {0} added to zoo, please assign the cell", animal.Name);
    }

    //relocate animal to cell (or undistributed list)
    public void RelocateAnimalToCell(Animal animal, Cell cell)
    {
        //check if enough space in cell
        if(cell.GetFreeSpace() < animal.Size)
        {
            Console.WriteLine("Not enough space in cell {0} for animal {1}", cell.Id, animal.Name);
            return;
        }

        //check if animal already in cell
        if(cell.Animals.Exists(x => x.Name == animal.Name))
        {
            Console.WriteLine("Animal {0} already in cell {1}", animal.Name, cell.Id);
            return;
        }

        //remove from undistributed list and add to cell
        //TODO: check if animal in undistributed list
        //TODO: remove in specific method
        _animals.RemoveAll(x => x.Name == animal.Name);
        cell.AddAnimal(animal);
    }

    //get cell by id
    public Cell GetCellById(int id)
    {
        //check if cell exists
        if(!_cells.Exists(x => x.Id == id))
        {
            throw new Exception("Cell with id " + id + " does not exist");
        }
        return _cells.Find(x => x.Id == id);
    }
}