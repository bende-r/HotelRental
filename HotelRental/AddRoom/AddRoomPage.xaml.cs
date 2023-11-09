using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelRental.AddRoom;
using HotelRental.Entities;

namespace HotelRental
{

    public partial class AddRoomPage : ContentPage
    {
        public AddRoomPage(Hotel hotel)
        {
            InitializeComponent();
            BindingContext = new AddRoomPageViewModel(hotel);
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = (AddRoomPageViewModel)BindingContext;
            viewModel.AddRoom();
        }
    }
}