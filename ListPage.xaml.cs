namespace beerTMobile;
using beerTMobile.Models;
public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProdusPage((Rezervare)this.BindingContext)
        {
            BindingContext = new Produs()
        });

    }


    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var rlist = (Rezervare)BindingContext;
        rlist.Date = DateTime.UtcNow;
        Birt selectedBirt = (BirtPicker.SelectedItem as Birt);
        rlist.BirtID = selectedBirt.ID;
        await App.Database.SaveRezervareAsync(rlist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var rlist = (Rezervare)BindingContext;
        await App.Database.DeleteRezervareAsync(rlist);
        await Navigation.PopAsync();
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var items = await App.Database.GetBirturiAsync();
        BirtPicker.ItemsSource = (System.Collections.IList)items;
        BirtPicker.ItemDisplayBinding = new Binding("BirtDetails");

        var birtl = (Rezervare)BindingContext;

        listView.ItemsSource = await App.Database.GetListaProduseAsync(birtl.ID);
    }

}