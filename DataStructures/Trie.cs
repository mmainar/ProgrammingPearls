using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class Trie
    {
        private readonly Dictionary<char, Trie> nodeChars;
        public int TotalWords { get; set; }

        public Trie()
        {
            TotalWords = 0;
            nodeChars = new Dictionary<char, Trie>();
        }

        public void Add(string s)
        {
            Trie node = this;
            foreach (char c in s)
            {
                node = node.Include(c);
            }
            //node.Include('\0');
            TotalWords++;
        }

        public Trie Include(char c)
        {
            if (nodeChars.ContainsKey(c))
            {
                return nodeChars[c];
            }

            var child = new Trie();
            nodeChars.Add(c, child);
            return child;
        }

        public bool Contains(string prefix, out List<string> words)
        {
            words = new List<string>();
            Trie node = this;
            foreach (char c in prefix)
            {
                if (!node.nodeChars.ContainsKey(c))
                {
                    return false;
                }
                node = node.nodeChars[c];
            }

            // Fill words list with the words that start with this prefix prefix
            CollectWords(node, prefix, ref words);
            return true;
        }

        public void PrintWords()
        {
            int totalWordsPrinted = 0;
            var words = new List<string>();
            string prefix = "";
            var sb = new StringBuilder(prefix);
            foreach (var v in nodeChars)
            {
                CollectWords(v.Value, prefix + v.Key, ref words);
            }

            foreach (var word in words)
            {
                Console.WriteLine(word);
                totalWordsPrinted++;
            }

            Console.WriteLine("Total words printed {0}", totalWordsPrinted);
        }

        public void CollectWords(Trie node, string prefix, ref List<string> words)
        {
            if (!node.nodeChars.Any())
            {
                words.Add(prefix);
                return;
            }

            var sb = new StringBuilder(prefix);
            foreach (var v in node.nodeChars)
            {
                CollectWords(v.Value, prefix + v.Key, ref words);
            }
        }
    }
}
