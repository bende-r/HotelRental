using System.Collections.ObjectModel;
using System.ComponentModel;

using HotelRental.Entities;

namespace HotelRental.RoomList;

public class RoomListPageViewModel
{
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<Room> _hotelRooms;

    private Room _selectedRoom;

    public Room SelectedRoom
    {
        get => _selectedRoom;
        set
        {
            if (_selectedRoom != value)
            {
                _selectedRoom = value;
                OnPropertyChanged(nameof(SelectedRoom));
            }
        }
    }

    public ObservableCollection<Room> HotelRooms
    {
        get => _hotelRooms;
        set
        {
            _hotelRooms = value;
            OnPropertyChanged(nameof(HotelRooms));
        }
    }

    public RoomListPageViewModel(Hotel hotel)
    {
        HotelRooms = hotel.Rooms;
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}