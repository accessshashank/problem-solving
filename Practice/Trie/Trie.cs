using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.TrieClass
{
    public class Trie
    {
        public Trie()
        {
            Root = new TrieNode();
        }
        public TrieNode Root { get; set; }
    }

    public class TrieNode
    {
        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
        }
        public Dictionary<char, TrieNode> Children { get; set; }
    }
}
