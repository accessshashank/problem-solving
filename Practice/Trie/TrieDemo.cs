using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.TrieClass;

namespace Practice.TrieDemo
{
    class TrieDemo
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            Insert(trie.Root, "apple");
            Insert(trie.Root, "act");
            Insert(trie.Root, "ace");
            Insert(trie.Root, "bad");
            Insert(trie.Root, "apples");
            Insert(trie.Root, "actor");
            Insert(trie.Root, "actress");

            var msg = SearchTrie(trie.Root, "ace") == null ? "ace not present" : "ace is present";
            Console.WriteLine(msg);

            msg = SearchTrie(trie.Root, "apple") == null ? "apple not present" : "apple is present";
            Console.WriteLine(msg);

            msg = SearchTrie(trie.Root, "actt") == null ? "actt not present" : "actt is present";
            Console.WriteLine(msg);

            Console.WriteLine("Here are words starting with ac");

            var allWords = AutoComplete(trie.Root, "ac");
            foreach (var item in allWords)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Autocorrecting words for actrewqwe");
            allWords = AutoCorrect(trie.Root, "actrewqwe");
            foreach (var item in allWords)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Autocorrecting words for act");
            allWords = AutoCorrect(trie.Root, "act");
            foreach (var item in allWords)
            {
                Console.WriteLine(item);
            }
        }

        private static List<string> AutoCorrect(TrieNode node, string word)
        {
            int len = word.Length;
            var allWords = new List<string>();
            while (len > 0)
            {
                string subStr = word.Substring(0, len);
                var foundNode = SearchTrie(node, subStr);
                if(foundNode != null && len == word.Length)
                {
                    var res = new List<string>();
                    res.Add(word);
                    return res;
                }
                else if(foundNode != null)
                {                    
                    GetAllStringsStartingWith(foundNode, subStr, allWords);
                    if (allWords != null) return allWords;
                    len--;
                }
                else
                {
                    len--;
                }
            }
            return null;
        }

        private static List<string> AutoComplete(TrieNode node, string word)
        {
            var foundNode = SearchTrie(node, word);
            if (foundNode == null) return null;
            var allWords = new List<string>();
            GetAllStringsStartingWith(foundNode, word, allWords);
            return allWords;
        }

        private static void GetAllStringsStartingWith(TrieNode node, string word, List<string> allWords)
        {
            foreach (var childNode in node.Children)
            {
                if(childNode.Key == '*')
                {
                    allWords.Add(word);
                }
                else
                {
                    GetAllStringsStartingWith(childNode.Value, word + childNode.Key, allWords);
                }
            }
        }

        private static TrieNode SearchTrie(TrieNode node, string str)
        {
            var currentNode = node;

            foreach (var ch in str.ToCharArray())
            {
                if(currentNode.Children.ContainsKey(ch))
                {
                    currentNode = currentNode.Children[ch];
                }
                else
                {
                    return null;
                }
            }

            return currentNode;
        }

        private static void Insert(TrieNode root, string str)
        {
            var currentNode = root;
            foreach (var ch in str.ToCharArray())
            {
                if(currentNode.Children.ContainsKey(ch))
                {
                    currentNode = currentNode.Children[ch];
                }
                else
                {
                    TrieNode node = new TrieNode();
                    currentNode.Children.Add(ch, node);
                    currentNode = node;
                }
            }

            currentNode.Children.Add('*', null);
        }
    }
}
