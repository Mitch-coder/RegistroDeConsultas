using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCap
{
    public class EntitieQuery
    {
        public int id { get; set; }
        public int numberWeek { get; set; }
        public int numberStudent { get; set; }
        public string topic { get; set; }
        public string observations { get; set; }
        public string idStudent { get; set; }
        public string signStudent { get; set; }
        public DateTime Date { get; set; }
    }
}
