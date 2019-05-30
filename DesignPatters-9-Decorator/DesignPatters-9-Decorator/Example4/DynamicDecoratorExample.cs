using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace DesignPatters_9_Decorator.Example4
{
    public class DynamicDecoratorExample
    {
        static void Mains(string[] args)
        {
            var square = new Square(1.23f);
            WriteLine(square.AsString());

            var redSquare = new ColoredShape(square, "red");
            WriteLine(redSquare.AsString());

            var redHalfTransparentSquare = new TransparentShape(redSquare, 0.5f);
            WriteLine(redHalfTransparentSquare.AsString());
        }
    }

    public interface IShape
    {
        string AsString();
    }

    // dynamic
    public class Circle : IShape
    {
        private float radius;

        public Circle() : this(0)
        {

        }

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public void Resize(float factor)
        {
            radius *= factor;
        }

        public string AsString() => $"A circle of radius {radius}";
    }

    public class Square : IShape
    {
        private float side;

        public Square() : this(0)
        {

        }

        public Square(float side)
        {
            this.side = side;
        }

        public string AsString() => $"A square with side {side}";
    }


    public class ColoredShape : IShape
    {
        private IShape shape;
        private string color;

        public ColoredShape(IShape shape, string color)
        {
            this.shape = shape ?? throw new ArgumentNullException(paramName: nameof(shape));
            this.color = color ?? throw new ArgumentNullException(paramName: nameof(color));
        }

        public string AsString() => $"{shape.AsString()} has the color {color}";
    }

    public class TransparentShape : IShape
    {
        private IShape shape;
        private float transparency;

        public TransparentShape(IShape shape, float transparency)
        {
            this.shape = shape ?? throw new ArgumentNullException(paramName: nameof(shape));
            this.transparency = transparency;
        }

        public string AsString() => $"{shape.AsString()} has {transparency * 100.0f} transparency";
    }
}
