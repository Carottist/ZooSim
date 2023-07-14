using System;

public class GenericTestClass<T>
{
    public T GenericMethod(T arg)
    {
        return arg;
    }
}

public class CustomList<T> //where T: class
{
    //array to store items
    T[] items = new T[10];

    public void RewriteAtIndex(T item, int index)
    {
        items[index] = item;
    }

    //constructor
    public CustomList()
    {
        //initialize array
        items = new T[10];
    }
}

public class TestClass
{
    public void TestMethod()
    {
        CustomList<int> list = new CustomList<int>();
        list.RewriteAtIndex(1, 1); //make wrong
        //list.RewriteAtIndex("Yes", 2); //make correct

        CustomList<string> list2 = new CustomList<string>();
        list2.RewriteAtIndex("Hello", 3);

        List<object> animals = new List<object>();

        //get first animal
        object animal = animals[0];
    }
}

//42 - число в десятичной системе счисления

//42 = 4*10^1 + 2*10^0

//728 = 7*10^2 + 2*10^1 + 8*10^0


//запишем степени двойки
//2^0 = 1
//2^1 = 2
//2^2 = 4
//2^3 = 8
//2^4 = 16
//2^5 = 32
//2^6 = 64

//запишем степени двойки в двоичной системе счисления
//2^0 = 1
//2^1 = 10
//2^2 = 100
//2^3 = 1000

// 1 + 1 = 10
// 10 + 1 = 11

//42 = 2^5 (32) + 2^3 (8) + 2^1 (2)
//100 = 2^6 (64) * 1 + 2^5 (32) * 1 + 2^2 (4) * 1 = 1100100
//101 = 2^6 (64) * 1 + 2^5 (32) * 1 + 2^2 (4) * 1 + 2^0 (1) * 1 = 1100101

//int zero = 0
//00000000000000000000000000001010

//00000000000000000000000000000010 - 1
//00000000000000000000000000000001 - 1
//00000000000000000000000000000000 - 1
//11111111111111111111111111111111 - 1

// 0-255, -127 - 128

// 1 - 10