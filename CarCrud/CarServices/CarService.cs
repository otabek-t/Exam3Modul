using System.Runtime.CompilerServices;
using CarDataAccess.Entity;
using CarRepositories;
using CarServices.Dtos;
using CarServices.Extension;

namespace CarServices;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    public CarService()
    {
        _carRepository = new CarRepository();
    }
    public CarDto ConverToDto(Car car)
    {
        return new CarDto
        {
            Id = car.Id,
            Brand = car.Brand,
            Color = car.Color,
            EngineCapasity = car.EngineCapasity,
            MileAge = car.MileAge,
            Model = car.Model,
            Price = car.Price,
            Year = car.Year,
        };
    }
    public Car ConverToEntity(CarDto car)
    {
        return new Car
        {
            Id = car.Id ?? new Guid(),
            Brand = car.Brand,
            Color = car.Color,
            Year = car.Year,
            Price = car.Price,
            Model = car.Model,
            EngineCapasity = car.EngineCapasity,
            MileAge = car.MileAge,
        };
    } 
    public Guid AddCarDto(CarDto car)
    {
        var addCar = _carRepository.AddCar(ConverToEntity(car));
        return addCar;
    }

    public void DeleteCarDto(Guid carId)
    {
        ConverToEntity(GetCarByIdDto(carId));
        _carRepository.DeleteCar(carId);
    }

    public List<CarDto> GetAllCarByBrand(string brand)
    {
        var getBrand = GetAllCarsDto();
        return getBrand.Where(ca => ca.Brand == brand).ToList();
    }

    public List<CarDto> GetAllCarsDto()
    {
        var car = _carRepository.GetAllCars();
        return car.Select(ca => ConverToDto(ca)).ToList();
    }

    public double GetAverageCapasityByBrand()
    {
        var getCar = GetAllCarsDto();
        var getSelect = getCar.Select(ca => ca.Brand).ToList();
        return getCar.Average(ca => ca.Price);

       
       
    }

    public CarDto GetCarByIdDto(Guid carId)
    {
        var getCar = GetAllCarsDto();
        return getCar.Where(ca => ca.Id == carId).First();
    }


    public List<CarDto> GetCarsByYearRange(int startYear, int endYear)
    {
        var getCarYear = GetAllCarsDto();
        return getCarYear.Where(ca => ca.Year >startYear && ca.Year <endYear).ToList();
    }

    public List<CarDto> GetCarsSortedByPrice()
    {
        var getPrice = GetAllCarsDto();
        var priceSort = getPrice.OrderByDescending(ca => ca.Price).ToList();
        return priceSort;
    }

    public CarDto GetLowestMileAgeCar()
    {
        var getLowestMile = GetAllCarsDto();
        var minMile = getLowestMile.Min(ca => ca.MileAge);
        var select = getLowestMile.Single(ca => ca.MileAge == minMile);
        return select;       
        
    }

    public CarDto GetMostExpensiveCar()
    {
        var getMostCar = GetAllCarsDto();
        var mostCar = getMostCar.Max(ca => ca.Price);
        var select = getMostCar.Single(ca => ca.Price == mostCar);
        return select;
    }

    public List<CarDto> GetRecentCars(int years)
    {
        var getRecentCar = GetAllCarsDto();
        return getRecentCar.Where(ca => ca.Year ==  years).ToList();
    }

    public List<CarDto> SearchCarsByModel(string keyword)
    {
        var getModel = GetAllCarsDto();
        return getModel.Where(ca => ca.Model == keyword).ToList();
    }

    public List<CarDto> SearchCarsWithinPriceRange(double minPrice, double maxPrice)
    {
        var getPrice = GetAllCarsDto();
        return getPrice.Where(ca => ca.Price > minPrice && ca.Price < maxPrice).ToList();
    }

    public void UpdateCarDto(CarDto car)
    {
        _carRepository.UpdateCar(ConverToEntity(car));
    }

    public List<CarDto> TotalPrice()
    {
        var getPriceCar = GetAllCarsDto();
        TotalSum.TotalSumma(getPriceCar);
        return getPriceCar;
        
    }
}
