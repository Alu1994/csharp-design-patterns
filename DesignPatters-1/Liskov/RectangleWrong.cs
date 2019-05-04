using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatters_1.Liskov
{
    public class RectangleWrong
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public RectangleWrong()
        {

        }

        public RectangleWrong(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }
}
