using System;
using System.Collections.Generic;
using System.IO;

namespace DesignPatternsInCSharpAnddotNet
{
    public class Journal
    {
        private readonly List<string> _entries = new List<string>();

        private static int _count = 0;

        public int AddEntry(string text)
        {
            _entries.Add($"{++_count}: {text}");
            return _count;
        }

        public void RemoveEntry()
        {
            _entries.RemoveAt(_count - 1);
            _count--;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _entries);
        }
    }
}