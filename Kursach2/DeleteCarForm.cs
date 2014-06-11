using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.Linq;
using System.ServiceModel;
using CommunicationInterface;
using MappingDLL;

namespace Kursach
{
    public partial class DeleteCarForm : Form
    {
        public DeleteCarForm()
        {
            InitializeComponent();
        }

        private void DeleteCarForm_Load(object sender, EventArgs e)
        {
            Uri tcpUri = new Uri("http://localhost:8080/");
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IMyObject> factory = new ChannelFactory<IMyObject>(binding, address);
            IMyObject service = factory.CreateChannel();
            List<Car> litr = service.getCars();

            var bindinglist = new BindingList<Car>(litr);
            var source = new BindingSource(bindinglist, null);
            dataGridView1.DataSource = source;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Uri tcpUri = new Uri("http://localhost:8080/");
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IMyObject> factory = new ChannelFactory<IMyObject>(binding, address);
            IMyObject service = factory.CreateChannel();

            bool answer = service.deleteCar(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            if (answer)
            {
                MessageBox.Show("Успешно удалено!");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
