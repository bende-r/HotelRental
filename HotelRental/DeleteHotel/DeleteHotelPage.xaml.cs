using System.Collections.ObjectModel;

using HotelRental.Entities;

namespace HotelRental.DeleteHotel
{
    public partial class DeleteHotelPage : ContentPage
    {
        public DeleteHotelPage(ObservableCollection<Hotel> hotels)
        {
            InitializeComponent();
            BindingContext = new DeleteHotelPageViewModel(hotels);
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = (DeleteHotelPageViewModel)BindingContext;
            if (viewModel.SelectedHotel != null)
            {
                viewModel.DeleteHotel(viewModel.SelectedHotel);
                viewModel.SelectedHotel = null;
            }
        }
    }
}