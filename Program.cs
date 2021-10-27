using System;
using System.Threading.Tasks;
using System.IO;

namespace ChkShtLst
{
    class Program
    {

        static Task Main(string[] args)
        {
            Console.WriteLine("Starting");
        
            bool foundWord = false;
            var errorMessage = new System.Text.StringBuilder();
            foreach (var arg in args)
            {
                foreach (var fileName in Directory.GetFiles("/inputfolder", "*", SearchOption.AllDirectories))
                {        
                    var fileContent = File.ReadAllText(fileName);
                    if (fileContent.Contains(arg) && 
                        !fileName.Contains("/.github/workflows/") && 
                        !fileName.Contains("/inputfolder/_temp/")
                        )
                    {
                        errorMessage.Append(arg);
                        errorMessage.Append(" found in ");
                        errorMessage.Append(fileName);
                        errorMessage.AppendLine();
                        foundWord = true;
                    }
                }
            }

            if (foundWord)
            {
                Console.Write(errorMessage);
            }
            Console.WriteLine("Finished");
            Environment.Exit(Convert.ToInt32(foundWord));
            return Task.CompletedTask;
        }
    }
}
