using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClass
{
    public class SearchInfo
    {
        public int mark_id;
        public int year1;
        public int year2;
        public int region;

        public void setInfo(int mark_id, int year1, int year2, int region)
        {
            this.mark_id = mark_id;
            this.year1 = year1;
            this.year2 = year2;
            this.region = region;
        }
    }
}
