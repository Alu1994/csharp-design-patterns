using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Coding.Exercise
{
    public class PrototypeExercise
    {
        [Serializable]
        public class Point
        {
            public int X, Y;
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
            }
        }

        [Serializable]
        public class Line
        {
            public Point Start, End;
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
                return this.DeepCopy<Line>();
            }

            static void Mains(string[] args)
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

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }
    }
}
