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

            Host.Open();
           
                
                Console.WriteLine("Service: " + "http://localhost:8000"  +" Started"  );
                Console.WriteLine("<Press Enter To Close Service>");
                Console.ReadLine();
                Host.Close();




            }
        }
    }

