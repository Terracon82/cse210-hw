class Video
{
    private List<Comment> _comments = new();
    public int NumComments { get { return _comments.Count; } }
    private string _title;
    private string _author;
    private int _length;

    public string DisplayString
    {
        get
        {
            return
                $"""
                {_title} - {_author}
                {_length} minutes
                {NumComments} comments

                """
                ;
        }
    }

    public string DisplayStringComments
    {
        get
        {
            string displayString = "";

            foreach (Comment comment in _comments)
            {
                displayString += comment.DisplayString;
            }

            return displayString;
        }
    }

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }
}