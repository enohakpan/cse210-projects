class Scripture
{
    private ScriptureReference _reference;
    private List<Word> _words;
    
    public ScriptureReference Reference
    {
        get { return _reference; }
        private set { _reference = value ?? throw new ArgumentNullException(nameof(value)); }
    }
    
    public List<Word> Words
    {
        get { return _words; }
        private set { _words = value.Count > 0 ? value : new List<Word> { new Word("Placeholder") }; }
    }
    
    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }
    
    public string GetDisplayText()
    {
        return $"{Reference}\n{string.Join(" ", Words)}";
    }
    
    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        var visibleWords = Words.Where(w => !w.Hidden).ToList();
        
        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            var wordToHide = visibleWords[rand.Next(visibleWords.Count)];
            wordToHide.Hide();
            visibleWords.Remove(wordToHide);
        }
    }
    
    public bool IsFullyHidden()
    {
        return Words.All(w => w.Hidden);
    }
}
