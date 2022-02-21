//Задание 13.6.1
//Наша задача — сравнить производительность вставки в List<T> и LinkedList<T>.Для этого используйте уже знакомый вам StopWatch.

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
                Console.WriteLine("Введите колличество интераций для сравнения");
                string input;
                int runs;
                do
                {
                    input = Console.ReadLine();
                }
                while (!int.TryParse(input, out runs));

                double [] liststat = new double[runs];
                double [] linkedliststat = new double[runs];
                double SumList = 0;
                double SumLList = 0;
                Console.WriteLine($"Запускаем сравнение на {runs} проходов. \nList \tLinkedList");
                for (int i = 0;i<runs;i++)
                {
                    liststat[i] = WriteToList(path);
                    SumList += liststat[i];
                    Console.Write(liststat[i]);
                    linkedliststat [i] = WriteToLinkedList(path);
                    SumLList += linkedliststat[i];
                    Console.WriteLine($"\t{linkedliststat[i]}");
                }
                Console.WriteLine($"Итого за {runs} проходов:");
                Console.Write(SumList);
                Console.WriteLine($"\t{SumLList}");
                double AvgList = SumList/runs;
                double AvgLList = SumLList / runs;
                Console.WriteLine($"Среднее за {runs} проходов:");
                Console.Write(AvgList);
                Console.WriteLine($"\t{AvgLList}");
            }
            else
                Console.WriteLine("Файл не найден");
            Console.ReadKey();
        }

        static double WriteToList(string path)
        {
            var text = File.ReadLines(path);
            List<string> lines = new List<string>();

            var stopWatch = Stopwatch.StartNew();
            foreach (string line in text)
                lines.Add(line);
            return stopWatch.Elapsed.TotalMilliseconds;
        }

        static double WriteToLinkedList(string path)
        {
            var text = File.ReadLines(path);
            LinkedList<string> lines = new LinkedList<string>();

            var stopWatch = Stopwatch.StartNew();
            foreach (string line in text)
                lines.AddLast(line);
            return stopWatch.Elapsed.TotalMilliseconds;
        }
    }
}