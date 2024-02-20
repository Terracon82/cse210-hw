using System.Text.RegularExpressions;

class ScriptureStandardWorks
{
    private List<Volume> _volumes = new();
    public List<Volume> Volumes { get { return _volumes; } }

    public class Volume
    {
        private int _volumeID;
        public int VolumeID { get { return _volumeID; } }
        private string _volumeTitle;
        private string _volumeLongTitle;
        private string _volumeSubtitle;
        private string _volumeShortTitle;
        private string _volumeLdsUrl;
        private List<Book> _books = new();
        public List<Book> Books { get { return _books; } }


        public Volume(int volumeID
        , string volumeTitle
        , string volumeLongTitle
        , string volumeSubtitle
        , string volumeShortTitle
        , string volumeLdsUrl
        )
        {
            _volumeID = volumeID;
            _volumeTitle = volumeTitle;
            _volumeLongTitle = volumeLongTitle;
            _volumeSubtitle = volumeSubtitle;
            _volumeShortTitle = volumeShortTitle;
            _volumeLdsUrl = volumeLdsUrl;
        }
    }

    public class Book
    {
        private int _bookID;
        public int BookID { get { return _bookID; } }
        private string _bookTitle;
        public string BookTitle { get { return _bookTitle; } }

        private string _bookLongTitle;
        public string BookLongTitle { get { return _bookLongTitle; } }

        private string _bookSubtitle;
        public string BookSubtitle { get { return _bookSubtitle; } }

        private string _bookShortTitle;
        public string BookShortTitle { get { return _bookShortTitle; } }

        private string _bookLdsUrl;
        public string BookLdsUrl { get { return _bookLdsUrl; } }

        private List<Chapter> _chapters = new();
        public List<Chapter> Chapters { get { return _chapters; } }


        public Book(int bookId
        , string bookTitle
        , string bookLongTitle
        , string bookSubtitle
        , string bookShortTitle
        , string bookLdsUrl
        )
        {
            _bookID = bookId;
            _bookTitle = bookTitle;
            _bookLongTitle = bookLongTitle;
            _bookSubtitle = bookSubtitle;
            _bookShortTitle = bookShortTitle;
            _bookLdsUrl = bookLdsUrl;
        }

    }

    public class Chapter
    {
        private int _chapterID;
        public int ChapterID { get { return _chapterID; } }

        private int _chapterNumber;
        public int ChapterNumber { get { return _chapterNumber; } }
        private List<Verse> _verses = new();
        public List<Verse> Verses { get { return _verses; } }

        public Chapter(int chapterId, int chapterNumber)
        {
            _chapterID = chapterId;
            _chapterNumber = chapterNumber;
        }
    }

    public class Verse
    {
        private List<Word> _words = new();
        private int _verseID;
        public int VerseID { get { return _verseID; } }
        private int _verseNumber;
        public int VerseNumber { get { return _verseNumber; } }
        private string _verseTitle;
        public string VerseTitle { get { return _verseTitle; } }
        private string _verseShortTitle;
        public string VerseShortTitle { get { return _verseShortTitle; } }

        private bool _allWordsHidden = false;
        private List<int> _visibleWordsIndices = new();
        public bool AllWordsHidden { get { return _allWordsHidden; } }


        public Verse(int verseID, int verseNumber, string verseTitle, string verseShortTitle, string scriptureText)
        {
            _verseID = verseID;
            _verseNumber = verseNumber;
            _verseTitle = verseTitle;
            _verseShortTitle = verseShortTitle;

            for (int i = 0; i < scriptureText.Split(" ").Length; i++)
            {
                Word word = new(scriptureText.Split(" ")[i]);
                _words.Add(word);
            }

            // Generates a list of indices of the visible words in _words.
            _visibleWordsIndices = _words.Select((word, index) => new { word, index })
                        .Where(pair => !pair.word.Hidden)
                        .Select(pair => pair.index)
                        .ToList();

        }


        public string GetVerseText()
        {
            string outputString = "";

            for (int i = 0; i < _words.Count; i++)
            {
                // This adds one word at a time to the verse
                outputString += _words[i].GetWord();

                // Unless it is the last word, it adds a space after every word.
                if (i != _words.Count - 1)
                {
                    outputString += " ";
                }
            }

            return outputString;
        }

        public void HideWords(double hideProportion)
        {
            // Determines the number of words to hide based on the hideProportion variable.
            int numHiddenWords = (int)Math.Ceiling((double)_words.Count * hideProportion);

            // Randomly orders the visibleWordsIndices list and takes the first numHiddenWords items.
            Random random = new();
            List<int> hiddenWordsIndices = _visibleWordsIndices.OrderBy(x => random.Next()).Take(numHiddenWords).ToList();

            // Hides each word at each index in the hiddenWordsIndices.
            foreach (int index in hiddenWordsIndices)
            {
                _words[index].HideWord();
            }

            // Generates a list of indices of the visible words in _words.
            _visibleWordsIndices = _words.Select((word, index) => new { word, index })
                .Where(pair => !pair.word.Hidden)
                .Select(pair => pair.index)
                .ToList();

            // This checks if all words are hidden.
            if (_visibleWordsIndices.Count == 0)
            {
                _allWordsHidden = true;
                return;
            }
        }
    }

    public class Word
    {
        private string _text;
        private bool _hidden = false;
        public bool Hidden { get { return _hidden; } }

        public Word(string text)
        {
            _text = text;
        }

        public void HideWord()
        {
            this._hidden = true;
        }

        public string GetWord()
        {
            if (!_hidden)
            {
                return _text;
            }
            else
            {
                return new String('_', _text.Length);
            }
        }

    }

    public class Reference
    {
        private ScriptureStandardWorks _scriptureStandardWorks;
        public string ReferenceName { get; set; }
        private int _volumeID;
        private int _bookID;
        private int _chapterID;
        private List<int> _verseIDList;
        public List<int> VerseIDs { get { return _verseIDList; } }

        public Reference(int volumeID, int bookID, int chapterID, List<int> verseIDList, string referenceName)
        {
            ReferenceName = referenceName;
            _volumeID = volumeID;
            _bookID = bookID;
            _chapterID = chapterID;
            _verseIDList = verseIDList;
        }

        public Reference(ScriptureStandardWorks scriptureStandardWorks, string referenceText, string referenceName = null)
        {
            _scriptureStandardWorks = scriptureStandardWorks;

            // This takes the first word as the book title.
            string bookName = referenceText.Split(" ")[0];

            // This takes the first number after the space and before the colon.
            int chapterNumber = int.Parse(referenceText.Split(" ")[1].Split(":")[0]);

            List<int> verseNumberList = new();
            // This determines whether there are a range of verses or a single verse.
            if (referenceText.Split(" ")[1].Split(":")[1].Contains('-'))
            {
                // This generates a list of the numbers between first and last numbers in the verse range.
                int lowerRange = int.Parse(referenceText.Split(" ")[1].Split(":")[1].Split("-")[0]);
                int upperRange = int.Parse(referenceText.Split(" ")[1].Split(":")[1].Split("-").Last());

                verseNumberList = Enumerable.Range(
                    lowerRange
                    , upperRange - lowerRange + 1
                    ).ToList();
            }
            else
            {
                // This adds the single verse number to the list of verses. 
                verseNumberList.Add(int.Parse(referenceText.Split(" ")[1].Split(":")[1].Split("-")[0]));
            }

            Volume volume = _scriptureStandardWorks.Volumes.First(volume => volume.Books.Any((book => book.BookShortTitle == bookName)));
            int volumeID = volume.VolumeID;

            Book book = volume.Books.First(book => book.BookShortTitle == bookName);
            int bookID = book.BookID;

            Chapter chapter = book.Chapters.First(chapter => chapter.ChapterNumber == chapterNumber);
            int chapterID = chapter.ChapterID;

            List<int> verseIDList = new();
            foreach (int verseNumber in verseNumberList)
            {
                Verse verse = chapter.Verses.First(verse => verse.VerseNumber == verseNumber);

                verseIDList.Add(verse.VerseID);
            }

            if (referenceName == null)
            {
                referenceName = referenceText;
            }

            ReferenceName = referenceName;
            _volumeID = volumeID;
            _bookID = bookID;
            _chapterID = chapterID;
            _verseIDList = verseIDList;
        }

        // public string GetReferenceString()
        // {
        //     return
        //     // This should display a string like "John 5:4-7". There is an inline if statement to determine whether a second number is necessary.
        //     $"""
        //     {_book} {_chapter}:{_verses.First()}{(_verses.Count > 1 ? $"-{_verses.Last()}" : "")}
        //     """;
        // }

    }

    public class ScripturePassage
    {
        private ScriptureStandardWorks _scriptureStandardWorks;
        private Reference _reference;
        // private string _text;
        private List<Verse> _verses = new();
        // public string Text { get { return _text; } set { _text = value; } }
        private double _hideWordsProportion = 0.1;
        private bool _allVersesHidden = false;
        private List<int> _visibleVerseIndices = new();

        public ScripturePassage(ScriptureStandardWorks scriptureStandardWorks, Reference reference)
        {
            _scriptureStandardWorks = scriptureStandardWorks;
            _reference = reference;

            foreach (int verseID in reference.VerseIDs)
            {
                Verse verse = _scriptureStandardWorks.GetVerse(verseID);
                _verses.Add(verse);
            }

            _visibleVerseIndices = _verses.Select((verse, index) => new { verse, index })
            .Where(pair => !pair.verse.AllWordsHidden)
            .Select(pair => pair.index)
            .ToList();
        }

        // Returns the display string for the scripture passage.
        private string GetScripture()
        {
            string outputString = "";
            for (int i = 0; i < _verses.Count; i++)
            {
                // This adds one verse at a time to the passage.
                outputString += $"{_verses[i].VerseNumber} " + _verses[i].GetVerseText();

                // Unless it is the last verse, it adds a newline after every verse.
                if (i != _verses.Count - 1)
                {
                    outputString += "\n";
                }
            }

            return outputString;
            // $"""
            // {_reference.GetReference()} {_text}
            // """;
        }

        public void DisplayScripture()
        {
            System.Console.WriteLine(
                $"""
            {_reference.ReferenceName}
            {this.GetScripture()}
            """
            );
        }

        private void HideWords()
        {
            foreach (int index in _visibleVerseIndices)
            {
                _verses[index].HideWords(_hideWordsProportion);
            }

            _visibleVerseIndices = _verses.Select((verse, index) => new { verse, index })
            .Where(pair => !pair.verse.AllWordsHidden)
            .Select(pair => pair.index)
            .ToList();

            if (_visibleVerseIndices.Count == 0)
            {
                _allVersesHidden = true;
                return;
            }
        }

        public void MemorizeScripturePassage()
        {
            Console.Clear();
            DisplayScripture();
            Console.Write("\nPress enter to continue or type 'quit' to finish: ");
            string continueLoop = Console.ReadLine();
            while (_allVersesHidden == false)
            {
                HideWords();

                Console.Clear();
                DisplayScripture();
                Console.Write("\nPress enter to continue or type 'quit' to finish: ");
                continueLoop = Console.ReadLine();

                if (continueLoop == "quit")
                {
                    break;
                }
            }
        }
    }

    public async Task BuildScriptureStandardWorks()
    {
        string completeScriptureString = await FileManager.LoadCsvFromZipAsync("https://docs.nephi.org/scriptures/downloads/lds-scriptures.csv.zip");
        List<string> verseRows = Regex.Split(completeScriptureString, @"\r?\n(?=\d)").ToList();

        foreach (string verseRowTextRaw in verseRows.Skip(1)) // Skip the header row
        {
            List<string> verseRow = Regex.Split(verseRowTextRaw, @",(?=(?:[^""]*""[^""]*"")*[^""]*$)").ToList();

            int volumeID = int.Parse(verseRow[0]);
            int bookID = int.Parse(verseRow[1]);
            int chapterID = int.Parse(verseRow[2]);
            int verseID = int.Parse(verseRow[3]);
            string volumeTitle = verseRow[4];
            string bookTitle = verseRow[5];
            string volumeLongTitle = verseRow[6];
            string bookLongTitle = verseRow[7];
            string volumeSubtitle = verseRow[8];
            string bookSubtitle = verseRow[9];
            string volumeShortTitle = verseRow[10];
            string bookShortTitle = verseRow[11];
            string volumeLdsUrl = verseRow[12];
            string bookLdsUrl = verseRow[13];
            int chapterNumber = int.Parse(verseRow[14]);
            int verseNumber = int.Parse(verseRow[15]);
            string scriptureText = verseRow[16];
            string verseTitle = verseRow[17];
            string verseShortTitle = verseRow[18];


            Volume thisVolume = _volumes.FirstOrDefault(volume => volume.VolumeID == volumeID);

            if (thisVolume == null)
            {
                Volume volume = new(volumeID, volumeTitle, volumeLongTitle, volumeSubtitle, volumeShortTitle, volumeLdsUrl);
                _volumes.Add(volume);
            }

            Book thisBook = _volumes.FirstOrDefault(volume => volume.VolumeID == volumeID)
            .Books.FirstOrDefault(book => book.BookID == bookID);

            if (thisBook == null)
            {
                Book book = new(bookID, bookTitle, bookLongTitle, bookSubtitle, bookShortTitle, bookLdsUrl);
                _volumes.FirstOrDefault(volume => volume.VolumeID == volumeID)
                .Books.Add(book);
            }

            Chapter thisChapter = _volumes.FirstOrDefault(volume => volume.VolumeID == volumeID)
            .Books.FirstOrDefault(book => book.BookID == bookID)
            .Chapters.FirstOrDefault(chapter => chapter.ChapterID == chapterID);

            if (thisChapter == null)
            {
                Chapter chapter = new(chapterID, chapterNumber);
                _volumes.FirstOrDefault(volume => volume.VolumeID == volumeID)
                .Books.FirstOrDefault(book => book.BookID == bookID)
                .Chapters.Add(chapter);
            }

            Verse thisVerse = _volumes.FirstOrDefault(volume => volume.VolumeID == volumeID)
            .Books.FirstOrDefault(book => book.BookID == bookID)
            .Chapters.FirstOrDefault(chapter => chapter.ChapterID == chapterID)
            .Verses.FirstOrDefault(verse => verse.VerseID == verseID);

            if (thisVerse == null)
            {
                Verse verse = new(verseID, verseNumber, verseTitle, verseShortTitle, scriptureText);
                _volumes.FirstOrDefault(volume => volume.VolumeID == volumeID)
                .Books.FirstOrDefault(book => book.BookID == bookID)
                .Chapters.FirstOrDefault(chapter => chapter.ChapterID == chapterID)
                .Verses.Add(verse);
            }

        }

    }

    public Volume GetVolume(int volumeID)
    {
        Volume volume = Volumes.First(volume => volume.VolumeID == volumeID);
        return volume;
    }

    public Book GetBook(int bookID)
    {
        Volume volume = Volumes.First(volume => volume.Books.Any(book => book.BookID == bookID));

        Book book = volume.Books.First(book => book.BookID == bookID);

        return book;
    }

    public Chapter GetChapter(int chapterID)
    {
        Volume volume = Volumes.First(volume => volume.Books.Any(book => book.Chapters.Any(chapter => chapter.ChapterID == chapterID)));

        Book book = volume.Books.First(book => book.Chapters.Any(chapter => chapter.ChapterID == chapterID));

        Chapter chapter = book.Chapters.First(chapter => chapter.ChapterID == chapterID);

        return chapter;
    }

    public Verse GetVerse(int verseID)
    {
        Volume volume = Volumes.First(volume => volume.Books.Any(book => book.Chapters.Any(chapter => chapter.Verses.Any(verse => verse.VerseID == verseID))));

        Book book = volume.Books.First(book => book.Chapters.Any(chapter => chapter.Verses.Any(verse => verse.VerseID == verseID)));

        Chapter chapter = book.Chapters.First(chapter => chapter.Verses.Any(verse => verse.VerseID == verseID));

        Verse verse = chapter.Verses.First(verse => verse.VerseID == verseID);

        return verse;
    }
}
