using HotelRental.EditRoom;
using HotelRental.Entities;

namespace HotelRental.RoomList
{
    public partial class RoomListPage : ContentPage
    {
        private Hotel _hotel;
        private MainPageViewModel mpvm;

        public RoomListPage(MainPageViewModel mpvm)
        {
            this._hotel = mpvm.SelectedHotel;
            this.mpvm = mpvm;
            InitializeComponent();
            BindingContext = new RoomListPageViewModel(_hotel);
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRoomPage(_hotel));
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteRoomPage(_hotel));
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditRoomPage(mpvm, _hotel));
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(mpvm));
        }
    }
}