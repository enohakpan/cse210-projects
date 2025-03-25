public class Comments {
    private string _name;
    private string _text;

    public Comments(string name, string text){
        _name = name;
        _text = text;
    }

    /* getters and setters */
    public string GetName(){
        return _name;
    }

    public void SetName(string name){
        _name = name;
    }

    public string GetText(){
        return _text;
    }

    public void SetText(string text){
        _text = text;
    }
}