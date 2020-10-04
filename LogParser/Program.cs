using System;
using System.IO;

namespace LogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к папке с логами или прямой путь к логу");
            string sourceDirectory = Console.ReadLine();

            Console.WriteLine("Введите слово или его часть для проверки совпадения строк в логе");
            string searchWord = Console.ReadLine();

           string logfilePath = @"D:\logloglog.txt"; // путь где будет создаваться файл со строками

            if (File.Exists(logfilePath))
            {
                File.Delete(logfilePath);
            }

            using (FileStream fs = File.Create(logfilePath))
            {

            }
            
            try
            {
                var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.log");
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
                            Console.WriteLine(line1);
                            File.AppendAllText(logfilePath,line1 + Environment.NewLine);
                        }
                       
                    }
                    sr.Close();
                }
            }
            catch (Exception)
            {
                try
                {

                    using StreamReader sr = new StreamReader(sourceDirectory);
                    string line2;
                    while ((line2 = sr.ReadLine()) != null)
                    {
                        if (line2.Contains(searchWord))
                        {
                            Console.WriteLine(line2);
                            File.AppendAllText(logfilePath, line2 + Environment.NewLine);
                        }
                       
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Такого пути или файла нет");
                }
            }
        }

    }
}
