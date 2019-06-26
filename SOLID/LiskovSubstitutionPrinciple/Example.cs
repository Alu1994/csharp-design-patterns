using static System.Console;

namespace LiskovSubstitutionPrinciple
{
    public class Example
    {
        public static int Area(RectangleWrong r) => r.Width * r.Height;
        public static int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2, 3);
            WriteLine($"{rc} has area {Area(rc)}");

            Rectangle sq = new Square();
            sq.Width = 4;
            WriteLine($"{sq} has area {Area(sq)}");
        }
    }
}
