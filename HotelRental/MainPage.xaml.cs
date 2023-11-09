using System.Collections.ObjectModel;

using HotelRental.DeleteHotel;
using HotelRental.EditHotel;
using HotelRental.Entities;
using HotelRental.RoomList;

namespace HotelRental;

public partial class MainPage : ContentPage
{
    MainPageViewModel _mainPageViewModel = new MainPageViewModel();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = _mainPageViewModel;
        ObservableCollection<Hotel> hotelList = JsonFileHandler.LoadData();
        if (hotelList != null)
            _mainPageViewModel.Hotels = JsonFileHandler.LoadData();
    }

    public MainPage(MainPageViewModel mpvm)
    {
        InitializeComponent();
        _mainPageViewModel = mpvm;
        BindingContext = mpvm;
    }


    private async void ShowRoomsPage(object sender, EventArgs e)
    {
        var viewModel = _mainPageViewModel;
        if (viewModel.SelectedHotel != null)
        {
            await Navigation.PushAsync(new RoomListPage(_mainPageViewModel));
        }
    }

    private async void AddHotelClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddHotelPage(_mainPageViewModel.Hotels));
    }

    private async void DeleteHotelClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DeleteHotelPage(_mainPageViewModel.Hotels));
    }

    private async void EditHotelClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditHotelPage(_mainPageViewModel));
    }

    private void Button_OnClicked(object sender, EventArgs e)
    {
        JsonFileHandler.SaveData(_mainPageViewModel.Hotels);
    }
}