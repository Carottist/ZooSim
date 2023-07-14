using System;
using System.IO; //input output
using System.Collections.Generic;

public static class DataManager
{
    public static Dictionary<string, List<string>> animalData;


    //this class loads csv at the start of the game
    public static Dictionary<string, List<string>> LoadAnimalData()
    {
        //load csv /scr/Animals/AnimalsData.csv
        var path = "/ZooSim/scr/Animals/AnimalsData.csv";

        //new string array to store data
        var result = new Dictionary<string, List<string>>();

        //read all lines
        using (var reader = new StreamReader(path))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                //add values to result (first line is key, rest is list of values)
                result.Add(values[0], new List<string>(values));
            }
        }
        return result;
    }

    //get animal data by name
    public static List<string> GetAnimalData(string name)
    {
        //check if animal exists
        if (animalData.ContainsKey(name))
        {
            return animalData[name];
        }
        else
        {
            throw new Exception("Animal not found");
        }
    }

    //static constructor
    static DataManager()
    {
        animalData = LoadAnimalData();
    }


}