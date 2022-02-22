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
                Console.WriteLine("Файл найден");
                var text = File.ReadAllText(path);
                var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
                char[] delimiters = new char[] { ' ', '\r', '\n' };
                var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                                
                HashSet<string> Dic = new HashSet<string>(words);

                Console.WriteLine("Всего слов:" + Dic.Count);

                Console.WriteLine("Введите минимальное колличество букв в слове:");
                string input;
                int minlength;
                do
                {
                    input = Console.ReadLine();
                }
                while (!int.TryParse(input, out minlength) ||(minlength < 0));

                foreach (string word in Dic)
                    if (word.Length < minlength)
                        Dic.Remove(word);

                Dictionary<string, int> WordCount = new Dictionary<string, int>();

                foreach (var word in Dic)
                {
                    int count = 0;
                    foreach (string w in words)
                    {
                        if (word == w)
                            count++;
                    }
                    WordCount.Add(word, count);
                }

                
                var wordnumbers = WordCount.ToArray();
                for (int i = 0; i < wordnumbers.Length; i++)
                    for (int j = i; j < wordnumbers.Length; j++)
                    {
                        if (wordnumbers[i].Value < wordnumbers[j].Value)
                            (wordnumbers[i], wordnumbers[j]) = (wordnumbers[j], wordnumbers[i]);
                    }

                Console.WriteLine("Топ 10 слов");
                for (int i =0; i <10; i++)
                    Console.WriteLine("Слово "+wordnumbers[i].Key + " встречается " + wordnumbers[i].Value +" раз");

            }
            else
                Console.WriteLine("Файл не найден");
            Console.ReadKey();
        }
    }
}
