using System.Collections.ObjectModel;

namespace HotelRental.Entities;

public class Hotel
{
    public string Name { get; set; }
    public ObservableCollection<Room> Rooms { get; set; }

    public Hotel()
    {
        this.Rooms = new ObservableCollection<Room>();
    }
}