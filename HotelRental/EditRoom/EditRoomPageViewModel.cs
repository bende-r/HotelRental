using System.Collections.ObjectModel;
using System.ComponentModel;

using HotelRental.Entities;

namespace HotelRental.EditRoom;

public class EditRoomPageViewModel : INotifyPropertyChanged
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

    public EditRoomPageViewModel(Hotel hotel)
    {
        HotelRooms = hotel.Rooms;
    }

    public void UpdateRoom(Room roomUp)
    {
        int ind = HotelRooms.IndexOf(roomUp);

        Room r = new Room()
        {
            Number = NewRoomNumber,
            Description = NewRoomDescription,
            PricePerNight = NewRoomPrice,
        };

        HotelRooms[ind] = r;

        NewRoomNumber = 0;
        NewRoomDescription = string.Empty;
        NewRoomPrice = 0;
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}