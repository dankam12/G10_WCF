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

            WebServiceHost host = new WebServiceHost(typeof(Service1), new Uri("Localhost:8000/"));
            try
            {
                ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IService1), new WebHttpBinding(), "http://localhost:8000/Index");
                host.Description.Endpoints[0].Behaviors.Add(new WebHttpBehavior { HelpEnabled = true });
                host.Open();
                Console.WriteLine("Service: " + "http://localhost:8000/index" + " Started\n");
                Console.WriteLine("View available methods at " + "http://localhost:8000/index/help" + "\n");
                Console.WriteLine("<Press any key To Close Service>");
                Console.ReadLine();
                host.Close();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine("An exception occurred: {0}", cex.Message);
                host.Abort();
            }
        }
    }
}

