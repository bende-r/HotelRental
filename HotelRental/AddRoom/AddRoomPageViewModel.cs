using System.Collections.ObjectModel;
using System.ComponentModel;

using HotelRental.Entities;

namespace HotelRental.AddRoom;

public class AddRoomPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<Room> _hotelRooms;

    private int _newRoomNumber;
    public int NewRoomNumber
    {
        get => _newRoomNumber;
        set
        {
            _newRoomNumber = value;
            OnPropertyChanged(nameof(NewRoomNumber));
        }
    }

    private string _newRoomDescription;
    public string NewRoomDescription
    {
        get => _newRoomDescription;
        set
        {
            _newRoomDescription = value;
            OnPropertyChanged(nameof(NewRoomDescription));
        }
    }

    private double _newRoomPrice;
    public double NewRoomPrice
    {
        get => _newRoomPrice;
        set
        {
            _newRoomPrice = value;
            OnPropertyChanged(nameof(NewRoomPrice));
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

    public AddRoomPageViewModel(Hotel hotel)
    {
        HotelRooms = hotel.Rooms;
    }

    public void AddRoom()
    {
        var newRoom = new Room
        {
            Number = NewRoomNumber,
            Description = NewRoomDescription,
            PricePerNight = NewRoomPrice
        };
        HotelRooms.Add(newRoom);

        NewRoomNumber = 0;
        NewRoomDescription = string.Empty;
        NewRoomPrice = 0;
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}