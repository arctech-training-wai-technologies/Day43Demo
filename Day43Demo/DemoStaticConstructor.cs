using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day43Demo
{
    public class Point
    {
        public static int x;
        public int y;

        static Point()
        {
            Console.WriteLine("static constructor called");
            x = 100;
        }

        public Point()
        {
            Console.WriteLine("constructor called");
            x = 10;
            y = 20;
        }

        public Point(int xVal, int yVal)
        {
            Console.WriteLine("Parameterized constructor called");
            x = xVal; y = yVal; 
        }
    }
    public class DemoStaticConstructor
    {
        public void Demo()
        {
            Point.x = 100;

            Point point = new Point();
            Point point2 = new Point();
            //Point p1 = new Point(10, 20);
        }
        
    }

}
