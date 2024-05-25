using System;

public class Word
{
    private string _text; // Stores the text of the word.
    private bool _isHidden; // Indicates whether the word is hidden or not.
    public Word(string text) { // Constructor to initialize the word with its text.
        _text = text;
        _isHidden = false; // Words are visible by default.
    }
    public string Text => _text; // Gets the text of the word.
    public bool IsHidden => _isHidden; // Checks if the word is hidden.
    public void Hide() // Method hides the word.
    {
        _isHidden = true;
    }
    public void Show() // Method shows the word.
    {
        _isHidden = false;
    }
    public string Display() { // Method to display the word. If hidden, it returns underscores matching the length of the word; otherwise, it returns the actual word.
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}