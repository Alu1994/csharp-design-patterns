using System;
using System.Text;
using static System.Console;

namespace DesignPatters_2
{
    public class WithoutBuilder
    {
        static void Mains(string[] args)
        {
            var sb = new StringBuilder();

            var hello = "hello";
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            WriteLine(sb);

            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach(var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");
            WriteLine(sb);
        }
    }
}
