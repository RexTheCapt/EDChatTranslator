using System.Diagnostics;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EdJournalArrayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string journalPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\Saved Games\\Frontier Developments\\Elite Dangerous";
            string[] journals = Directory.GetFiles(journalPath, "Journal.*.log").OrderBy(x=>(new FileInfo(x)).LastWriteTime).ToArray();

            JArray a = new();

            foreach (string journal in journals)
                foreach (string line in File.ReadAllLines(journal))
                    a.Add((JObject)JsonConvert.DeserializeObject(line));

            string raw = a.ToString();

            using (StreamWriter sw = new("output.json"))
                sw.WriteLine(raw);

            Console.WriteLine(Path.GetFullPath("output.json"));
        }
    }
}