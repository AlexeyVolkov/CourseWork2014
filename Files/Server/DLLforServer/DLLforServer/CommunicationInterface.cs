using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using MappingDLL;

namespace CommunicationInterface
{
    [ServiceContract] // Говорим WCF что это интерфейс для запросов сервису
    public interface IMyObject
    {
        [OperationContract] // Делегируемый метод.                       
        bool newCarFromGrid(string name, string mark, int year, int price, string url, string region);

        [OperationContract] // Делегируемый метод.                          
        bool newCarFromUser(string name, string mark, int year, int price, string info, string region, string url_photo);
        [OperationContract] // Делегируемый метод.                          
        bool newClient(string full_name, string email, string passport);
        [OperationContract] // Делегируемый метод.                         
        bool newOrder(int FK_id_client, int FK_id_car, DateTime data, int summ);
        [OperationContract] // Делегируемый метод. 
        List<Client> getClients();
        [OperationContract] // Делегируемый метод. 
        List<Car> getCars();
        [OperationContract] // Делегируемый метод. 
        bool deleteClient(int id);
    }
}
