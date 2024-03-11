static class FileManager
{
    public static void CopyFile(string sourceFile, string destFile, bool includeOldLocationInNewName = false)
    {
        if (!includeOldLocationInNewName)
        {
            File.Copy(sourceFile, destFile);
        }
        else
        {
            // string sourceDirectory = sourceFile.Split("\\")

            // destFile = destFile.
            File.Copy(sourceFile, destFile);
        }
    }
}