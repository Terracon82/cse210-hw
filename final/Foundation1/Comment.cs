class Comment
{
    private string _author;
    public string Author { get { return _author; } }
    private string _text;
    public string Text { get { return _text; } }

    public string DisplayString {get{return 
    $"""
    {_author}:
    {_text}


    """;}}

    public Comment(string author, string text)
{
    _author = author;
    _text = text;
}
}