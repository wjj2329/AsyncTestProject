using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AsyncTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            WordChecker wordChecker = new WordChecker();
           //await wordChecker.LoadDictionary();
            wordChecker.LoadDictionary();
            wordChecker.CheckWordLoop();
        }
        
    }
}
