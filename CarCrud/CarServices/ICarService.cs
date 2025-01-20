using CarServices.Dtos;

namespace CarServices
{
    public interface ICarService
    {
        Guid AddCarDto(CarDto car);
        void DeleteCarDto(Guid carId);
        void UpdateCarDto(CarDto car);
        List<CarDto> GetAllCarsDto();
        CarDto GetCarByIdDto(Guid carId);

        List<CarDto> GetAllCarByBrand(string brand);
        CarDto GetMostExpensiveCar();
        List<CarDto> GetCarsByYearRange(int startYear, int endYear);
        CarDto GetLowestMileAgeCar();
        List<CarDto> SearchCarsByModel(string keyword);
        List<CarDto> SearchCarsWithinPriceRange(double minPrice, double maxPrice);
        double GetAverageCapasityByBrand();
        List<CarDto> GetCarsSortedByPrice();
        List<CarDto> GetRecentCars(int years);
        List<CarDto> TotalPrice();
    }
}