using Microsoft.Maui.Controls;

namespace GalwayGo;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private async void OnExploreClicked(object sender, EventArgs e)
    {
        // Handle Explore button click event
        // Navigate to another page, launch a modal, etc.
        await Navigation.PushAsync(new BudgetPlanner());
    }
}


