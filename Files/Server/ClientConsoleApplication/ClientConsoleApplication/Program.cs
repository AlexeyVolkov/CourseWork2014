using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace Client
{
    [ServiceContract]
    public interface IMyObject
    {
        [OperationContract]
        string GetCommandString(int i);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Uri tcpUri = new Uri("http://localhost:8080/");
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IMyObject> factory = new ChannelFactory<IMyObject>(binding, address);
            IMyObject service = factory.CreateChannel();

            Console.WriteLine("Вызываю метод сервиса...?");
            Console.WriteLine(service.GetCommandString(1));
            Console.WriteLine(service.GetCommandString(2));
            Console.WriteLine(service.GetCommandString(20));
            Console.WriteLine(service.GetCommandString(1562492));
            Console.WriteLine(service.GetCommandString(0));
            Console.ReadLine();
        }
    }
}