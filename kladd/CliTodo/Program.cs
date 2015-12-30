using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliTodo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                ShowHelp();
            }

            Arguments CommandLine = new Arguments(args);
            try
            {
                //GetTodo
                if (CommandLine["Get"] != null)
                {
                    int id = -1;
                    if ((CommandLine["Id"] != null))
                    {
                        int.TryParse(CommandLine["Id"], out id);
                    }
                    GetTodo(id);
                }
                //SetTodo
                if (CommandLine["Set"] != null)
                {
                    try
                    {
                        //Plus och minus och andra kluriga uräknignar
                    }
                    catch (Exception e)
                    {
                        //Ops det giock åt h-vete
                        throw new Exception("Bajs logic funkade inte... " + e.InnerException);
                    }

                    if ((CommandLine["Id"] != null))
                    {
                        int id;
                        int.TryParse(CommandLine["Id"], out id);

                        if ((CommandLine["desc"] != null))
                        {
                            string desc = CommandLine["desc"];
                            SetTodo(desc, id);
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException("Id is missing...");
                    }
                }
                //NewTodo
                if (CommandLine["New"] != null)
                {
                    throw new NotImplementedException("Skriv lite kod här...");
                }

                Console.WriteLine("\n\r\n\r\n\rRemove when done with debugging...\n\rPress any key to exit");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ops! {0}", e.ToString());
            }
        }
        

        static bool SetTodo(string description, int Id)
        {
            Console.WriteLine("About to update Todo {0} with {1}", Id.ToString(), description);
            try
            {
                //Using rest......
            }
            catch (Exception e)
            {
                Console.WriteLine("Ops! {0}", e.ToString());
                return false;
            }
            return true;
        }

        static void GetTodo(int Id=-1)
        {
            try
            {
                if (Id == -1)
                {
                    //Using get ALL
                    foreach (var todo in new string[] { "Stå ut","Jobba hårdare"})
                    {
                        Console.WriteLine(todo);
                    }
                }
                else
                {
                    //Using Get specific todo
                    Console.WriteLine("You got Id:{0}", Id.ToString());
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Ops! {0}", e.ToString());
            }
        }

        static void ShowHelp()
        {
            Console.WriteLine("\n{0} - Testclient for Todo RESTful methods.", AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("Copyright (C) 2015 Student Daniel");
            Console.WriteLine("Acme Inc.");
            Console.WriteLine("\n");
            Console.WriteLine("Usage: {0} [-Get|/Get] [-Id:n] Specifiy ID to get specific Todo otherwise all Todos are returned.", AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("Usage: {0} [-Set] [-Id:n] [-desc:] [-EndTime:]", AppDomain.CurrentDomain.FriendlyName);

            Environment.Exit(0);
        }
    }
}
