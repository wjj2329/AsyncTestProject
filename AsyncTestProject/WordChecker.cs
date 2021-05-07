using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private bool isDoneLoading = false;
        public WordChecker()
        {
           dictionary = new MyDictionary();
        }
        public  async Task LoadDictionary()
        {
            Console.WriteLine("Dictionary loading now!");
            Console.WriteLine("Type a word to search!");
            StreamReader sr = new StreamReader(@"Dictionary.txt");
            await ParseFile(sr);//This is the code that is causing us to hang we can't type anything until this is done
            Console.WriteLine("Dictionary Done Loading");
            isDoneLoading = true;
           
        }

        private async Task ParseFile(StreamReader sr)
        {
            try
            {
                await Task<long>.Run(() =>
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    Thread.Sleep(5000);
                    while (!sr.EndOfStream)
                    {
                        var word = sr.ReadLine();
                        if (Regex.IsMatch(word, @"^[a-zA-Z]+$"))
                            dictionary.AddWord(word.ToLower(new System.Globalization.CultureInfo("en-US")));
                        stopWatch.Stop();
                    }
                    return stopWatch.ElapsedMilliseconds;
                }).ContinueWith(result => { Console.WriteLine("The Dictionary took " + result.Result.ToString()+" ammount of ms to load"); });
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CheckWordLoop()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (!isDoneLoading)
                {
                    Console.WriteLine("The Dictionary is still loading please try searching later");
                    continue;
                }                 
                if (!Regex.IsMatch(input, @"^[a-z]+$"))
                {
                    Console.WriteLine("Pleaes only include lowercase letters! Try Again");
                    continue;
                }
                if (dictionary.ContainsWord(input))
                {
                    Console.WriteLine("The Dictionary Contains the Word");
                }
                else
                {
                    Console.WriteLine("The Dictionary Does Not Contain the Word");
                }
                Console.WriteLine("Which word would you like to search for?"); //Now after this we can type
            }
        }
    }
}
