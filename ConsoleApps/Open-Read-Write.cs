using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace FileFetcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO TEXT SNATCHER YOOOOOOO!");
             
            while (true)
            {
                Console.WriteLine("Would you like to open a text file, \n add text to an existing file, \n or display the contents of a text file to the console? \n 'open', 'write', or 'read'?");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "open":
                        PerformOpenProcedures();
                        break;
                    case "write":
                        PerformWriteProcedures();
                        break;
                    case "read":
                        PerformReadProcedures();
                        break;
                }
            }

        }

        public static void PerformOpenProcedures()
        {
            Console.WriteLine("Please enter the path to the file you'd like to open.");
            string pathInput = Console.ReadLine();
            FileOpener(pathInput);
            Console.ReadLine();
        }

        public static void PerformWriteProcedures()
        {
            
            Console.WriteLine("Please enter the file path.");
            string writePathInput = Console.ReadLine();
            Console.WriteLine("Please enter the text you'd like to append.");
            string writeInput = Console.ReadLine();

            try
            {
                TextAppender(writePathInput, writeInput);
                FileOpener(writePathInput);
                Console.WriteLine("Operation Successful. File Opening...");
            }

            catch(UnauthorizedAccessException)
            {
                Console.WriteLine("Access Denied. You don't have administsrator privilege - write operations have been discontinued...");
                return;
            }
            
            Console.ReadLine();
        }

        public static void PerformReadProcedures()
        {
            Console.WriteLine("Please enter the file path.");
            string readPathInput = Console.ReadLine();
            DisplayText(readPathInput);
            Console.ReadLine();
        }

       public static void FileOpener(string path)
        {
            Process.Start(path);
        }

        public static void TextAppender(string path, string text)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(text);
            }
        }

        public static void DisplayText(string path)
        {
            using (StreamReader reader = File.OpenText(path))
            {
                string str = string.Empty;
                while((str = reader.ReadLine()) != null)
                {
                    Console.WriteLine(str);
                }
            }
            
        }

    }
}
