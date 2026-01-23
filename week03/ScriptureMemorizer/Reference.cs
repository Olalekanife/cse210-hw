public class Reference
{
    private string _book;
    private int _startChapter;
    private int _startVerse;
    private int _endVerse;

    // Single verse constructor
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _startChapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    // Verse range constructor
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _startChapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Returns formatted reference text
    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
            return $"{_book} {_startChapter}:{_startVerse}";
        else
            return $"{_book} {_startChapter}:{_startVerse}-{_endVerse}";
    }
}
