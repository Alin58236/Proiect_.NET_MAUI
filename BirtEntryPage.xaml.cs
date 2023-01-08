namespace beerTMobile;
using beerTMobile.Models;
public partial class BirtEntryPage : ContentPage
{
	public BirtEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetBirturiAsync();
    }
    async void OnBirtAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BirtPage
        {
            BindingContext = new Birt()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new BirtPage
            {
                BindingContext = e.SelectedItem as Birt
            });
        }
    }

}