using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using beerTMobile.Models;


namespace beerTMobile.Data
{
    public class RezervariDatabase
    {
        readonly SQLiteAsyncConnection database;
        public RezervariDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Rezervare>().Wait();
            database.CreateTableAsync<Produs>().Wait();
            database.CreateTableAsync<ListaProdus>().Wait();
        }

        public Task<int> SaveProdusAsync(Produs product)
        {
            if (product.ID != 0)
            {
                return database.UpdateAsync(product);
            }
            else
            {
                return database.InsertAsync(product);
            }
        }
        public Task<int> DeleteProdusAsync(Produs product)
        {
            return database.DeleteAsync(product);
        }
        public Task<List<Produs>> GetProduseAsync()
        {
            return database.Table<Produs>().ToListAsync();
        }

        public Task<int> SaveListaProdusAsync(ListaProdus listp)
        {
            if (listp.ID != 0)
            {
                return database.UpdateAsync(listp);
            }
            else
            {
                return database.InsertAsync(listp);
            }
        }
        public Task<List<Produs>> GetListaProduseAsync(int shoplistid)
        {
            return database.QueryAsync<Produs>(
            "select P.ID, P.Description from Product P"
            + " inner join ListProduct LP"
            + " on P.ID = LP.ProductID where LP.ShopListID = ?",
            shoplistid);
        }



        public Task<List<Rezervare>> GetRezervariAsync()
        {
            return database.Table<Rezervare>().ToListAsync();
        }
        public Task<Rezervare> GetRezervareAsync(int id)
        {
            return database.Table<Rezervare>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveRezervareAsync(Rezervare rlist)
        {
            if (rlist.ID != 0)
            {
                return database.UpdateAsync(rlist);
            }
            else
            {
                return database.InsertAsync(rlist);
            }
        }
        public Task<int> DeleteRezervareAsync(Rezervare rlist)
        {
            return database.DeleteAsync(rlist);
        }
    }
}
