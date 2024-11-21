internal class Delegates

{
    public delegate void MyDelegate(int hours, string work);

    static void Main(string[] args)
    {
        MyDelegate myDelegate = new MyDelegate(MyMethod);
        // myDelegate (10, "typing");
        myDelegate.Invoke(20, "Teaching");
        Console.WriteLine();

        Console.ReadLine();
    }

    public static void MyMethod(int hrs, string wrk)

    {
        Console.WriteLine("My Method running......");
        Console.WriteLine($"Hours : {hrs} Works : {wrk}");
    }
}