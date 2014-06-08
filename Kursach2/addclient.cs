using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Media;
using System.Threading;

using System.Data.SqlClient;
using System.Data.Linq;
using System.ServiceModel;
using CommunicationInterface;
using MappingDLL;
namespace Kursach
{
    public partial class addclient : Form
    {
        public addclient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string full_name = textBox1.Text.ToString();
            string email = textBox2.Text.ToString();
            string passport = textBox3.Text.ToString();

            Uri tcpUri = new Uri("http://localhost:8080/");
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IMyObject> factory = new ChannelFactory<IMyObject>(binding, address);
            IMyObject service = factory.CreateChannel();

            bool answer = service.newClient(full_name, email, passport);
            if (answer)
            {
                MessageBox.Show("Успешно добавлено!");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
