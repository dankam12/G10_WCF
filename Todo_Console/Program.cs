using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Todo_WebService;


namespace Todo_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            WebServiceHost Host = new WebServiceHost(typeof(Service1), new Uri("Localhost:8000/"));

            ServiceEndpoint ep = Host.AddServiceEndpoint(typeof(IService1), new WebHttpBinding(), "http://localhost:8000/Index");
            Host.Description.Endpoints[0].Behaviors.Add(new WebHttpBehavior { HelpEnabled = true });

            Host.Open();

            Console.WriteLine("Service: " + "http://localhost:8000/index"  +" Started\n"  );
            Console.WriteLine("View avaiable methods at " + "http://localhost:8000/index/help" +"\n");
            Console.WriteLine("<Press Enter To Close Service>");
            Console.ReadLine();
            Host.Close();




            }
        }
    }

