using System.Collections.Generic;
using static System.Console;

namespace DesignPatters_11_Flyweight_2.Exercise
{
    public class TestIt
    {
        static void Main(string[] args)
        {
            var sentence = new Sentence("Hello World");
            sentence[1].Capitalize = true;
            WriteLine(sentence);
        }
    }

    public class Sentence
    {
        private string[] words;
        private Dictionary<int, WordToken> _tokens = new Dictionary<int, WordToken>();

        public Sentence(string plainText)
        {
            words = plainText.Split(' ');
        }

        public WordToken this[int index]
        {
            get
            {
                WordToken wt = new WordToken();
                _tokens.Add(index, wt);
                return _tokens[index];
            }
        }

        public override string ToString()
        {
            var ws = new List<string>();
            for (var i = 0; i < words.Length; i++)
            {
                var w = words[i];
                if (_tokens.ContainsKey(i) && _tokens[i].Capitalize)
                    w = w.ToUpperInvariant();
                ws.Add(w);
            }
            return string.Join(" ", ws);
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
}
