using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTestProject
{
    class WordChecker
    {
        MyDictionary dictionary;
        public WordChecker()
        {
             dictionary = new MyDictionary();
        }
        public void  LoadDictionary()
        {
            Console.WriteLine("Dictionary loading now");//This is the code that is causing us to hang we can't type anything untill this is done
            StreamReader sr = new StreamReader(@"Dictionary.txt");
            int count = 0;
            parseFile(sr, count);
            
           
        }

        private void parseFile(StreamReader sr, int count)
        {
            while (!sr.EndOfStream)
            {
                count++;
                if (count % 1000 == 0) //This Code makes it load slower so we can see the delay feel free to mess with it to make it slower or faster
                    Thread.Sleep(1);
                var word = sr.ReadLine();
                if (Regex.IsMatch(word, @"^[a-zA-Z]+$"))
                    dictionary.AddWord(word.ToLower(new System.Globalization.CultureInfo("en-US")));
            }
        }

        public void CheckWordLoop()
        {
            while (true)
            {
                Console.WriteLine("Which word would you like to search for?"); //Now after this we can type
                var s = Console.ReadLine();
                if (!Regex.IsMatch(s, @"^[a-z]+$"))
                {
                    Console.WriteLine("Pleaes only include lowercase letters! Try Again");
                    continue;
                }
                if (dictionary.ContainsWord(s))
                {
                    Console.WriteLine("The Dictionary Contains the Word");
                }
                else
                {
                    Console.WriteLine("The Dictionary Does Not Contain the Word");
                }
            }
        }
    }
}
