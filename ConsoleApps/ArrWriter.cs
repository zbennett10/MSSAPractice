using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace arrWriter
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter values for Array One. Do not include spaces.");
            arrayOne = ArrayFetcher();
            Console.WriteLine("Please enter values for Array Two. Do not include spaces.");
            arrayTwo = ArrayFetcher();

            Console.WriteLine("Array One: {0} \nArray Two: {1}", new String(arrayOne), new String(arrayTwo));
            Console.WriteLine("Press Enter to combine values.");
            Console.ReadLine();
            ArrayCombiner(arrayOne, arrayTwo);
            
            Console.WriteLine("Press Enter to write array to text document.");
            Console.ReadLine();
            Console.WriteLine("Please enter the path of your new text document.");
            string path = Console.ReadLine();
            DocCreator(path, outputText);
        }

        public static char[] arrayOne { get; set; }
        public static char[] arrayTwo { get; set; }
        public static string outputText {get;set;}

        public static char[] ArrayFetcher()
        {
            List<char> chars = new List<char>();
            while (true)
            {
                ConsoleKeyInfo currentKey = Console.ReadKey();
                if (currentKey.Key != ConsoleKey.Enter) chars.Add(currentKey.KeyChar);
                else break;
            }
            return chars.ToArray();
        }

        public static void ArrayCombiner(char[] arrOne, char[] arrTwo)
        {
            List<char> listOne = arrOne.ToList();
            List<char> listTwo = arrTwo.ToList();

            foreach(var item in listTwo)
            {
                listOne.Add(item);
            }
            arrayOne.ToList().Clear();
            arrayOne = listOne.ToArray();
            outputText = new string(arrayOne);
            Console.WriteLine(outputText);
        }

        public static void DocCreator(string path, string input)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.Write(input);
            }
            Thread.Sleep(500);
            Process.Start(path);
        }
    }
}
