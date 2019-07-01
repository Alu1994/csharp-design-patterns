using System;

namespace Coding.Exercise
{
    public class Point
    {
        public int X, Y;

        public Point()
        {

        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point DeepCopy()
        {
            return new Point(X, Y);
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line()
        {

        }

        public Line(Point start, Point end)
        {
            if (start == null)
                throw new ArgumentNullException(paramName: nameof(start));
            if (end == null)
                throw new ArgumentNullException(paramName: nameof(end));

            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return $"{nameof(Start)}: {Start}, {nameof(End)}: {End}";
        }

        public Line DeepCopy()
        {
            return new Line(Start.DeepCopy(), End.DeepCopy());
        }
    }

    class UdemyExercise
    {
        static void Main(string[] args)
        {
            var line1 = new Line(start: new Point(1, 1), end: new Point(10, 10));

            var line2 = line1.DeepCopy();
            line2.Start.X = 2;
            line2.Start.Y = 2;
            line2.End.X = 20;
            line2.End.Y = 20;

            Console.WriteLine(line1);
            Console.WriteLine(line2);
        }
    }
}