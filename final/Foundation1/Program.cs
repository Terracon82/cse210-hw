class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation1 World!");
        System.Console.WriteLine();

        List<Video> videos = CreateVideos(5);
        List<Comment> comments = CreateComments(15);

        int commentIndex = 0;
        for (int i = 0; i < videos.Count; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                videos[i].AddComment(comments[commentIndex]);
                commentIndex++;
            }
        }

        foreach (Video video in videos)
        {
            System.Console.WriteLine(video.DisplayString);
            System.Console.WriteLine(video.DisplayStringComments);
        }

    }

    static List<Video> CreateVideos(int numVideos)
    {
        List<Video> videos = new();
        string title = "";
        string author = "";
        int length = 0;
        Random random = new();

        for (int i = 1; i <= numVideos; i++)
        {
            title = $"Example Video Title {i}";
            author = $"Example Video Author {i}";
            length = random.Next(24);

            videos.Add(new Video(title, author, length));
        }

        return videos;
    }

    static List<Comment> CreateComments(int numComments)
    {
        List<Comment> comments = new();
        string author = "";
        string text = "";

        for (int i = 1; i <= numComments; i++)
        {
            author = $"Example Comment Author {i}";
            text = $"Example Comment Text {i}";

            comments.Add(new Comment(author, text));
        }

        return comments;
    }
}