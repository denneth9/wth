using System;
using System.Reflection;
namespace wtf
{
    class Program
    {
        // Main function, execution entry point of the program  
        static void Main(string[] args) // string type parameters  
        {
            // Command line arguments  
            /*//Console.WriteLine("Argument length: " + args.Length);
            //Console.WriteLine("Supplied Arguments are:");
            foreach (Object obj in args)
            {
                //Console.WriteLine(obj);
            }*/
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter an acronym to decode");
                return;
            }
            else if (args.Length > 1)
            {
                Console.WriteLine("Please enter only one acronym at a time");
                return;
            }
            //string input = Console.ReadLine();
            string str_current_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string str_path = str_current_path + @"\wth.txt";
            string message = FindInFile(args[0], str_path);
            Console.WriteLine(message);


            string FindInFile(string str_search, string str_path)
            {
                string message = "";
                foreach (var line in File.ReadAllLines(str_path))
                {
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        int charLocation = line.IndexOf(".", StringComparison.OrdinalIgnoreCase);
                        //if (line.IndexOf(str_search, StringComparison.OrdinalIgnoreCase) == 0)
                        if (charLocation > 0)
                        {
                            string acronym = line.Substring(0, charLocation);
                            if (acronym.ToUpper() == str_search.ToUpper())
                            {
                                string[] splitline = line.Split(". ");
                                foreach (string str in splitline)
                                {
                                    message = message + str + System.Environment.NewLine;
                                }
                                return message;
                            }
                            //Console.WriteLine("Found one");


                        }

                    }

                }
                return "No matches found";
            }
        }
    }
}