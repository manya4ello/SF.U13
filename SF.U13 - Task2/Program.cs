//Задание 13.6.2
//Ваша задача — написать программу ,которая позволит понять, какие 10 слов чаще всего встречаются в тексте.

using System;
using System.Diagnostics;
using System.IO;
namespace CountWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Text1.txt";

            if (File.Exists(path))
            {
                Console.WriteLine("Подсчет начался");
                var text = File.ReadAllText(path);
                var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
                char[] delimiters = new char[] { ' ', '\r', '\n' };
                var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                                
                HashSet<string> Dic = new HashSet<string>();
                foreach (var word in words)
                    Dic.Add(word);
                Console.WriteLine(Dic.Count);
                Dictionary<string, int> WordCount = new Dictionary<string, int>();

                //foreach (var word in Dic)
                //{
                //    int count = 0;
                //    foreach (string w in words)
                //    {
                //        if (word==w)
                //            count++;
                //    }
                //    WordCount.Add(word, count);
                //}

                foreach (var item in Dic)
                    Console.WriteLine("s:" + item);

                    //foreach (var item in WordCount)
                    //Console.WriteLine(item.Key + " " + item.Value);

                //WordCount = WordCount.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                //foreach (var item in WordCount)
                //    Console.WriteLine(item.Key + " " + item.Value);

            }
            else
                Console.WriteLine("Файл не найден");
            Console.ReadKey();
        }
    }
}
