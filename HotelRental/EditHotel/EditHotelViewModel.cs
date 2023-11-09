using System.Collections.ObjectModel;
using System.ComponentModel;

using HotelRental.Entities;

namespace HotelRental.EditHotel;

public class EditHotelViewModel : INotifyPropertyChanged
{
    //    private MainPageViewModel _h;

    private ObservableCollection<Hotel> _hotels;

    public ObservableCollection<Hotel> Hotels
    {
        get => _hotels;
        set
        {
            _hotels = value;
            OnPropertyChanged(nameof(Hotels));
        }
    }

    public EditHotelViewModel(ObservableCollection<Hotel> hotel)
    {
        this.Hotels = hotel;
    }

    //public EditHotelViewModel(MainPageViewModel hotelList)
    //{
    //    H = hotelList;
    //    Hotels = H.Hotels;
    //}

    //public MainPageViewModel H
    //{
    //    get;
    //    set;
    //}

    private Hotel _selectedHotel;

    public Hotel SelectedHotel
    {
        get => _selectedHotel;
        set
        {
            if (_selectedHotel != value)
            {
                _selectedHotel = value;
                OnPropertyChanged(nameof(SelectedHotel));
            }
        }
    }

    private string _newHotelName;
    public string NewHotelName
    {
        get => _newHotelName;
        set
        {
            _newHotelName = value;
            OnPropertyChanged(nameof(NewHotelName));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void UpdateHotel(Hotel hotel)
    {
        int ind = Hotels.IndexOf(hotel);

        Hotel newHotel = new Hotel()
        {
            Name = NewHotelName
        };

        Hotels[ind] = newHotel;

        NewHotelName = string.Empty;
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}