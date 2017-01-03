using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace J_Merge
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter path to first json file.");
            string json1 = Console.ReadLine();
            Console.WriteLine("Enter path to second json file.");
            string json2 = Console.ReadLine();

            string mergedJson = Merge_Json();
            File.WriteAllText(@"C:\newJson.txt", mergedJson);
            

        }

        public static string Merge_Json()
        {

            //take 2 json files
            //read both files to stream
            StringBuilder jsonText = new StringBuilder();
           
            using (StreamReader reader = new StreamReader(@"C:\Users\benne\OneDrive\Documents\Visual Studio 2015\Projects\J-Merge\J-Merge\workout.json"))
            {
                //write to new file
                jsonText.Append(reader.ReadToEnd() + "\n");
            }

            using (StreamReader reader = new StreamReader(@"C:\Users\benne\OneDrive\Documents\Visual Studio 2015\Projects\J-Merge\J-Merge\workoutTitles.json"))
            {
                //write to new file
                jsonText.Append(reader.ReadToEnd() + "\n");
            }
            
            return jsonText.ToString();
        }

       
        //workout json structure

       
        public class RootObject
        {
            
            public string workout { get; set; }
            public string title { get; set; }
        }

    }
}
