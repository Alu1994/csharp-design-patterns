using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Console;

namespace SingleResponsibilityPrinciple
{
    class Example
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            WriteLine(j);

            var p = new Persistence();
            var filename = $"{Environment.CurrentDirectory}\\journal.txt";
            p.SaveToFile(j, filename, true);
            p.LoadFile(filename);
        }
    }

    // Uma classe deve ter somente 1 propósito e não mais que isso
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{ ++count}: {text}");
            return count; //memento pattern
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }


        // DOES NOT RESPECT SRP - SINGLE RESPONSABILITY PRINCIPLE
        //public void Save(string filename)
        //{
        //    File.WriteAllText(filename, ToString());
        //}

        //public static Journal Load(string filename)
        //{

        //}

        //public void Load(Uri uri)
        //{

        //}
    }

    //Por esse motivo foi criado uma classe para ter a responsabilidade de fazer a persistencia dos dados.
    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }

        public void LoadFile(string filename)
        {
            if(!string.IsNullOrWhiteSpace(filename))
                Process.Start(@"cmd.exe ", $"/c {filename}");
        }
    }
}
