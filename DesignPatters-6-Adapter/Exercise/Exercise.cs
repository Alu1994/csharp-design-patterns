using static System.Console;

namespace DesignPatters_6_Adapter.Exercise
{
    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        private readonly Square square;

        public SquareToRectangleAdapter(Square square)
        {
            this.square = square;
        }

        public int Width => square.Side;
        public int Height => square.Side;
    }

    public class Exercise
    {
        static void Main()
        {
            var square = new Square
            {
                Side = 10
            };

            IRectangle rectangle = new SquareToRectangleAdapter(square);

            var area = rectangle.Area();

            Write($"The area of the Rectangle is: {area}");
        }
    }
}