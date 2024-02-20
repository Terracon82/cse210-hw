// class Reference
// {
//     private string _book;
//     private int _chapter;
//     private List<int> _verses;
//     public List<int> Verses { get { return _verses; } }

//     public Reference(string text)
//     {
//         // This takes the first word as the book title.
//         _book = text.Split(" ")[0];

//         // This takes the first number after the space and before the colon.
//         _chapter = int.Parse(text.Split(" ")[1].Split(":")[0]);

//         // This determines whether there are a range of verses or a single verse.
//         if (text.Split(" ")[1].Split(":")[1].Contains('-'))
//         {
//             // This generates a list of the numbers between first and last numbers in the verse range.
//             int lowerRange = int.Parse(text.Split(" ")[1].Split(":")[1].Split("-")[0]);
//             int upperRange = int.Parse(text.Split(" ")[1].Split(":")[1].Split("-").Last());

//             _verses = Enumerable.Range(
//                 lowerRange
//                 , upperRange - lowerRange + 1
//                 ).ToList();
//         }
//         else
//         {
//             // This adds the single verse number to the list of verses. 
//             _verses.Add(int.Parse(text.Split(" ")[1].Split(":")[1].Split("-")[0]));
//         }
//     }

//     public string GetReference()
//     {
//         return
//         // This should display a string like "John 5:4-7". There is an inline if statement to determine whether a second number is necessary.
//         $"""
//         {_book} {_chapter}:{_verses.First()}{(_verses.Count > 1 ? $"-{_verses.Last()}" : "")}
//         """;
//     }

// }