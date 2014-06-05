using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CommunicationInterface
{
    [ServiceContract] // Говорим WCF что это интерфейс для запросов сервису
    public interface IMyObject
    {
        [OperationContract] // Делегируемый метод.                            -Тут изменять при изменениии
        bool newCarFromGrid(string name, string mark, int year, int price, string url, string region);

        [OperationContract] // Делегируемый метод.                            -Тут изменять при изменениии
        bool newCarFromUser(string name, string mark, int year, int price, string info, string region, string url_photo);
    }
}
