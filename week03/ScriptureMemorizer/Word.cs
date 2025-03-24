class Word
{
    private string _text;
    private bool _Hidden;
    
    public string Text
    {
        get { return _text; }
        private set { _text = value.Length > 0 ? value : "_"; }
    }
    
    public bool Hidden
    {
        get { return _Hidden; }
        private set { _Hidden = value; }
    }
    
    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }
    
    public void Hide()
    {
        Hidden = true;
    }
    
    public override string ToString()
    {
        return Hidden ? new string('_', Text.Length) : Text;
    }
}
