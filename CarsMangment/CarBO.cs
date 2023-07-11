using CarsMangment.DAO;
using CarsMangment.Models;

namespace CarsMangment
{
    public class CarBO
    {
        ICarRepository _repo;
        public CarBO(ICarRepository repo) 
        { 
            _repo = repo;
        }
        public async Task<Car>Add(Car car)
        {
            await _repo.Add(car);
            return car;
        }
        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }
        public async Task<Car> GetCarDetails(int id)
        {
            return await _repo.GetCarDetails(id);
        }
        public IEnumerable<Car> GetCars()
        {
            return  _repo.GetCars();
        }
        public async Task<Car> Update(Car car)
        {
            
            await _repo.Update(car);
         
            return car;
        }
    }
}
