using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Digite a palavra-base:");
            string baseWord = Console.ReadLine();

            Console.WriteLine("Digite as palavras candidatas separadas por espaço:");
            string[] candidateWordsArray = Console.ReadLine().Split(' ');

            List<string> candidateWords = new List<string>(candidateWordsArray);

            AnagramGame anagramGame = new AnagramGame(baseWord, candidateWords);
            List<string> anagrams = anagramGame.FindAnagrams();

            if (anagrams.Count > 0)
            {
                Console.WriteLine("Anagramas:");
                foreach (var anagram in anagrams)
                {
                    Console.WriteLine(anagram);
                }
            }
            else
            {
                Console.WriteLine("Nenhum anagrama");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

public class AnagramGame
{
    private string _baseWord;
    private List<string> _candidateWords;

    public AnagramGame(string baseWord, List<string> candidateWords)
    {
        BaseWord = baseWord;
        CandidateWords = candidateWords;
    }

    public string BaseWord
    {
        get { return _baseWord; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Palavra base não pode ser vazia");
            }
            if (!value.All(c => char.IsLetter(c)))
            {
                throw new ArgumentException("Palavra base deve conter apenas caracteres alfabéticos ASCII");
            }
            _baseWord = value;
        }
    }

    public List<string> CandidateWords
    {
        get { return _candidateWords; }
        set
        {
            if (value == null || value.Count == 0)
            {
                throw new ArgumentException("A lista de palavras candidatas não pode ser nula ou vazia");
            }
            foreach (var word in value)
            {
                if (!word.All(c => char.IsLetter(c)))
                {
                    throw new ArgumentException("Todas as palavras candidatas devem conter apenas caracteres alfabéticos ASCII");
                }
            }
            _candidateWords = value;
        }
    }

    public List<string> FindAnagrams()
    {
        string sortedBaseWord = String.Concat(BaseWord.ToLower().OrderBy(c => c));

        List<string> anagrams = new List<string>();

        foreach (string candidate in CandidateWords)
        {
            if (candidate.ToLower() != BaseWord.ToLower() &&
                String.Concat(candidate.ToLower().OrderBy(c => c)) == sortedBaseWord)
            {
                anagrams.Add(candidate);
            }
        }

        return anagrams;
    }
}