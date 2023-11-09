using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelRental.DeleteRoom;
using HotelRental.Entities;


namespace HotelRental
{
    public partial class DeleteRoomPage : ContentPage
    {
        public DeleteRoomPage(Hotel hotel)
        {
            InitializeComponent();
            BindingContext = new DeleteRoomPageViewModel(hotel);
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = (DeleteRoomPageViewModel)BindingContext;
            if (viewModel.SelectedRoom != null)
            {
                viewModel.DeleteRoom(viewModel.SelectedRoom);
                viewModel.SelectedRoom = null;
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}