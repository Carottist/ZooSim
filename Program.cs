using System;
using System.Data.SqlTypes;

class Program
{
    //list here
    List<int> ints = new List<int>();
    List<string> strings = new List<string>();

    static void Main(string[] args)
    {
        Zoo zoo = new Zoo();
        Console.WriteLine("Добро пожаловать!");
        zoo.EarnMoney(19500);
        Control.MainZooControl(zoo);
    }
}


/*
class Program
{
    static string AddTwoNumbers(int a, int b)
    {
        //add two numbers and convert to string
        return (a + b).ToString();
    }

    //multiply two numbers
    static string MultiplyTwoNumbers(int a, int b)
    {
      return (a * b).ToString();  
    }

    //function to take text and return it with brackets
    static string TakeToBrackets(string text)
    {
        return "(" + text + ")";
    }

    //reverse a string and return it
    static string Reverse(string text)
    {
        //convert string to char array
        char[] charArray = text.ToCharArray();

        //reverse the char array
        Array.Reverse(charArray);

        //return the reversed string
        return new string(charArray);
    }

    static void Main(string[] args)
    {
        //create functional programming class instance
        FunctionalProgramming fp = new FunctionalProgramming();

        //add to the list
        fp.AddDelegate(AddTwoNumbers);

        //add to the list
        fp.AddDelegate(MultiplyTwoNumbers);

        fp.another_delegate = TakeToBrackets;

        //execute all delegates in the list
        fp.Execute(5, 10);

        /*public void Execute(int number, int number2)
        {
            foreach (TestDelegate testDelegate in delegates_list)
            {
                string text = testDelegate(number, number2);

                Console.WriteLine(another_delegate?.Invoke(text));
            }
        }

        fp.another_delegate = Reverse;

        //add to the list
        fp.AddDelegate(AddTwoNumbers);

        //remove from the list
        fp.RemoveDelegate(MultiplyTwoNumbers);

        fp.Execute(5, 10);

        /*public void Execute(int number, int number2)
        {
            foreach (TestDelegate testDelegate in delegates_list)
            {
                string text = testDelegate(number, number2);

                Console.WriteLine(another_delegate?.Invoke(text));
            }
        }
    }
}*/