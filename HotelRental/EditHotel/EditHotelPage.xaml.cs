using System.Collections.ObjectModel;

using HotelRental.Entities;

namespace HotelRental.EditHotel
{
    public partial class EditHotelPage : ContentPage
    {
        private MainPageViewModel vmh;

        public EditHotelPage(MainPageViewModel hotels)
        {
            InitializeComponent();
            BindingContext = new EditHotelViewModel(hotels.Hotels);
            vmh = hotels;
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = (EditHotelViewModel)BindingContext;
            if (viewModel.SelectedHotel != null)
            {
                viewModel.UpdateHotel(viewModel.SelectedHotel);
                viewModel.SelectedHotel = null;
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(vmh));
            vmh.OnPropertyChanged(nameof(vmh.Hotels));
        }
    }
}