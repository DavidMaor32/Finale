using System;
using System.IO;
using System.Linq;


namespace Finale.Wordle {
    public class Wordle {
        public static readonly int WORD_LENGTH = 5;
        public static readonly int NUM_GUESSES = 6;

        private static readonly string WORDS_FILE = @"..\..\Games\Wordle\valid-wordle-words.txt";

        private string  word;
        private int     guesses_left;

        public Wordle() {
            Start();
        }

        public void Start() {
            this.word = GetWord();
            this.guesses_left = NUM_GUESSES;

        }

        public ResultWordle[] Guess(string guess) {
            guess = guess.ToLower();
            if (guess.Length != WORD_LENGTH)
                throw new ArgumentException("Guess must be 5 characters long");
            if (this.guesses_left == 0)
                throw new InvalidOperationException("No more guesses left! the word is:" + this.word);


            string copy = this.word;
            ResultWordle[] res = new ResultWordle[5];

            for (int i = 0; i < WORD_LENGTH; i++)
                if (guess[i] == copy[i]) {
                    res[i] = ResultWordle.Match;
                    copy = ReplaceAt(copy, i, '$');
                }

            for (int i = 0; i < WORD_LENGTH; i++) {
                if (copy[i] == '$')
                    continue;
                if (Count(copy, guess[i]) == 0)
                    res[i] = ResultWordle.Wrong;
                else {
                    res[i] = guess[i] == copy[i] ? ResultWordle.Match : ResultWordle.Misplace;
                    copy = ReplaceAt(copy, IndexOf(copy, guess[i]), '$');
                }

            }
            this.guesses_left--;
            if (this.guesses_left == 0 && !(res.All(r => r == ResultWordle.Match)))
                throw new InvalidOperationException("No more guesses left! the word is:" + this.word);
            return res;
        }
        private string GetWord() {
            string[] words = File.ReadAllLines(WORDS_FILE);
            Random random = new Random();
            return words[random.Next(words.Length)];
        }

        private static int Count(string str, char ch) {
            int count = 0;
            foreach (char c in str) {
                if (c == ch)
                    count++;
            }
            return count;
        }
        private static int IndexOf(string str, char ch) {
            for (int index = 0; index < str.Length; index++) {
                if (str[index] == ch)
                    return index;
            }
            return -1;
        }

        private string ReplaceAt(string str, int index, char ch) {
            return str.Substring(0, index) + ch + str.Substring(index + 1);
        }

    }
}
