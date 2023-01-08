using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using SQLiteNetExtensions.Attributes;

namespace beerTMobile.Models
{
    public class ListaProdus
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Rezervare))]
        public int RezervareID { get; set; }
        public int ProdusID { get; set; }
    }
}
