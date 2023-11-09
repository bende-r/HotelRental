using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelRental.AddHotel;
using HotelRental.Entities;

namespace HotelRental
{

    public partial class AddHotelPage : ContentPage
    {

        public AddHotelPage(ObservableCollection<Hotel> hotels)
        {
            InitializeComponent();
            BindingContext = new AddHotelPageViewModel(hotels);
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = (AddHotelPageViewModel)BindingContext;
            viewModel.AddHotel();
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}