using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Filehandling
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string inputdata = Console.ReadLine();


            //FileStream fileStream = new FileStream(@"D:/Sample.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamWriter writer = new StreamWriter(@"D:/Sample.txt");
            writer.WriteLine(inputdata);
            writer.Close();

            StreamReader streamReader = new StreamReader(@"D:/Sample.txt");
            string data = streamReader.ReadToEnd();
            Console.WriteLine(data);
            streamReader.Close();

            //fileStream.Close();
            Console.WriteLine("File creation success!");
            Console.ReadLine();
        }
    }
}

