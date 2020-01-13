using System;

namespace CS.Impl._01_Basic
{
    public class Sentence
    {
        public string Reverse(string sentence)
        {
            String[] words = sentence.Split(' ');
            Array.Reverse(words);
            return String.Join(" ", words);

                }
    }
}
