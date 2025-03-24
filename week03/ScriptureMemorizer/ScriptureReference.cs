class ScriptureReference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int? _endVerse;

    public string Book
    {
        get { return _book; }
        private set { _book = value.Length > 0 ? value : "Unknown"; }
    }

    public int Chapter
    {
        get { return _chapter; }
        private set { _chapter = value > 0 ? value : 1; }
    }

    public int StartVerse
    {
        get { return _startVerse; }
        private set { _startVerse = value > 0 ? value : 1; }
    }

    public int? EndVerse
    {
        get { return _endVerse; }
        private set { _endVerse = value >= StartVerse ? value : null; }
    }
    
    public ScriptureReference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }
    
    public override string ToString()
    {
        return EndVerse == null ? $"{Book} {Chapter}:{StartVerse}" : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}
