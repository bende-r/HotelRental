using System.Collections.ObjectModel;
using System.ComponentModel;

using HotelRental.Entities;

namespace HotelRental.DeleteHotel;

public class DeleteHotelPageViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Hotel> _hotels;

    public DeleteHotelPageViewModel(ObservableCollection<Hotel> hotelList)
    {
        Hotels = hotelList;
    }

    public ObservableCollection<Hotel> Hotels
    {
        get => _hotels;
        set
        {
            _hotels = value;
            OnPropertyChanged(nameof(Hotels));
        }
    }
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

    public event PropertyChangedEventHandler PropertyChanged;

    public void DeleteHotel(Hotel hotel)
    {
        Hotels.Remove(hotel);
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}