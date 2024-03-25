// // // static class FileManager
// // // {
// // //     public static void CopyFile(string sourceFile, string destFile, bool includeOldLocationInNewName = false)
// // //     {
// // //         if (!includeOldLocationInNewName)
// // //         {
// // //             File.Copy(sourceFile, destFile);
// // //         }
// // //         else
// // //         {
// // //             // string sourceDirectory = sourceFile.Split("\\")

// // //             // destFile = destFile.
// // //             File.Copy(sourceFile, destFile);
// // //         }
// // //     }
// // // }

// // using System;
// // using System.Runtime.InteropServices;
// // using System.Runtime.InteropServices.ComTypes;
// // using System.Text;

// // public class ShortcutCreator
// // {
// //     // COM Import for ShellLink
// //     [ComImport]
// //     [Guid("00021401-0000-0000-C000-000000000046")]
// //     [ClassInterface(ClassInterfaceType.None)]
// //     private class ShellLink
// //     {
// //     }

// //     // IShellLink interface definition
// //     [ComImport]
// //     [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
// //     [Guid("000214F9-0000-0000-C000-000000000046")]
// //     private interface IShellLink
// //     {
// //         // Add other methods as needed, keeping only those used for this example
// //         void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
// //         void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
// //         void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
// //         void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
// //     }

// //     [ComImport]
// //     [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
// //     [Guid("0000010B-0000-0000-C000-000000000046")]
// //     private interface IPersistFile
// //     {
// //         // Add other methods as needed
// //         void Save([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, [MarshalAs(UnmanagedType.Bool)] bool fRemember);
// //     }

// //     // WIN32_FIND_DATA is included for completeness but may not be necessary for simple shortcut creation
// //     [StructLayout(LayoutKind.Sequential)]
// //     private struct WIN32_FIND_DATA
// //     {
// //         // ... (add struct fields as necessary)
// //     }

// //     // Function to create a shortcut
// // public static void CreateShortcut(string shortcutPath, string targetPath, string description = "", string arguments = "")
// // {
// //     var shellLink = new ShellLink() as IShellLink;

// //     // Set the path of the executable
// //     shellLink.SetPath(targetPath);

// //     // Set the description of the shortcut
// //     if (!string.IsNullOrEmpty(description))
// //     {
// //         shellLink.SetDescription(description);
// //     }

// //     // Extract the directory from the target path and set it as the working directory
// //     var directory = System.IO.Path.GetDirectoryName(targetPath);
// //     shellLink.SetWorkingDirectory(directory);

// //     // Set the arguments if any
// //     if (!string.IsNullOrEmpty(arguments))
// //     {
// //         shellLink.SetArguments(arguments);
// //     }

// //     // Save the shortcut
// //     var persistFile = (IPersistFile)shellLink;
// //     persistFile.Save(shortcutPath, false);
// // }

// // }

// // // Usage example
// // // class Program
// // // {
// // //     static void Main()
// // //     {
// // //         string shortcutPath = @"C:\Path\To\YourShortcut.lnk";
// // //         string targetPath = @"C:\Path\To\YourApplication.exe";
// // //         string description = "Your Shortcut Description";
// // //         string workingDirectory = @"C:\Path\To";
// // //         string arguments = "-arg1 -arg2";

// // //         ShortcutCreator.CreateShortcut(shortcutPath, targetPath, description, workingDirectory, arguments);
// // //         Console.WriteLine("Shortcut created successfully.");
// // //     }
// // // }


// using IWshRuntimeLibrary;
// using System;

// public class ShortcutCreator
// {
//     public static void CreateShortcut(string shortcutPath, string targetPath, string description = "", string workingDirectory = "", string arguments = "")
//     {
//         WshShell shell = new WshShell();
//         IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

//         shortcut.TargetPath = targetPath;
//         shortcut.Description = description;
//         shortcut.WorkingDirectory = workingDirectory;
//         shortcut.Arguments = arguments;

//         shortcut.Save();
//     }
// }