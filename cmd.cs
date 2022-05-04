using System;
using System.Collections.Generic;

namespace OSPROJECT
{
    class Program
    {
        public static Dictionary<String, String> commands = new Dictionary<String, String>
        {   {"cd", "Change the current default directory to.If the argument is not present, report the current directory.If the directory does not exist an appropriate error should be reported."},
            {"cls","Clear the screen." },
            {"dir","List the contents of directory ." },
            {"help","Display the user manual using the more filter. Provides Help information for commands." },
            {"quit","Quit the shell." },
            {"copy","Copies one or more files to another location" },
            {"del","Deletes one or more files." },
            {"mkdir","Creates a directory." },
            {"rmdir","Removes a directory." },
            {"rename","Renames a file." },
            {"type","Displays the contents of a text file." },
            {"import", "import text file(s) from your computer" },
            {"export","export text file(s) to your computer" }
        };

        public static void help(string command, int commandsNumber)
        {

            bool found = false;
            if (commandsNumber == 1)
            {
                foreach (var it in commands)
                    Console.WriteLine(it.Key + ":  " + it.Value);
                found = true;
            }
            else if (commandsNumber == 2)
            {
                foreach (var it in commands)
                {
                    if (command == it.Key)
                    {
                        Console.WriteLine(it.Key + ":    " + it.Value);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Command is not detected");
                }
            }
        }
        public static string changeDirectory(string newDirectory)
        {
             newDirectory = Console.ReadLine();
             return newDirectory;            
        }       
            
        static void Main(string[] args)
        {
            String currentDirectory = "C";
            while (true)
            {
                String command="",input,firstCommand = "", secondCommand = "", newDirectory = "",temp=""; 
                int commandsNumber = 0;                
                Console.Write(currentDirectory + ":> ");
                input = Console.ReadLine().ToLower();

                for (int i = 0;i < input.Length;i++) ///if it begins with spaces;
                {
                    bool flag = false;
                    if (input[i] != ' ')
                    {
                        flag = true;
                        for (int j = i; j < input.Length; j++) 
                        {
                            temp += input[j];
                        }
                    }
                    if (flag)
                        break;
                }
                input = temp;
                int letter = 0,counter=0;
                while (letter < input.Length)
                {
                    if (input[letter] != ' ' ) {
                        firstCommand += input[letter];
                    }
                    if (commandsNumber == 0)
                    {
                        command += firstCommand;
                        firstCommand = "";
                    }
                    if (commandsNumber == 1)
                    {
                        secondCommand += firstCommand;
                        firstCommand = "";
                    }
                    if (input[letter] == ' ')
                    {
                        commandsNumber++;
                        while (letter+ counter < input.Length && input[letter+ counter] == ' ')
                        {
                                counter++;
                        }
                    }
                    if (letter == input.Length - 1 && input[letter] != ' ')
                    {
                        commandsNumber++;
                    }
                    bool ok = false;
                    if (counter > 0)
                    {
                        letter += counter;
                        counter = 0;
                        ok = true;
                    }
                    if (ok==false)
                        letter++;
                    
                }
                if (commandsNumber == 2)
                {
                    help(secondCommand, 2);
                }
                else if (commandsNumber == 1)
                {
                    if (command == "help")
                    {
                            help(command, 1);                     
                    }
                    else if (command == "cls")
                    {
                        Console.Clear();
                    }
                    else if (command == "quit")
                    {
                        return;
                    }
                    else if (command == "cd")
                    {
                        currentDirectory = changeDirectory(newDirectory);
                    }
                    else if (command == "type")
                    {
                        Console.WriteLine("Didn't implemented yet.");
                    }
                    else if (command == "copy")
                    {
                        Console.WriteLine("Didn't implemented yet.");
                    }
                    else if (command == "del")
                    {
                        Console.WriteLine("Didn't implemented yet.");
                    }
                    else if (command == "rename")
                    {
                        Console.WriteLine("Didn't implemented yet.");
                    }
                    else if (command == "rmdir")
                    {
                        Console.WriteLine("Didn't implemented yet.");
                    }
                    else if (command == "dir")
                    {
                        Console.WriteLine("Didn't implemented yet.");
                    }
                    else if (command == "mkdir")
                    {
                        Console.WriteLine("Didn't implemented yet.");
                    }
                    else if (command == "import")
                    {
                        Console.WriteLine("Didn't implemented yet.");
                    }
                    else if (command == "export")
                    {
                        Console.WriteLine("Didn't implemented yet.");
                    }
                    else
                    {
                        Console.WriteLine("Command is not detected");
                    }
                }
                else
                {
                    Console.WriteLine("Command is not detected");
                }
            }                  
        }
    }
}
