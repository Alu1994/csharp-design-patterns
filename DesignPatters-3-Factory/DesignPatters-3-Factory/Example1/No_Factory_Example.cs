using System;

namespace DesignPatters_3_Factory.Example1
{

    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }

    public class Point
    {
        private double x, y;

        /// <summary>
        /// Initializes a point from EITHER cartesian or polar
        /// </summary>
        /// <param name="a">x if cartesian, rho if polar</param>
        /// <param name="b"></param>
        /// <param name="system"></param>
        public Point(double a, double b,
            CoordinateSystem system = CoordinateSystem.Cartesian)
        {
            switch (system)
            {
                case CoordinateSystem.Cartesian:
                    x = a;
                    y = b;
                    break;
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(system), system, null);
            }
        }
    }

    class No_Factory_Example
    {
        static void Mains(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
