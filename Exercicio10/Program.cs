using System;
using System.Collections.Generic;

namespace Exercicio10
{
    class Program
    {
        static void Main(string[] args)
        {
            int language;
            while (true)
            {
                Console.WriteLine("Choose a language: 1 - English, 2 - Portuguese");
                if (int.TryParse(Console.ReadLine(), out language) && (language == 1 || language == 2))
                {
                    break;
                }
            }

            string sentence;
            while (true)
            {
                Console.WriteLine("Enter a sentence:");
                sentence = Console.ReadLine();
                if (!string.IsNullOrEmpty(sentence))
                {
                    break;
                }
            }

            Pangram pangram = language switch
            {
                1 => new EnglishPangram(sentence),
                2 => new PortuguesePangram(sentence),
                _ => throw new InvalidOperationException("How did we get here?")
            };

            Console.WriteLine(pangram.IsPangram() ? "It's a pangram" : "It's not a pangram");
        }
    }

    abstract class Pangram
    {
        protected string Sentence { get; }

        public Pangram(string sentence)
        {
            Sentence = sentence;
        }

        public abstract bool IsPangram();
    }

    class EnglishPangram : Pangram
    {
        public EnglishPangram(string sentence) : base(sentence) { }

        public override bool IsPangram()
        {
            HashSet<char> letters = new HashSet<char>();
            foreach (var letter in Sentence)
            {
                char lowerLetter = char.ToLower(letter);
                if (lowerLetter >= 'a' && lowerLetter <= 'z')
                {
                    letters.Add(lowerLetter);
                }
            }

            return letters.Count == 26;
        }
    }

    class PortuguesePangram : Pangram
    {
        public PortuguesePangram(string sentence) : base(sentence) { }

        private static readonly Dictionary<char, char> SpecialCharacters = new()
        {
            {'à', 'a'}, {'á', 'a'}, {'â', 'a'}, {'ã', 'a'},
            {'é', 'e'}, {'ê', 'e'},
            {'í', 'i'},
            {'ó', 'o'}, {'ô', 'o'}, {'õ', 'o'},
            {'ú', 'u'},
            {'ç', 'c'}
        };

        private char GetLetter(char letter)
        {
            letter = char.ToLower(letter);
            if (letter == 'k' || letter == 'w' || letter == 'y')
            {
                return '\0';
            }
            else if (letter >= 'a' && letter <= 'z')
            {
                return letter;
            }

            else if (SpecialCharacters.ContainsKey(letter))
            {
                return SpecialCharacters[letter];
            }

            return '\0';
        }

        public override bool IsPangram()
        {
            HashSet<char> letters = new HashSet<char>();
            foreach (var letter in Sentence)
            {
                char normalizedLetter = GetLetter(letter);
                if (normalizedLetter != '\0')
                {
                    letters.Add(normalizedLetter);
                }
            }

            // Portuguese alphabet has 23 letters (no k, w, y)
            return letters.Count == 23;
        }
    }
}