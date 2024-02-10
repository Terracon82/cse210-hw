class Verse
{
    private List<Word> _words = new();

    public Verse(string text)
    {
        for (int i = 0; i < text.Split(" ").Length; i++)
        {
            Word word = new(text.Split(" ")[i]);
            _words.Add(word);
        }
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
}