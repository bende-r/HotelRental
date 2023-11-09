using System.Collections.ObjectModel;
using System.ComponentModel;

using HotelRental.Entities;

namespace HotelRental.AddHotel;

public class AddHotelPageViewModel : INotifyPropertyChanged
{
    ObservableCollection<Hotel> _hotelList;

    public AddHotelPageViewModel(ObservableCollection<Hotel> hotelList)
    {
        this._hotelList = hotelList;
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

    public void AddHotel()
    {
        if (!NewHotelName.Equals(string.Empty))
        {
            Hotel newHotel = new Hotel()
            {
                Name = NewHotelName
            };

            _hotelList.Add(newHotel);

            NewHotelName = string.Empty;
        }
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}