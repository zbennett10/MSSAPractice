using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            listOutputter();
        }

        public static void listOutputter()
        {
            List<int> unsortedNumbers = new List<int>
            {
                1,6,745,34,45,32,223,7,53,23,5,64,366,56
            };
            int temp = 0;


            for (int i = 0; i < unsortedNumbers.Count; i++)
            {
                for(int j = 0; j < unsortedNumbers.Count; j++)
                {
                    if(unsortedNumbers[i] < unsortedNumbers[j])
                    {
                        temp = unsortedNumbers[i];
                        unsortedNumbers[i] = unsortedNumbers[j];
                        unsortedNumbers[j] = temp;
                    }
                }
            }
            foreach (int num in unsortedNumbers)
            {
                Console.WriteLine(num);
               
            }
            Console.ReadLine();
        }


    }
}
