using System;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Memorizer!\n");

        ScriptureStandardWorks scriptureStandardWorks = new();
        await scriptureStandardWorks.BuildScriptureStandardWorks();

        string referenceText = "D&C 130:20-21";
        // string scripturePassageText =
        // """
        // There is a law, irrevocably decreed in heaven before the foundations of this world, upon which all blessings are predicated—
        // And when we obtain any blessing from God, it is by obedience to that law upon which it is predicated.
        // """;

        ScriptureStandardWorks.Reference reference = new(scriptureStandardWorks, referenceText);


        ScriptureStandardWorks.ScripturePassage scripturePassage = new(scriptureStandardWorks, reference);

        scripturePassage.MemorizeScripturePassage();

    }
}