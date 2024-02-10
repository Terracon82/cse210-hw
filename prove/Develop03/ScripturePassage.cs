class ScripturePassage
{
    private Reference _reference;
    // private string _text;
    private List<Verse> _verses = new();
    // public string Text { get { return _text; } set { _text = value; } }
    private double _hideWordsProportion = 0.1;
    private bool _allVersesHidden = false;
    private List<int> _visibleVerseIndices = new();

    public ScripturePassage(string reference, string text)
    {
        _reference = new Reference(reference);
        // _text = text;

        List<string> verseTextList = text.Split("\n").ToList();
        for (int i = 0; i < verseTextList.Count; i++)
        {
            Verse verse = new(verseTextList[i]);
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
            outputString += $"{_reference.Verses[i]} " + _verses[i].GetVerse();

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
            {_reference.GetReference()}
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
        DisplayScripture();
        while (_allVersesHidden == false)
        {
            // Console.Clear();
            HideWords();
            Console.ReadLine();
            DisplayScripture();
        }
        Console.ReadLine();
    }
}