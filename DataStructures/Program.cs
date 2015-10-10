using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        private static readonly Trie trie = new Trie();

        private static void Main(string[] args)
        {
            Stream stream =
                Assembly.GetExecutingAssembly().GetManifestResourceStream("DataStructures.Resources.words.txt");
            if (stream == null)
            {
                throw new Exception("Could not read words.txt");
            }

            var words = new List<string>();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int notFoundWords = 0;
            long totalBytesUsedStart = GC.GetTotalMemory(true);
     
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var word = reader.ReadLine();
                    trie.Add(word);
                }
                stream.Position = 0;
                stream.Seek(0, SeekOrigin.Begin);
                while (!reader.EndOfStream)
                {
                    var word = reader.ReadLine();
                    var exists = trie.Contains(word, out words);
                    if (!exists)
                    {
                        notFoundWords++;
                        Console.WriteLine("Trie does not contain word {0}", word);
                    }
                }

            }
            stopWatch.Stop();
            long totalBytesUsedEnd = GC.GetTotalMemory(true);

            Console.WriteLine("Trie has {0} words (not found {1}). Took {2}", trie.TotalWords, notFoundWords, stopWatch.Elapsed);
            Console.WriteLine("Before trie loaded {0} KB ; After {1} MB", totalBytesUsedStart / 1024, totalBytesUsedEnd / (1024 * 1024));
            //trie.PrintWords();
            var sw = new Stopwatch();
            while (true)
            {
                Console.Write("Type your word: ");
                var c = Console.ReadLine();
                sw.Restart();
                trie.Contains(c, out words);
                sw.Stop();
                Console.WriteLine("{0} matching words found in {1}ms :", words.Count, sw.Elapsed.TotalMilliseconds);
                foreach (var word in words)
                {
                    Console.WriteLine(word);
                }
            }

            Console.WriteLine("Press a key to exit");
            Console.ReadLine();
        }
    }
}
