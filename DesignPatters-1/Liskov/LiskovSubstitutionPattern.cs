using static System.Console;

namespace DesignPatters_1.Liskov
{
    public class LiskovSubstitutionPattern
    {
        public static int Area(RectangleWrong r) => r.Width * r.Height;
        public static int Area(Rectangle r) => r.Width * r.Height;

        static void Main_s(string[] args)
        {
            Rectangle rc = new Rectangle(2, 3);
            WriteLine($"{rc} has area {Area(rc)}");

            Rectangle sq = new Square();
            sq.Width = 4;
            WriteLine($"{sq} has area {Area(sq)}");
        }
    }
}
