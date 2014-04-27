﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Kursach
{
    class Search
    {
        public List<string[]> carsList = new List<string[]>();
        public List<string> linksList = new List<string>();
        public List<DateTime> datesList = new List<DateTime>();
        public DateTime oldestDate = new DateTime();
        public bool Enabled = false;

        public Search(int mark_id, int year1, int year2, int region)
        {
            /*liksList.Add(new string[] { "man", "damn" });
            string l = liksList[0][1];*/

            string url = "http://cars.auto.ru/list/?mark_id=" + mark_id + "&year%5B1%5D=" + year1 + "&year%5B2%5D=" + year2 + "&region_id=" + region;
            
            HtmlWeb www = new HtmlWeb();
            HtmlDocument html = www.Load(url);

            try
            {
                bool first = true; //needed
                HtmlNodeCollection node = html.DocumentNode.SelectNodes("//div[@id='cars_sale']/table");
                HtmlNodeCollection nodes = node[0].SelectNodes("tr");

                int j = 0;
                string[] temp_arr = new string[10];

                foreach (HtmlNode row in nodes)
                {
                    j = 0;
                    foreach (HtmlNode cell in row.SelectNodes("td"))
                    {
                        if (j < 10 && cell.InnerText != "")
                            temp_arr[j] = cell.InnerText;
                        j++;
                    }
                    if(!first)
                        carsList.Add(new string[] { temp_arr[0], temp_arr[1], temp_arr[2], temp_arr[9] });
                    first = false;
                }

                //----------------------------------------------------------------------------------------
                //---------------------------LINKS--------------------------------------------------------
                //----------------------------------------------------------------------------------------
                
                HtmlNodeCollection nodeLink = html.DocumentNode.SelectNodes("//div[@id='cars_sale']/table");
                HtmlNodeCollection nodesLink = nodeLink[0].SelectNodes("tr");

                first = true;
                bool first_td = true;
                foreach (HtmlNode row in nodesLink)
                {
                    if (!first)
                    {
                        first_td = true;
                        foreach (HtmlNode cell in row.SelectNodes("td/a"))
                        {
                            if (first_td)
                                linksList.Add(cell.GetAttributeValue("href", "link"));
                            first_td = false;
                        }
                    }
                    first = false;
                }

                //----------------------------------------------------------------------------------------
                //---------------------------DATES--------------------------------------------------------
                //----------------------------------------------------------------------------------------

                foreach (string link in linksList)
                {
                    html = www.Load(link);
                    HtmlNodeCollection nodeDates = html.DocumentNode.SelectNodes("//div[@class='c']/div/p[@class='c']");
                    HtmlNode nodesDates = nodeDates[0].SelectSingleNode("strong");

                    datesList.Add(Convert.ToDateTime(nodesDates.InnerText));
                }
                Enabled = true;
            }
            catch { /* search has given null result*/ };
        }
    }
}