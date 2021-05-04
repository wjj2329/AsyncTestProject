using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AsyncTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            WordChecker wordChecker = new WordChecker();
            wordChecker.LoadDictionary();
            wordChecker.CheckWordLoop();
        }
    }
}
