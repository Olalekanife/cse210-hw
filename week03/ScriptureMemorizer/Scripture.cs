using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (var w in text.Split(' '))
        {
            _words.Add(new Word(w));
        }
    }

    // Hide random words that are not already hidden
    public void HideRandomWords(int count = 1)
    {
        Random rnd = new Random();
        var unhiddenWords = _words.FindAll(word => !word.IsHidden());

        for (int i = 0; i < count && unhiddenWords.Count > 0; i++)
        {
            int index = rnd.Next(unhiddenWords.Count);
            unhiddenWords[index].Hide();
            unhiddenWords.RemoveAt(index); // Ensure we hide a different word next
        }
    }

    // Return the scripture as a display string
    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + "\n";
        foreach (var word in _words)
        {
            result += word.GetDisplayText() + " ";
        }
        return result.Trim();
    }

    // Check if all words are hidden
    public bool IsCompletelyHidden()
    {
        return _words.TrueForAll(word => word.IsHidden());
    }
}
