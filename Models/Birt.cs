using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SQLiteNetExtensions.Attributes;
namespace beerTMobile.Models
{
    public class Birt
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string BirtName { get; set; }
        public string Adresa { get; set; }
        public string BirtDetails
        {
            get
            {
                return BirtName + " " +Adresa;} }
        [OneToMany]
 public List<Rezervare> Rezervari { get; set; }

    }
}
