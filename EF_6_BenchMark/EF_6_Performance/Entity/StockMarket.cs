using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_6_BenchMark.EF_6_Performance.Entity
{
    public class StockMarket
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Column(TypeName = "varchar")]
        public string Family { get; set; }
        public int StockShare { get; set; }
        [Column(TypeName = "varchar")]
        public string State { get; set; }
        public DateTime LogTime { get; set; }
    }
}
