using System;
using System.Diagnostics;

namespace DesignPatternsInCSharpAnddotNet
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var journal = new Journal();
            journal.AddEntry("I cried today");
            journal.AddEntry("I ate a bug");
            Console.WriteLine(journal);

            var persistence = new Persistence();
            const string filename = @"../../journal.txt";
            persistence.SaveToFile(journal, filename, true);
        }
    }
}