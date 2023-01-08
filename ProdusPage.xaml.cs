namespace beerTMobile;

using beerTMobile.Models;
public partial class ProdusPage : ContentPage
{
    Rezervare rl;
    public ProdusPage(Rezervare rlist)
	{
		InitializeComponent();
        rl= rlist;
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var produs = (Produs)BindingContext;
        await App.Database.SaveProdusAsync(produs);
        listView.ItemsSource = await App.Database.GetProduseAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var produs = (Produs)BindingContext;
        await App.Database.DeleteProdusAsync(produs);
        listView.ItemsSource = await App.Database.GetProduseAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Produs p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Produs;
            var lp = new ListaProdus()
            {
                RezervareID = rl.ID,
                ProdusID = p.ID
            };
            await App.Database.SaveListaProdusAsync(lp);
            p.ListaProduse = new List<ListaProdus> { lp };
            await Navigation.PopAsync();
        }
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProduseAsync();
    }

}