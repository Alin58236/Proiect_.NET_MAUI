namespace beerTMobile;
using beerTMobile.Models;
public partial class BirtPage : ContentPage
{
	public BirtPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var birt = (Birt)BindingContext;
        await App.Database.SaveBirtAsync(birt);
        await Navigation.PopAsync();
    }
}