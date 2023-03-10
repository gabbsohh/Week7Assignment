using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Week7Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the full name and path of the text file: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            if (!IsTextFile(filePath))
            {
                Console.WriteLine("Invalid file format.");
                return;
            }

            try
            {
                string content = File.ReadAllText(filePath);
                int wordCount = CountWords(content);
                Console.WriteLine("The text file contains {0} words.", wordCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }

        static bool IsTextFile(string filePath)
        {
            Regex regex = new Regex(@"^.+\.(txt|TXT)$");
            return regex.IsMatch(filePath);
        }

        static int CountWords(string content)
        {
            content = content.Trim();
            int wordCount = 0;

            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] == ' ')
                {
                    wordCount++;
                }
            }

            return wordCount + 1;
        }
    }
}
