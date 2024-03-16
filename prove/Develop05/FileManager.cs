class Filemanager
{
    public static void SaveText(string text, string fileName)
    {
        File.WriteAllText(fileName, text);
    }
    public static string LoadText(string fileName)
    {
        return File.ReadAllText(fileName);
    }
}