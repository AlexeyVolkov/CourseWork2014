using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Kursach
{
    class Search
    {
        public const int rows = 45; //----number of strings

        public string[][] cars = new string[rows][];
        public string[] links = new string[rows];
        public DateTime[] dates = new DateTime[rows];
        public DateTime oldestDate = new DateTime();

        public Search(int mark_id, int year1, int year2, int region)
        {
            string url = "http://cars.auto.ru/list/?mark_id=" + mark_id + "&year%5B1%5D=" + year1 + "&year%5B2%5D=" + year2 + "&region_id=" + region;
            
            HtmlWeb www = new HtmlWeb();
            HtmlDocument html = www.Load(url);

            try
            {
                HtmlNodeCollection node = html.DocumentNode.SelectNodes("//div[@id='cars_sale']/table");
                HtmlNodeCollection nodes = node[0].SelectNodes("tr");

                int i = 0;
                int j = 0;
                foreach (HtmlNode row in nodes)
                {
                    if (i < rows)
                    {
                        cars[i] = new string[10];
                        j = 0;
                        foreach (HtmlNode cell in row.SelectNodes("td"))
                        {
                            if (j < 10)
                                cars[i][j] = cell.InnerText;
                            j++;
                        }
                    }
                    i++;
                }

                //----------------------------------------------------------------------------------------
                //---------------------------LINKS--------------------------------------------------------
                //----------------------------------------------------------------------------------------

                HtmlNodeCollection nodeLink = html.DocumentNode.SelectNodes("//div[@id='cars_sale']/table");
                HtmlNodeCollection nodesLink = nodeLink[0].SelectNodes("tr");

                int q = 0;
                int w = 0;
                foreach (HtmlNode row in nodesLink)
                {
                    if (q < rows)
                    {
                        w = 0;
                        foreach (HtmlNode cell in row.SelectNodes("td/a"))
                        {
                            if (w == 0)
                                links[q] = cell.GetAttributeValue("href", "link");
                            w++;
                        }
                    }
                    q++;
                }

                //----------------------------------------------------------------------------------------
                //---------------------------DATES--------------------------------------------------------
                //----------------------------------------------------------------------------------------

                for (int y = 1; y < rows; y++)
                {
                    html = www.Load(links[y]);
                    HtmlNodeCollection nodeDates = html.DocumentNode.SelectNodes("//div[@class='c']/div/p[@class='c']");
                    HtmlNode nodesDates = nodeDates[0].SelectSingleNode("strong");

                    dates[y] = Convert.ToDateTime(nodesDates.InnerText);
                }
                
            }
            catch { /* search has given null result*/ };
        }
    }
}
