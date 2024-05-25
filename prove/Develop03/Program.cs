using System;

class Program
{
    static void Main(string[] args) {
        Console.WriteLine("Hello Develop03 World!");
        // This will start by displaying "AAA" and waiting for the user to press the enter key
        Console.WriteLine("AAA");
        Console.ReadLine();

        // This will clear the console
        Console.Clear();

        // This will show "BBB" in the console where "AAA" used to be
        Console.WriteLine("BBB");
    }
}

/*
using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private string _verse;
    private string _reference;
    private List<string> _words;
    private HashSet<int> _maskedIndices;

    public Scripture(string verse, string reference)
    {
        _verse = verse;
        _reference = reference;
        _words = verse.Split(' ').ToList();
        _maskedIndices = new HashSet<int>();
    }

    public string Verse => _verse;
    public string Reference => _reference;
    public List<string> Words => _words;
    public HashSet<int> MaskedIndices
    {
        get => _maskedIndices;
        set => _maskedIndices = value;
    }
}

class Reference
{
    private Scripture _scripture;

    public Reference(Scripture scripture)
    {
        _scripture = scripture;
    }

    public string Display()
    {
        var displayedWords = _scripture.Words.Select((word, i) => 
            _scripture.MaskedIndices.Contains(i) ? new string('_', word.Length) : word);
        return string.Join(" ", displayedWords) + " " + _scripture.Reference;
    }
}

class Word
{
    private Scripture _scripture;
    private Random _random;

    public Word(Scripture scripture)
    {
        _scripture = scripture;
        _random = new Random();
    }

    public void MaskWords(int numWords = 3)
    {
        var indicesToMask = _scripture.Words
            .Select((word, index) => index)
            .Where(index => !_scripture.MaskedIndices.Contains(index))
            .OrderBy(x => _random.Next())
            .Take(numWords)
            .ToList();

        foreach (var index in indicesToMask)
        {
            _scripture.MaskedIndices.Add(index);
        }
    }
}

class Program
{
    private Scripture _scripture;
    private Reference _reference;
    private Word _word;

    public Program(string verse, string reference)
    {
        _scripture = new Scripture(verse, reference);
        _reference = new Reference(_scripture);
        _word = new Word(_scripture);
    }

    public void Run()
    {
        while (!IsComplete())
        {
            _word.MaskWords();
            Console.WriteLine(_reference.Display());
            Console.WriteLine("Press Enter to continue or type 'quit' to end: ");
            string userInput = Console.ReadLine().Trim().ToLower();
            if (userInput == "quit")
            {
                Quit();
            }
        }
        Console.WriteLine("You have memorized the verse!");
    }

    private bool IsComplete()
    {
        return _scripture.MaskedIndices.Count == _scripture.Words.Count;
    }

    private void Quit()
    {
        Console.WriteLine("Quitting the program.");
        Environment.Exit(0);
    }

    static void Main(string[] args)
    {
        string verse = "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life.";
        string reference = "John 3:16";
        Program program = new Program(verse, reference);
        program.Run();
    }
}
*/