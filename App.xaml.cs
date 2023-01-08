using System;
using beerTMobile.Data;
using System.IO;

namespace beerTMobile;

public partial class App : Application
{
    static RezervariDatabase database;
    public static RezervariDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new RezervariDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Rezervari.db3"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
