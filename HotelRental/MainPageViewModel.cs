using System.Collections.ObjectModel;
using System.ComponentModel;

using HotelRental.Entities;

using Microsoft.Maui.Controls;

namespace HotelRental;

public class MainPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<Hotel> _hotels;

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

    public ObservableCollection<Hotel> Hotels
    {
        get => _hotels;
        set
        {
            _hotels = value;
            OnPropertyChanged(nameof(Hotels));
        }
    }

    public MainPageViewModel()
    {
        Hotels = new ObservableCollection<Hotel>();
        //  load();
    }

    public Hotel this[int id]
    {
        get { return Hotels[id]; }

        set
        {
            Hotels[id] = value;
            OnPropertyChanged(nameof(Hotels));
        }
    }

    public int IndexOf(Hotel hotel)
    {
        return Hotels.IndexOf(hotel);
    }

    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}