using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometricObjectsSolution;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(22);
            Console.WriteLine(circle.Radius);
            Console.Read();
        }
    }
}
