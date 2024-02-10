class ScripturePassage
{
    private Reference _reference;
    // private string _text;
    private List<Verse> _verses = new();
    // public string Text { get { return _text; } set { _text = value; } }

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
    }

    // Returns the display string for the scripture passage.
    public string GetScripture()
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
}