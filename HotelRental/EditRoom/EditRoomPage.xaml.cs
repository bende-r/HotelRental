using HotelRental.Entities;
using HotelRental.RoomList;

namespace HotelRental.EditRoom
{
    public partial class EditRoomPage : ContentPage
    {
        private Hotel _hotel;
        private MainPageViewModel mpvm;
        public EditRoomPage(MainPageViewModel mpvm, Hotel hotel)
        {
            this._hotel = hotel;
            this.mpvm = mpvm;
            InitializeComponent();
            BindingContext = new EditRoomPageViewModel(hotel);
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RoomListPage(mpvm));
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = (EditRoomPageViewModel)BindingContext;
            if (viewModel.SelectedRoom != null)
            {
                viewModel.UpdateRoom(viewModel.SelectedRoom);
                viewModel.SelectedRoom = null;
            }
        }
    }
}