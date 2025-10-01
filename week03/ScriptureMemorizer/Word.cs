using System;
using System.Linq;


namespace ScriptureMemorizer
{
    public class Word
    {
        private string _text;
        private bool _hidden;


        public Word(string text)
        {
            _text = text ?? string.Empty;
            _hidden = false;
        }


        public bool HasLetters => _text.Any(char.IsLetter);
        public bool IsHidden => _hidden;


        public void Hide()
        {
            if (HasLetters) _hidden = true;
        }


        public string GetDisplay()
        {
            if (!_hidden) return _text;


            var chars = _text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i])) chars[i] = '_';
            }
            return new string(chars);
        }


        public override string ToString() => GetDisplay();
    }
}