﻿using System;
using static System.Console;

namespace DesignPatters_3_Factory.Example2
{
    class FactoryExample
    {
        static void Mains(string[] args)
        {
            var point = Point.NewPolarPoint(1.0, Math.PI / 2);
            WriteLine(point);
        }
    }

    public class Point
    {
        // factory methods
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        private double x, y;
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
}