using System;
public class Scripture
{
    private string _verse;
    private string _reference;
    private List<Word> _words; // puts each word in the verse into a list.
    public Scripture(string verse, string reference) {
        _verse = verse;
        _reference = reference;
        _words = verse.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string Verse => _verse;
    public string Reference => _reference;
    public List<Word> Words => _words;
    public void HideRandomWords(int count) { // hides a selected number of words.
        var unhiddenWords = _words.Where(w => !w.IsHidden).ToList();
        var random = new Random();
        for (int i = 0; i < count && unhiddenWords.Any(); i++) { // removes hidden words from list.
            var wordToHide = unhiddenWords[random.Next(unhiddenWords.Count)];
            wordToHide.Hide();
            unhiddenWords.Remove(wordToHide);
        }
    }

    public string Display() { // Displays the Verse with the scripture referance appearing in front of the verse.
        var displayedWords = _words.Select(w => w.Display()).ToArray();
        return $"{_reference} {string.Join(" ", displayedWords)}";
    }
}