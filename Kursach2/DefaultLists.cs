using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Kursach
{
    class DefaultLists
    {
        const string url = "http://all.auto.ru/extsearch/";
        const string error = "-73";

        HtmlWeb www = new HtmlWeb();
        HtmlDocument html = new HtmlDocument();

        public DefaultLists()//--------Constructor
        {
            html = www.Load(url);
        }

        public Dictionary<string,string> brand()//-----------Brands
        {
            Dictionary<string, string> brandList = new Dictionary<string,string>();

            HtmlNodeCollection node = html.DocumentNode.SelectNodes("//select[@name='mark_id']");
            HtmlNodeCollection nodes = node[0].SelectNodes("option");

            foreach (HtmlNode i in nodes)
            {
                brandList.Add(i.NextSibling.InnerText, i.GetAttributeValue("value", error));
            }

            return brandList;
        }

        public Dictionary<string, string> year()//-----------Years
        {
            Dictionary<string, string> yearList = new Dictionary<string, string>();

            HtmlNodeCollection node = html.DocumentNode.SelectNodes("//select[@name='year[1]']");
            HtmlNodeCollection nodes = node[0].SelectNodes("option");

            foreach (HtmlNode i in nodes)
            {
                yearList.Add(i.NextSibling.InnerText, i.GetAttributeValue("value", error));
            }

            return yearList;
        }

        public Dictionary<string, string> region()//-----------Region
        {
            Dictionary<string, string> regionList = new Dictionary<string, string>();

            HtmlNodeCollection node = html.DocumentNode.SelectNodes("//select[@id='region_id']");
            HtmlNodeCollection nodes = node[0].SelectNodes("option");

            foreach (HtmlNode i in nodes)
            {
                regionList.Add(i.NextSibling.InnerText, i.GetAttributeValue("value", error));
            }

            return regionList;
        }

    }
}
