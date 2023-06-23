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