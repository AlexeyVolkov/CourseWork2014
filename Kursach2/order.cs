using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Media;
using System.Threading;
using MySql.Data.MySqlClient;

using System.Data.SqlClient;
using System.Data.Linq;
using System.ServiceModel;
using CommunicationInterface;
using MappingDLL;

using System.Net;
using System.Net.Mail;

using iTextSharp.text;
using iTextSharp;
using System.IO;
using System.Diagnostics;
using iTextSharp.text.pdf;
using AODL.Document.Styles;
using AODL.Document.Content.Text;
using AODL.Document.Content.Tables;
using AODL.Document.SpreadsheetDocuments;
using AODL.Document.TextDocuments;


namespace Kursach
{
    public partial class order : Form
    {
        public order()
        {
            InitializeComponent();
        }
        List<int> ids = new List<int>();
        List<int> ids2 = new List<int>(); 
        private void order_Load(object sender, EventArgs e)
        {
            ids2.Clear();
            ids.Clear();

            Uri tcpUri = new Uri("http://localhost:8080/");
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IMyObject> factory = new ChannelFactory<IMyObject>(binding, address);
            IMyObject service = factory.CreateChannel();
            List<Client> litr = service.getClients();
            /*dataGridView1.RowCount = litr.Count;
            for (int i = 0; i< litr.Count; i++)
            {
                dataGridView1[0,0].Value = litr[i].Id;
            }*/
            var bindinglist = new BindingList<Client>(litr);
            var source = new BindingSource(bindinglist, null);
            foreach (var a in litr)
            {
                comboBox1.Items.Add(a.full_name);
            }
            List<Car> litr2 = service.getCars();
            /*dataGridView1.RowCount = litr.Count;
            for (int i = 0; i< litr.Count; i++)
            {
                dataGridView1[0,0].Value = litr[i].Id;
            }*/
            var bindinglist2 = new BindingList<Car>(litr2);
            var source2 = new BindingSource(bindinglist2, null);
            foreach (var a in litr2)
            {
                comboBox2.Items.Add(a.name);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var doc = new Document();
                string path = @"C:\DKP.pdf";
                FileStream f = new FileStream(path, FileMode.Create);
                PdfWriter.GetInstance(doc, f);
                doc.Open();

                BaseFont TimesNewBold = BaseFont.CreateFont(@"C:\Windows\Fonts\timesbd.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                BaseFont TimesNewNormal = BaseFont.CreateFont(@"C:\Windows\Fonts\times.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                BaseFont CourierBoldItalic = BaseFont.CreateFont(@"C:\Windows\Fonts\courbi.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                iTextSharp.text.Font TimesNewBlack18 = new iTextSharp.text.Font(TimesNewBold, 18, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font CourierRed14 = new iTextSharp.text.Font(CourierBoldItalic, 14, iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.RED);
                iTextSharp.text.Font TimesNewBlack11 = new iTextSharp.text.Font(TimesNewNormal, 11, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

                iTextSharp.text.Paragraph Title = new iTextSharp.text.Paragraph();
                Title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

                Title.Add(new Phrase("Договор купли - продажи" + Environment.NewLine, TimesNewBlack18));

                iTextSharp.text.Paragraph Task = new iTextSharp.text.Paragraph(""+dateTimePicker1.Value.ToString()+"" + Environment.NewLine, TimesNewBlack11);
                      

iTextSharp.text.Paragraph Task1 = new iTextSharp.text.Paragraph("Мы, OOO “Volkov ‘n’ Kozlov” , именуемое в дальнейшем Продавец, и" + Environment.NewLine, TimesNewBlack11);
iTextSharp.text.Paragraph Task2 = new iTextSharp.text.Paragraph("гр." + comboBox1.Text + ", " + Environment.NewLine, TimesNewBlack11);
iTextSharp.text.Paragraph Task3 = new iTextSharp.text.Paragraph("Удостоверение личности: паспорт серии/№ , именуемый(ая) в дальнейшем Покупатель, " + Environment.NewLine, TimesNewBlack11);

iTextSharp.text.Paragraph Task4 = new iTextSharp.text.Paragraph("заключили настоящий Договор о нижеследующем:" + Environment.NewLine, TimesNewBlack11);

iTextSharp.text.Paragraph Task5 = new iTextSharp.text.Paragraph("1. Продавец передает в собственность Покупателя (продает), а Покупатель принимает (покупает) и оплачивает транспортное средство:" + Environment.NewLine, TimesNewBlack11);

iTextSharp.text.Paragraph Task6 = new iTextSharp.text.Paragraph("Марка, модель ТС: ___________________________________________________________________________________________" + Environment.NewLine, TimesNewBlack11);
iTextSharp.text.Paragraph Task7 = new iTextSharp.text.Paragraph("Год выпуска: _______________________________________________________________________________________________" + Environment.NewLine, TimesNewBlack11);


iTextSharp.text.Paragraph Task89 = new iTextSharp.text.Paragraph("3. Со слов Продавца на момент заключения настоящего Договора отчуждаемое транспортное средство никому не продано, не заложено, в споре и под запрещением (арестом) не состоит, а также не является предметом претензий третьих лиц." + Environment.NewLine, TimesNewBlack11);

iTextSharp.text.Paragraph Task9 = new iTextSharp.text.Paragraph("4. Стоимость указанного в п. 1 транспортного средства согласована Покупателем и Продавцом и составляет: _______________________________________________________________________________________________ руб. ____ коп." + Environment.NewLine, TimesNewBlack11);

iTextSharp.text.Paragraph Task8 = new iTextSharp.text.Paragraph("4. Покупатель в оплату за приобретенное транспортное средство передал Продавцу, а Продавец получил денежные средства в размере ______________________________________________________________________________________ руб. ____ коп." + Environment.NewLine, TimesNewBlack11);

iTextSharp.text.Paragraph Task12 = new iTextSharp.text.Paragraph("5. Право собственности на транспортное средство, указанное в п. 1 договора переходит к Покупателю с момента подписания настоящего договора." + Environment.NewLine, TimesNewBlack11);

iTextSharp.text.Paragraph Task13 = new iTextSharp.text.Paragraph("6. Настоящий договор составлен в трех экземплярах, имеющих одинаковую юридическую силу. Один экземпляр настоящего Договора для передачи в регистрационное подразделение ГИБДД, и по одному экземпляру Договора получены Продавцом и Покупателем. " + Environment.NewLine, TimesNewBlack11);


iTextSharp.text.Paragraph Task14 = new iTextSharp.text.Paragraph("___________________________						_____________________________" + Environment.NewLine, TimesNewBlack11);


iTextSharp.text.Paragraph Task15 = new iTextSharp.text.Paragraph("___________________________						_____________________________" + Environment.NewLine, TimesNewBlack11);
iTextSharp.text.Paragraph Task16 = new iTextSharp.text.Paragraph("(подпись, фамилия продавца)						(подпись, фамилия покупателя)" + Environment.NewLine, TimesNewBlack11);
                Task.Alignment = Element.ALIGN_JUSTIFIED;


                iTextSharp.text.Paragraph Footer = new iTextSharp.text.Paragraph(new Phrase("Козлов А.М." + Environment.NewLine, TimesNewBlack11));
                Footer.Alignment = Element.ALIGN_RIGHT;
                Footer.SpacingBefore = 50;

                doc.Add(Title);
                doc.Add(Task);
                doc.Add(Task1);
                doc.Add(Task2);
                doc.Add(Task3);
                doc.Add(Task4);
                doc.Add(Task5);
                doc.Add(Task6);
                doc.Add(Task7);
                doc.Add(Task89);
                doc.Add(Task9);
                doc.Add(Task8);
                doc.Add(Task12);
                doc.Add(Task13);
                doc.Add(Task14);
                doc.Add(Task15);
                doc.Add(Task16);

                doc.Add(Footer);
                doc.Close();
                Process.Start(path);
                MessageBox.Show("PDF файл успешно создан!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int FK_id_client = 4;
            int FK_id_car = 2;
            string dat = dateTimePicker1.Value.ToString();
            
            int summ = 0;
            Uri tcpUri = new Uri("http://localhost:8080/");
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IMyObject> factory = new ChannelFactory<IMyObject>(binding, address);
            IMyObject service = factory.CreateChannel();

            bool answer = service.newOrder(FK_id_client, FK_id_car, dat, summ );
            if (answer)
            {
                MessageBox.Show("Успешно добавлено!");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        
        }
        public static void SendMail(string smtpServer, string from, string password, string mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
                MessageBox.Show("Письмо успешно отправлено!");
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //Чтобы с фалом отправить в конец въебашь просто строчку с адресом к файлу.
            SendMail("smtp.gmail.com", "oopw14@gmail.com", "oooopppp", "oopw14@gmail.com", "Договор №52", "В связи с расширением..");
        }
    }
}
