using System;
using System.IO;

namespace CMP1903M_2
{
    class Program
    {

        // This method is used whenever you need to view what files are in a directory.
        // It returns a string array of all of these options for future use.
        static string[] ShowDirectory()
        {
            string[] files = Directory.GetFiles("../");
            foreach (string item in files)
            {
                Console.WriteLine(item);
            }
            return files;

        }

        // This method reads through a text file, printing the contents.
        // In order to streamline the process, the print statement is removed, abstracting the method to the user.
        static string FileContents(string path)
        {
            string text = System.IO.File.ReadAllText(path);
            //Console.WriteLine(text);
            return text;
        }

        // The meat of the program, this allows the user to choose one of the files
        // from the list, before checking if the file is in that list and returning it if so.
        static string ChooseFile(string[] options)
        {
            Console.WriteLine("Please enter a file (can enter in full or just the suffix): ");
            string input = Console.ReadLine();
            foreach(string item in options)
            {
                // I have used .Contains to allow the user to simply input the unique part of the filename,
                // such as 1a or 1b - and still get the results they need.
                if (item.Contains(input))
                {
                    Console.WriteLine($"Found the file {item}.");
                    return item;
                }
            }

            // If the user types gibberish or an incorrect filename, then recurse and try again.
            Console.WriteLine("That file does not exist, I'm afraid.");
            return ChooseFile(options);
        }

        // Run ChooseFile, letting them choose from the array of files given in the directory method.
        // Do this twice, once for each file. 
        static void Main(string[] args)
        {
            string fileA = ChooseFile(ShowDirectory());
            string fileB = ChooseFile(ShowDirectory());

            // If the contents of each file are identical, then say so. Otherwise don't.
            if(FileContents(fileA) == FileContents(fileB))
            {
                Console.WriteLine("The two files are the same.");
            }
            else
            {
                Console.WriteLine("The two files are not the same.");
            }


        }
    }
}
