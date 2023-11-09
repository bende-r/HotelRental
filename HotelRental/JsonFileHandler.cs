using System.Collections.ObjectModel;

using HotelRental.Entities;

using Newtonsoft.Json;

using Formatting = System.Xml.Formatting;

namespace HotelRental;

public class JsonFileHandler
{
    public static void SerializeHotelsToFile(ObservableCollection<Hotel> hotels, string filePath)
    {
        string json = JsonConvert.SerializeObject(hotels, (Newtonsoft.Json.Formatting)Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public static ObservableCollection<Hotel> DeserializeHotelsFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<ObservableCollection<Hotel>>(json);
        }
        return new ObservableCollection<Hotel>();
    }

    public static void SaveData(ObservableCollection<Hotel> hotels)
    {
        string fileName = "HotelRental.json";
        string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyAppFolder");
        Directory.CreateDirectory(directory);

        string filePath = Path.Combine(directory, fileName);

        SerializeHotelsToFile(hotels, filePath);
    }

    public static ObservableCollection<Hotel> LoadData()
    {
        string fileName = "HotelRental.json";
        string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyAppFolder");
        string filePath = Path.Combine(directory, fileName);
        return DeserializeHotelsFromFile(filePath);
    }
}