using System;
using System.Text.RegularExpressions;


namespace ScriptureMemorizer
{
    public class ScriptureReference
    {
        public string Book { get; private set; }
        public int Chapter { get; private set; }
        public int VerseStart { get; private set; }
        public int VerseEnd { get; private set; }


        public ScriptureReference(string book, int chapter, int verse)
        : this(book, chapter, verse, verse) { }


        public ScriptureReference(string book, int chapter, int verseStart, int verseEnd)
        {
            Book = book ?? throw new ArgumentNullException(nameof(book));
            Chapter = chapter;
            VerseStart = verseStart;
            VerseEnd = verseEnd;
        }


        public static ScriptureReference Parse(string input)
        {
            var m = Regex.Match(input.Trim(), @"^(.+?)\s+(\d+):(\d+)(?:-(\d+))?$");
            if (!m.Success)
                throw new FormatException("Invalid reference format.");


            var book = m.Groups[1].Value;
            var chapter = int.Parse(m.Groups[2].Value);
            var start = int.Parse(m.Groups[3].Value);
            var end = m.Groups[4].Success ? int.Parse(m.Groups[4].Value) : start;


            return new ScriptureReference(book, chapter, start, end);
        }


        public override string ToString()
        {
            return VerseStart == VerseEnd ? $"{Book} {Chapter}:{VerseStart}" : $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
        }
    }
}