using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using SQLiteNetExtensions.Attributes;


namespace beerTMobile.Models
{
    public class Produs
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Descriere { get; set; }
        [OneToMany]
        public List<ListaProdus> ListaProduse { get; set; }
    }
}
