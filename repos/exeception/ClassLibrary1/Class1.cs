namespace ClassLibrary1
{
    public class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello, World!");

            FileStream fileStream = new FileStream(@"S:\Sample.txt", FileMode.Create);
            fileStream.Close();
            Console.WriteLine("File creation success!");
            Console.ReadLine();
        }


    }
}
