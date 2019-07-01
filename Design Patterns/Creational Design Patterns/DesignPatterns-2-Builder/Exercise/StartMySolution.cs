using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace DesignPatters_2.Exercise // Coding.Exercise
{
    public class Start
    {
        static void Main(string[] args)
        {
            Code code = new CodeBuilder("Person")
                .AddField("Name", "string")
                .AddField("Age", "int");

            WriteLine(code.ToString());
        }
    }

    public class Field
    {
        public string Type, Name;

        public override string ToString()
        {
            return $"public {Type} {Name}";
        }
    }

    public class Code
    {
        public string className;
        public IList<Field> Fields = new List<Field>();
        private const int indentSize = 2;

        public Code()
        {

        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }

        private string ToStringImpl(int indent)
        {
            indent = (indent > 0) ? indent : 1;
            var indentTimes = new string(' ', indentSize * indent);
            StringBuilder classCode = new StringBuilder();
            classCode.AppendLine($"public class {className}").AppendLine("{");
            foreach (var f in Fields)
                classCode.AppendLine($"{indentTimes}{f};");
            return classCode.AppendLine("}").ToString();
        }
    }

    public class CodeBuilder
    {
        public CodeBuilder(string className)
        {
            code.className = className;
        }

        public static implicit operator Code(CodeBuilder cd)
        {
            return cd.code;
        }

        public CodeBuilder AddField(string name, string type)
        {
            code.Fields.Add(new Field { Name = name, Type = type });
            return this;
        }

        public override string ToString()
        {
            return code.ToString();
        }

        private Code code = new Code();
    }
}