using System;
using System.Reflection;
using System.Text.RegularExpressions;
namespace wtf
{
    class Program
    {
        // Main function, execution entry point of the program  
        static void Main(string[] args) // string type parameters  
        {
            if (args.Length == 0) //check if user has entered text
            {
                Console.WriteLine("Please enter an acronym to decode");
                return;
            }
            else if (args.Length > 1) //check that the user has only entered a single word
            {
                Console.WriteLine("Please enter only one acronym at a time");
                return;
            }
            string input = args[0];
            input = Regex.Replace(input, "[^a-zA-Z]+", "", RegexOptions.Compiled);
            if (input.Length == 0) //if the string contained nothing but special characters
            {
                Console.WriteLine("Invalid input");
                return;
            }
            string str_current_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //get the location of the excecutable
            string str_path = str_current_path + @"\wth.txt"; //find the text file in the excecutable directory
            string message = FindInFile(input, str_path); //attempt to find the acronym
            Console.WriteLine(message); //print the output of FindInFile()

            string FindInFile(string str_search, string str_path)
            {
                string message = "";
                foreach (var line in File.ReadAllLines(str_path)) //read every entry in the acronym 'Database'
                {
                    if (!String.IsNullOrWhiteSpace(line)) //If its empty, ignore
                    {
                        int charLocation = line.IndexOf(".", StringComparison.OrdinalIgnoreCase); //Check for the first period in the line
                        if (charLocation > 0) //This confirms that it found a period
                        {
                            string acronym = line.Substring(0, charLocation); //get the text before the first dot
                            if (acronym.ToUpper() == str_search.ToUpper()) //compare the text with the search
                            {
                                string[] splitline = line.Split(". "); //if the acronym was located, process the text for output, beginning by splitting the line in twain
                                int counter = 0; //int-ernal counter to check when the end of the list is reached
                                bool skippedfirst = false;
                                foreach (string str in splitline)
                                {
                                    counter++; //this ordering makes it count from 1
                                    if (counter == 1)
                                    {
                                        if (message.Length > 0) //If lines were added beforehand
                                        {
                                            message = message + System.Environment.NewLine; //Add a newline
                                        }
                                        else
                                        {
                                            message = message + acronym + System.Environment.NewLine; //If empty, start with the acronym and a newline char
                                        }
                                        //ignore first entry.
                                        continue;
                                    }
                                    if (counter < splitline.Length) //if the end of the list has not yet been reached
                                    {
                                        message = message + str + System.Environment.NewLine; //add the line to the string which is to be returned, together with a newline character for proper formatting
                                    }
                                    else
                                    {
                                        message = message + str; //dont add a newline char to the last line
                                    }
                                }
                            }
                        }
                    }
                }
                if (message.Length == 0)
                {
                    return $"No matches found for {str_search}"; //incase this process found nothing, notify the user of our limitations
                }
                return message; //return the message as formatted by this function
            }
        }
    }
}