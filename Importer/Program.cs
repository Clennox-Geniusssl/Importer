using System.Collections.Generic;
using System;

namespace Importer
{
    class Importer
    {
        public static List<Option> options;
        public static void Main(string[] args)
        {
            options = new List<Option>
            {
                new Option("import payments from a file", () => FirstSelection()),
                new Option("import users from a file", () =>  SecondSelection()),
                new Option("Exit", () => Environment.Exit(0)),
            };
            

            int index = 0;

            WriteMenu(options, options[index]);

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
                Console.Clear();
                WriteMenu(options, options[index]);

            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();
        }
        static void FirstSelection()
        {
            PayUsers.Pay();
        }

        static void SecondSelection()
        {
            UsersInfo.Users();
        }
    
        static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.Clear();

            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
         
        }
        
    }

    public class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }  
    }
    }