using System;
using System.IO;

namespace LogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory = "";
            Console.WriteLine("Введите путь к папке");
           sourceDirectory = Console.ReadLine();
            try
           {
                var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt");
                foreach (string currentFile in txtFiles)
                {
                    string fileName = currentFile.Substring(sourceDirectory.Length + 1);
                    Console.WriteLine(fileName);
                StreamReader sr = new StreamReader(currentFile);

                string s;

                while (sr.EndOfStream != true)
                {
                    s = sr.ReadLine();
                    Console.WriteLine(s);
                }
                sr.Close();       
            }
          }
            catch (Exception e)
            {
                try
                {
                    using StreamReader sr = new StreamReader(sourceDirectory);
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                      Console.WriteLine(line);
                  }
               }
               catch(Exception c)
              {
                    Console.WriteLine("такого пути или файла нет");
                }
          }
          }
        
        }
    }

