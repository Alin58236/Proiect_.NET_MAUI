using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using SQLiteNetExtensions.Attributes;

namespace beerTMobile.Models
{
    public class Rezervare
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(300), Unique]
        public string Descriere { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(typeof(Birt))]
        public int BirtID { get; set; }

    }
}
