using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using ExcelGenerator;
using ExcelGenerator.SpreadSheet;

namespace Kursach
{
    class Excel
    {
        public bool save(string[][] table, string path, string name = "Отчёт парсинга auto.ru")
        {
            try
            {
                Workbook workbook = new Workbook();
                Worksheet worksheet = new Worksheet(name);
                for (int i = 0; i < table.Length; i++)
                {
                    Row row = new Row();
                    for(int j = 0; j < table[i].Length; j++)
                        row.Cells.Add(new Cell(table[i][j]));

                    worksheet.Rows.Add(row);
                }

                workbook.Worksheets.Add(worksheet);
                workbook.save(path);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
