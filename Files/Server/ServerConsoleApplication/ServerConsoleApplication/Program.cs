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
        public System.Data.Linq.Table<Client> Clients
        {
            get { return this.GetTable<Client>(); }
        }
        public System.Data.Linq.Table<Order> Orders
        {
            get { return this.GetTable<Order>(); }

        }
    }
    public class MyObject : IMyObject
    {
        DB db = new DB(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Алексей\Documents\SourceTree\CourseWork2014\Files\Server\ServerConsoleApplication\ServerConsoleApplication\cars.mdf;Integrated Security=True;Connect Timeout=30");

        public bool newCarFromGrid(string name, string mark, int year, int price, string url, string region)
        {
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
        public bool newClient(string full_name, string email, string passport)
        {
            Client newClient = new Client();

            newClient.full_name = full_name;
            newClient.email = email;
            newClient.passport = passport;

            db.Clients.InsertOnSubmit(newClient);
            db.SubmitChanges();
            return true;
        }
        public bool newOrder(int FK_id_client, int FK_id_car, DateTime date ,int summ )
        {
            Order newOrder = new Order();

            newOrder.FK_id_client =FK_id_client;
            newOrder.FK_id_car = FK_id_car;
            newOrder.date = date;
            newOrder.summ = summ;

            db.Orders.InsertOnSubmit(newOrder);
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