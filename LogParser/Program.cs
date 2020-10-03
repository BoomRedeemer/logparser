using System;
using System.IO;

namespace LogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к папке");
            string sourceDirectory = Console.ReadLine();

            Console.WriteLine("Введите слово или его часть для проверки совпадения");
            string searchWord = Console.ReadLine();

           /* string logfilePath = @"C:\logloglog.txt";

            if (File.Exists(logfilePath))
            {
                File.Delete(logfilePath);
            }

            using (FileStream fs = File.Create(logfilePath))
            {

            }
            */
            try
            {
                var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt");
                foreach (string currentFile in txtFiles)
                {
                    string fileName = currentFile.Substring(sourceDirectory.Length + 1);
                    Console.WriteLine(fileName);
                    StreamReader sr = new StreamReader(currentFile);

                    string line1;

                    while ((line1 = sr.ReadLine()) != null)
                    {
                        if (line1.Contains(searchWord))
                        {
                            Console.WriteLine("нашлось");
                        }
                        else
                        {
                            Console.WriteLine("не нашлось");
                        }
                    }
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                try
                {

                    using StreamReader sr = new StreamReader(sourceDirectory);
                    string line2;
                    while ((line2 = sr.ReadLine()) != null)
                    {
                        if (line2.Contains(searchWord))
                        {
                            Console.WriteLine("нашлось");
                        }
                        else
                        {
                            Console.WriteLine("не нашлось");
                        }
                    }
                }
                catch (Exception c)
                {
                    Console.WriteLine("такого пути или файла нет");
                }
            }
        }

    }
}
