using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    public partial class business : Form
    {
        public business()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

                Title.Add(new Phrase("Отчет за период "+dateTimePicker1.Value +" по "+ dateTimePicker2.Value+"" + Environment.NewLine, TimesNewBlack18));

                iTextSharp.text.Paragraph Task = new iTextSharp.text.Paragraph(""+dateTimePicker1.Value.ToString()+"" + Environment.NewLine, TimesNewBlack11);
                Task.Alignment = Element.ALIGN_JUSTIFIED;


                doc.Add(Title);
                doc.Close();
                Process.Start(path);
                MessageBox.Show("PDF файл успешно создан!");
            }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


        }
    }
}
