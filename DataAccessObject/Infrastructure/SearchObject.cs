using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Infrastructure
{
    public class SearchObject
    {
        public string SearchName { get; set; }
        public string SearchCPF { get; set; }
        public DateTime SearchDate { get; set; }
        public int SearchID { get; set; }
    }
}
