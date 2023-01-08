using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace beerTMobile.Models
{
    public class Rezervare
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(300), Unique]
        public string Descriere { get; set; }
        public DateTime Date { get; set; }
    }
}
