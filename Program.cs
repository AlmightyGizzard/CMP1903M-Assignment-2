using System;
using System.IO;

namespace CMP1903M_2
{
    class Program
    {

        static string[] ShowDirectory()
        {
            string[] files = Directory.GetFiles("../");
            foreach (string item in files)
            {
                Console.WriteLine(item);
            }
            return files;

        }

        static string FileContents(string path)
        {
            string text = System.IO.File.ReadAllText(path);
            //Console.WriteLine(text);
            return text;
        }

        static string ChooseFile(string[] options)
        {
            Console.WriteLine("Please enter a file: ");
            string input = Console.ReadLine();
            foreach(string item in options)
            {
                if (item.Contains(input))
                {
                    Console.WriteLine($"Found the file {item}.");
                    return item;
                }
            }
            Console.WriteLine("Not a file, soz");
            return ChooseFile(options);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string fileA = ChooseFile(ShowDirectory());
            string fileB = ChooseFile(ShowDirectory());

            if(FileContents(fileA) == FileContents(fileB))
            {
                Console.WriteLine("They are the samesies");
            }
            else
            {
                Console.WriteLine("No snap.");
            }


        }
    }
}
