using System.Text.Json;
using CarDataAccess.Entity;

namespace CarRepositories;

public class CarRepository : ICarRepository
{
    private readonly string _carPath;
    private readonly List<Car> _cars;
    public CarRepository()
    {
        _carPath = Path.Combine(Directory.GetCurrentDirectory(), "carfile.json");
        if (!Directory.Exists(_carPath))
        {
            File.WriteAllText(_carPath, "[]");
        }
        _cars = new List<Car>();
        _cars = GetAllCars();
    }

    public Guid AddCar(Car car)
    {
        _cars.Add(car);
        SaveData();
        return car.Id;
    }

    public void DeleteCar(Guid carId)
    {
        var checkId = GetCarById(carId);
        _cars.Remove(checkId);
    }

    public List<Car> GetAllCars()
    {
        var fileAll = File.ReadAllText(_carPath);
        var readCars = JsonSerializer.Deserialize<List<Car>>(fileAll);
        return readCars;
    }

    public Car GetCarById(Guid carId)
    {
        var getCar = GetAllCars();
        return getCar.Where(ca => ca.Id == carId).First();
    }

    public void UpdateCar(Car car)
    {
        _cars[_cars.IndexOf(car)] = car;
        SaveData();
    }
    private void SaveData()
    {
        var carJson = JsonSerializer.Serialize(_cars);
        File.WriteAllText(_carPath, carJson);
    }
}
