using System;
using static System.Console;

namespace DesignPatters_7_Bridge.Exercise
{
    public class Exercise
    {
        static void Main(string[] args)
        {
            WriteLine(new Square(new VectorRenderer()));
            WriteLine(new Triangle(new RasterRenderer()));
        }
    }

    public interface IRenderer
    {
        string WhatToRenderAs { get; set; }
    }

    public abstract class Shape
    {
        protected IRenderer renderer;

        protected Shape(IRenderer renderer)
        {
            if (renderer == null)
                throw new ArgumentNullException(paramName: nameof(renderer));

            this.renderer = renderer;
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer)
        {
            renderer.WhatToRenderAs = "Square";
        }

        public override string ToString()
        {
            return renderer.ToString();
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
        {
            renderer.WhatToRenderAs = "Triangle";
        }

        public override string ToString()
        {
            return renderer.ToString();
        }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs { get; set; }

        public override string ToString()
        {
            return $"Drawing {WhatToRenderAs} as lines";
        }
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs { get; set; }

        public override string ToString()
        {
            return $"Drawing {WhatToRenderAs} as pixels";
        }
    }
}