using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Todo_WebService;
using Todo_Class;
namespace Todo_Client
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
                    GetTODo(id);
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
              //  Console.ReadLine();
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

        static void GetTodo(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    //Using get ALL
                    foreach (var todo in new string[] { "Stå ut", "Jobba hårdare" })
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


        
        static void GetTODo(int NR)
        {
            using (ChannelFactory<IService1> cf = new ChannelFactory<IService1>(new WebHttpBinding(), "http://localhost:8000/Index"))
            {
                cf.Endpoint.Behaviors.Add(new WebHttpBehavior());
                IService1 channel = cf.CreateChannel();
                
                if (NR == -1)
                {
                    List<ToDo> Poo = new List<ToDo>();
                    Poo = channel.GetToDoList();

                    foreach (ToDo p in Poo)
                    {
                        Console.WriteLine(p.Id);
                        Console.WriteLine(p.Description);
                        Console.WriteLine(p.Name);
                        Console.WriteLine(p.DeadLine);
                        Console.WriteLine(p.EstimationTime);

                    }

                }
                else
                {
                    String ID;
                    ID = Convert.ToString(NR);

                    ToDo Poo1;
                    Poo1 = channel.GetToDoById(ID);
                    Console.WriteLine(Poo1.Id);
                    Console.WriteLine(Poo1.Description);

                }
                

                

              


            }


                



            }

        static void GetToDoListByName(string Name)
        {
            using (ChannelFactory<IService1> cf = new ChannelFactory<IService1>(new WebHttpBinding(), "http://localhost:8000/Index"))
            {
                cf.Endpoint.Behaviors.Add(new WebHttpBehavior());
                IService1 channel = cf.CreateChannel();

                List<ToDo> GTodoByID = new List<ToDo>();
                Console.WriteLine("Vems Todos Vill du se ");
                String TName = Console.ReadLine();

                GTodoByID = channel.GetToDoListByName(TName);

                foreach (var g in GTodoByID)
                {
                    Console.WriteLine(g.Id);
                    Console.WriteLine(g.Description);
                    Console.WriteLine(g.Name);
                    Console.WriteLine(g.DeadLine);
                    Console.WriteLine(g.EstimationTime);
                }
                Console.ReadLine();


            }


        }
        static void AddTodo()
        {
            Console.WriteLine("Vem vill lägga till en Todo");
            string name = Console.ReadLine();
            Console.WriteLine("Description på din Todo");
            string desc = Console.ReadLine();
            DateTime dt = new DateTime();
            Console.WriteLine("Hur många timmar har du på dig att göra denna ToDo");

            int Deadline;
            string Dead = Console.ReadLine();
            while (!(int.TryParse(Dead, out Deadline)))
            {
                Console.WriteLine("du kan enbart ange siffror");
                Dead = Console.ReadLine();
            }

            Console.WriteLine("Hur lång tid tror du det ska ta ");
            int EstTime;
            string Est = Console.ReadLine();
            while (!(int.TryParse(Est, out EstTime)))
            {
                Console.WriteLine("du kan enbart ange siffror");
                Est = Console.ReadLine();

            }
            dt = DateTime.Now;
            ToDo addTodo = new ToDo()
            {
                Description = desc,
                Name = name,
                CreatedDate = dt,
                DeadLine = dt.AddHours(Deadline),
                Finnished = false,
                EstimationTime = EstTime
            };

            using (ChannelFactory<IService1> cf = new ChannelFactory<IService1>(new WebHttpBinding(), "http://localhost:8000/Index"))
            {
                cf.Endpoint.Behaviors.Add(new WebHttpBehavior());
                IService1 channel = cf.CreateChannel();
                channel.AddTodo(addTodo);


            }


        }
        static void UpdateTodo()
        {

            Console.WriteLine("Vilken Todo vill du ändra på, Välj ID");
           
            int Choice;
            string Length = Console.ReadLine();
            while (!(int.TryParse(Length, out Choice)))
            {
                Console.WriteLine("du kan enbart ange siffror mellan 1-9  ");
                Length = Console.ReadLine();
            }
            string PSwitch = null;
            do
            {
                Console.WriteLine("Ange vilken uppgift du vill se 1 2 3 4. Skriv 5 för att avsluta: ");


                PSwitch = Console.ReadLine();
                Console.WriteLine("Vad vill du ändra");
                Console.WriteLine("1. Description, 2. DeadLine, 3. Estimation Time, 4.Finish ");


                switch (PSwitch)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":


                        break;
                    case "4":


                        break;
                    case "5":

                        break;
                }
            }
            while (PSwitch != "5");

        }
    }
 






       




    }


       


 


    



#region Alla funktioner

//Allt detta skall skapas i egen klass sen, med en ServiceReference
//            using (ChannelFactory<IService1> cf = new ChannelFactory<IService1>(new WebHttpBinding(), "http://localhost:8000/Index"))
//            {
//                cf.Endpoint.Behaviors.Add(new WebHttpBehavior());
//                #region GetToDo
//                IService1 channel = cf.CreateChannel();
//List<ToDo> Poo = new List<ToDo>();
//Poo = channel.GetToDoList();

//                foreach (ToDo p in Poo)
//                {
//                    Console.WriteLine(p.Id);
//                    Console.WriteLine(p.Description);
//                    Console.WriteLine(p.Name);
//                    Console.WriteLine(p.DeadLine);
//                    Console.WriteLine(p.EstimationTime);

//                }
//                #endregion 

//                #region GetToDoByID
//                Console.WriteLine("Välj vilken Todo Du vill se");
//                int input;
//string Length = Console.ReadLine();
//                while (!(int.TryParse(Length, out input)))
//                {
//                    Console.WriteLine("du kan enbart ange siffror mellan 1-9  ");
//                    Length = Console.ReadLine();

//                }


//                ToDo Poo1;
//Poo1 = channel.GetToDoById(input);
//                Console.WriteLine(Poo1.Id);
//                Console.WriteLine(Poo1.Description);

//                Console.ReadLine();
//                #endregion

//                #region GetToByName

//                List<ToDo> GTodoByID = new List<ToDo>();
//Console.WriteLine("Vems Todos Vill du se ");
//                String TName = Console.ReadLine();

//GTodoByID = channel.GetToDoListByName(TName);

//                foreach (var g in GTodoByID)
//                {
//                    Console.WriteLine(g.Id);
//                    Console.WriteLine(g.Description);
//                    Console.WriteLine(g.Name);
//                    Console.WriteLine(g.DeadLine);
//                    Console.WriteLine(g.EstimationTime);
//                }
//                Console.ReadLine();


//                #endregion



//            }

#endregion