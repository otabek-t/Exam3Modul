using CarDataAccess.Entity;

namespace CarRepositories
{
    public interface ICarRepository
    {
        Guid AddCar(Car car);
        void DeleteCar(Guid carId);
        void UpdateCar(Car car);
        List<Car> GetAllCars();
        Car GetCarById(Guid carId);
    }
}