using System;
using System.Threading.Tasks;
using System.IO;

namespace ChkShtLst
{
    class Program
    {

        static Task Main(string[] args)
        {
            Console.WriteLine("Starting, looking for:");
            foreach (var arg in args)
	        {
                Console.WriteLine(arg);
	        }
            bool foundWord = false;
            var runningDirName = Directory.GetCurrentDirectory();
            var errorMessage = new System.Text.StringBuilder();
            foreach (var arg in args)
            {
                foreach (var fileName in Directory.GetFiles(runningDirName, "*", SearchOption.AllDirectories))
                {
                    var fileContent = File.ReadAllText(fileName);

                    if (fileContent.Contains(arg))
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
            Environment.Exit(Convert.ToInt32(foundWord));
            Console.WriteLine("Finished");
            return Task.CompletedTask;
        }
    }
}
