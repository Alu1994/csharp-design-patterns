using System;
using static System.Console;

namespace DesignPatterns_3_Factory.Example4
{
    class FactoryExample4
    {
        static void Mains(string[] args)
        {
            // Inner Class Factory
            var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
            WriteLine(point);

            // Property Factory
            var origin = Point.Origin;

            // Field Factory
            var origin2 = Point.Origin2;
        }
    }

    public class Point
    {
        public static PointFactory Factory => new PointFactory();

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        // Prop - Transient - Instanciate Multiple Times
        public static Point Origin => new Point(0, 0);

        // Field - Singleton - Instanciate One Time
        public static Point Origin2 = new Point(0, 0);  // better

        private double x, y;
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public class PointFactory
        {
            public Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }
}