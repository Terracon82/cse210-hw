class Verse
{
    // private int _verseID;
    private List<Word> _words = new();
    private bool _allWordsHidden = false;
    public bool AllWordsHidden { get { return _allWordsHidden; } }

    private List<int> _visibleWordsIndices = new();


    public Verse(string text)
    {
        for (int i = 0; i < text.Split(" ").Length; i++)
        {
            Word word = new(text.Split(" ")[i]);
            _words.Add(word);
        }

        // Generates a list of indices of the visible words in _words.
        _visibleWordsIndices = _words.Select((word, index) => new { word, index })
                    .Where(pair => !pair.word.Hidden)
                    .Select(pair => pair.index)
                    .ToList();
    }

    public string GetVerse()
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