using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace ScriptureMemorizer
{
    public class Scripture
    {
        private ScriptureReference _reference;
        private List<Word> _words;
        private static Random _rand = new Random();


        public Scripture(ScriptureReference reference, string text)
        {
            _reference = reference ?? throw new ArgumentNullException(nameof(reference));
            _words = Tokenize(text ?? string.Empty);
        }


        private List<Word> Tokenize(string text)
        {
            var tokens = Regex.Split(text.Trim(), "\\s+");
            return tokens.Where(t => t.Length > 0).Select(t => new Word(t)).ToList();
        }


        public bool AllHidden => _words.Where(w => w.HasLetters).All(w => w.IsHidden);


        public string GetDisplayText()
        {
            return $"{_reference}\n\n{string.Join(" ", _words.Select(w => w.GetDisplay()))}";
        }


        public void HideRandomWords(int count = 3, bool avoidAlreadyHidden = true)
        {
            if (count <= 0) return;


            var candidates = avoidAlreadyHidden
            ? _words.Where(w => !w.IsHidden && w.HasLetters).ToList()
            : _words.Where(w => w.HasLetters).ToList();


            if (!candidates.Any()) return;


            count = Math.Min(count, candidates.Count);
            var chosenIndices = new HashSet<int>();


            while (chosenIndices.Count < count)
            {
                int idx = _rand.Next(candidates.Count);
                chosenIndices.Add(idx);
            }


            foreach (var i in chosenIndices)
            {
                candidates[i].Hide();
            }
        }
    }
}