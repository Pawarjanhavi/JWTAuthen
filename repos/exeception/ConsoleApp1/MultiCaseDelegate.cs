using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MultiCaseDelegate
    {
        public delegate void calcDelegate(double height, double width);

        public static void area(double aheight,double awidth)
        {
            Console.WriteLine("Area is {0}", (aheight * awidth));

        }

        public static void perimeter(double pheight, double pwidth)
        {
            Console.WriteLine("Perimeter is {0}", (pheight + pwidth));

        }

        public static void Main(String[] args)
        {
            calcDelegate calcDelegate = new calcDelegate(area);
            calcDelegate += perimeter;

            calcDelegate.Invoke(4.5, 7.8);
            Console.ReadLine();
        }


    }

}
