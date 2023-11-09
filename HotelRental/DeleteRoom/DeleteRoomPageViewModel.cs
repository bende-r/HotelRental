using System.Collections.ObjectModel;
using System.ComponentModel;

using HotelRental.Entities;

namespace HotelRental.DeleteRoom;

public class DeleteRoomPageViewModel : INotifyPropertyChanged
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

    public DeleteRoomPageViewModel(Hotel hotel)
    {
        HotelRooms = hotel.Rooms;
    }

    public void DeleteRoom(Room room)
    {
        HotelRooms.Remove(room);
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}