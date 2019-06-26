using System;
using static System.Console;

namespace DesignPatters_3_Factory.Example3
{
    class FactoryExample3
    {
        static void Mains(string[] args)
        {
            var point = PointFactory.NewPolarPoint(1.0, Math.PI / 2);
            WriteLine(point);
        }
    }

    public class Point
    {
        private double x, y;
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }

    public static class PointFactory
    {
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }
}