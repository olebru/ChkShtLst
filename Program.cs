using System;
using System.Threading.Tasks;
using System.IO;

namespace ChkShtLst
{
    class Program
    {

        static Task Main(string[] args)
        {
            args = new string[2];
            args[0] = "net";
            args[1] = "mic";


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
                    Console.WriteLine(fileName);
                }
            }



            if (foundWord)
            {
                Console.Write(errorMessage);


            }

            Console.ReadLine();
            return Task.CompletedTask;
        }
    }
}