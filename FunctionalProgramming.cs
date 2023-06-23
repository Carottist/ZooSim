public delegate string TestDelegate(int number, int number2);

public delegate string AnotherDelegate(string text);

public class FunctionalProgramming
{
    public List<TestDelegate> delegates_list = new List<TestDelegate>();

    public AnotherDelegate? another_delegate;

    public void AddDelegate(TestDelegate testDelegate)
    {
        delegates_list.Add(testDelegate);
    }

    //remove delegate
    public void RemoveDelegate(TestDelegate testDelegate)
    {
        delegates_list.Remove(testDelegate);
    }

    public void Execute(int number, int number2)
    {
        foreach (TestDelegate testDelegate in delegates_list)
        {
            string text = testDelegate(number, number2);

            Console.WriteLine(another_delegate?.Invoke(text));
        }
    }
}