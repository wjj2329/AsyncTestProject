using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace AsyncTestProject
{
    public class MyDictionary
    {
        Node root;
       public MyDictionary()
        {
            root = new Node();
        }
        public void AddWord(String word)
        {
            String val = word;
            Node current = root;
            for(int i=0; i<word.Length; i++)
            {
                int index = (int)(word[i]-'a');
                if (current.children[index] == null)
                {
                    current.children[index] = new Node();
                }
                current = current.children[index];
            }
            current.isWord = true;
        }
        public bool ContainsWord(String word)
        {
            Node current = root;
            for(int i=0; i<word.Length; i++)
            {
                int index = (int)(word[i] - 'a');
                if (current.children[index] == null)
                {
                    return false;
                }
                current = current.children[index];
            }
            return current.isWord;
        }
        
        private class Node
        {
            public Node[] children = new Node[26];
            public bool isWord = false;       
        }
    }
    
}
