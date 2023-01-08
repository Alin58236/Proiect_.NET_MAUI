namespace beerTMobile;
using beerTMobile.Models;
public partial class ListEntryPage : ContentPage
{
	public ListEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetRezervariAsync();
    }
    async void OnRezervareAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListPage
        {
            BindingContext = new Rezervare()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = e.SelectedItem as Rezervare
            }) ;
        }
    }
}