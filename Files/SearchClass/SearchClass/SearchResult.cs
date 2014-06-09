using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClass
{
    public class SearchResult
    {
        public List<string[]> carsList = new List<string[]>();
        public List<string> linksList = new List<string>();
        public List<string> photoList = new List<string>();
        public List<DateTime> datesList = new List<DateTime>();
        public DateTime oldestDate = new DateTime();
        public bool Enabled = false;
    }
}
