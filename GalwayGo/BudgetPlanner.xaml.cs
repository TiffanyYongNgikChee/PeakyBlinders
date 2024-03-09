using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace GalwayGo
{
    public partial class BudgetPlannerPage : ContentPage
    {
        private CurrencyConversionService _conversionService;
        public ObservableCollection<Activity> SelectedActivities { get; set; }
        public ObservableCollection<Activity> Suggestions { get; set; }

        public BudgetPlannerPage()
        {
            InitializeComponent();

            // Initialize the collection of selected activities
            SelectedActivities = new ObservableCollection<Activity>();

            // Initialize the collection of suggestions
            Suggestions = new ObservableCollection<Activity>();

            // Set the binding context to this page
            BindingContext = this;

            _conversionService = new CurrencyConversionService();
        }

        // Event handler for removing activities
        private void OnRemoveActivityClicked(object sender, EventArgs e)
        {
            // Remove the selected activity from the list
            if (activityListView.SelectedItem != null)
            {
                SelectedActivities.Remove((Activity)activityListView.SelectedItem);
            }
        }

        // Event handler for disabling the budget planner
        private void OnDisableBudgetPlannerClicked(object sender, EventArgs e)
        {
            // Disable the budget planner functionality
            // Add your code to disable the budget planner here
        }

        // Event handler for currency selection change
        private async void OnCurrencyChanged(object sender, EventArgs e)
        {
            // Get the selected currency from the drop-down menu
            var selectedCurrency = currencyPicker.SelectedItem as Currency;

            // Fetch the live exchange rates for the selected currency
            var exchangeRates = await _conversionService.GetExchangeRates(selectedCurrency);

            // Perform currency conversion for activities
            foreach (var activity in activityListView.ItemsSource)
            {
                // Convert the amount for each activity to the selected currency
                var convertedAmount = _conversionService.ConvertCurrency(activity.Amount, exchangeRates);

                // Update the activity with the converted amount
                activity.ConvertedAmount = convertedAmount;
            }
        }

        // Event handler for getting suggestions
        private void OnGetSuggestionsClicked(object sender, EventArgs e)
        {
            // Get suggestions based on user's budget
            // Add your code to generate suggestions here
        }
    }

    // Define the Activity class
    public class Activity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal ConvertedAmount { get; set; }
    }
}
