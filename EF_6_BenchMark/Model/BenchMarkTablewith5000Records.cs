using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_6_BenchMark.Model
{
    public class BenchMarkTablewith5000Records
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public byte Age { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }        
    }
}
