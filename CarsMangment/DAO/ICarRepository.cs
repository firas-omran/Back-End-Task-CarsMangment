using CarsMangment.Models;

namespace CarsMangment.DAO
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars();
        Task<Car> GetCarDetails(int id);
        Task<Car> Add(Car item);
        Task<Car> Update(Car item);
        Task Delete(int id);
    }
}
