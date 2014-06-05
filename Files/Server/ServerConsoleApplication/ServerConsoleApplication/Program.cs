using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using CommunicationInterface;
using System.Data.SqlClient;
using System.Data.Linq;
using MappingDLL;

namespace CommunicationInterface
{
    public class DB : DataContext
    {
        public DB(string cs)
            : base(cs)
        {
        }

        public System.Data.Linq.Table<Car> Cars
        {
            get { return this.GetTable<Car>(); }

        }
    }
    public class MyObject : IMyObject
    {
        public bool newCarFromGrid(string name, string mark, int year, int price, string url, string region)
        {
            DB db = new DB(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Алексей\Documents\SourceTree\CourseWork2014\Files\Server\ServerConsoleApplication\ServerConsoleApplication\cars.mdf;Integrated Security=True;Connect Timeout=30");
            
            Car newCar = new Car();

            newCar.name = name;
            newCar.mark = mark;
            newCar.year = year;
            newCar.price = price;
            newCar.url = url;
            newCar.region = region;

            db.Cars.InsertOnSubmit(newCar);
            db.SubmitChanges();
            return true;
        }
        public bool newCarFromUser(string name, string mark, int year, int price, string info, string region, string url_photo)
        {
            DB db = new DB(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Алексей\Documents\SourceTree\CourseWork2014\Files\Server\ServerConsoleApplication\ServerConsoleApplication\cars.mdf;Integrated Security=True;Connect Timeout=30");

            Car newCar = new Car();

            newCar.name = name;
            newCar.mark = mark;
            newCar.year = year;
            newCar.price = price;
            newCar.info = info;
            newCar.region = region;
            newCar.url_photo = url_photo;

            db.Cars.InsertOnSubmit(newCar);
            db.SubmitChanges();
            return true;
        }
    }
}

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(MyObject), new Uri("http://localhost:8080/"));
            host.AddServiceEndpoint(typeof(IMyObject), new BasicHttpBinding(), "");
            host.Open();
            Console.WriteLine("Сервер запущен");
            Console.ReadLine();

            host.Close();
        }
    }
}