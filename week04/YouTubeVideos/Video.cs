public class Videos{
    private string _title;
    private string _author;
    private int _length;
    private List<Comments> _comments;

    public Videos(string title, string author, int length){
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comments>();
    }

    /* getters and setters */

    public string GetTitle(){
        return _title;
    }

    public void SetTitle (string title){
        _title = title;
    }

    public string GetAuthor(){
        return _author;
    }

    public void SetAuthor (string author){
        _author = author;
    }

    public int GetLength(){
        return _length;
    }

    public void SetLength (int length){
        _length = length;
    }

     public List<Comments> GetComments(){
        return _comments;
    }

    public void AddComments(Comments comments){
        _comments.Add(comments);
    }

    public int GetCommentCount(){
        return _comments.Count;
    }

    public void DisplayVideo()
    {
        Console.WriteLine(" ");
        Console.WriteLine("These are the details for your video.");
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");

        Console.WriteLine("Comments:");
        foreach (var comment in _comments)
        {
            Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
        }
    }
}