using System.Collections.Generic;
using NUnit.Framework;

namespace DataStructures
{
    public class TrieTest
    {
        private Trie trie;

        [SetUp]
        public void SetUp()
        {
            trie = new Trie();
        }

        [Test]
        public void Test()
        {
            var sampleWord = "aardvark";
            trie.Add(sampleWord);

            var words = new List<string>();
            Assert.IsTrue(trie.Contains(sampleWord, out words));
        }
    }
}
