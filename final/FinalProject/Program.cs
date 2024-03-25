using System;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello FinalProject World!");
        System.Console.WriteLine("This is a file manager. With special stuff!");

        Type shellType = Type.GetTypeFromProgID("WScript.Shell");
        dynamic shell = Activator.CreateInstance(shellType);
        // dynamic shortcut = shell.CreateShortcut(shortcutPath);


        // string shortcutPath = @"C:\PowerShellTest\DestFolder\modified_scene_py.lnk";
        // string targetPath = @"C:\Users\hyrum\Dropbox\Hyrum\S\School\College\CSE 111\modified_scene.py";
        // string description = "Description Goes Here";
        // // string workingDirectory = @"C:\Path\To";
        // // string arguments = "-arg1 -arg2";

        // ShortcutCreator.CreateShortcut(shortcutPath, targetPath, description);
        // Console.WriteLine("Shortcut created successfully.");

        // string shortcutPath = @"C:\Path\To\YourShortcut.lnk";
        // string targetPath = @"C:\Path\To\YourApplication.exe";
        // string description = "Your Shortcut Description";
        // string workingDirectory = @"C:\Path\To";
        // string arguments = "-arg1 -arg2";

        // ShortcutCreator.CreateShortcut(shortcutPath, targetPath, description, workingDirectory, arguments);
        // Console.WriteLine("Shortcut created successfully.");    
    }
}