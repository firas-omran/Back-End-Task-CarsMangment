using CarsMangment.Data;
using CarsMangment.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsMangment.DAO
{
    public class CarRepository : ICarRepository
    {
        CarsMangmentContext _context;
        public CarRepository(CarsMangmentContext context)
        {
            _context = context;
        }

        public async Task<Car> Add(Car item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task Delete(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Car> GetCarDetails(int id)
        {
            var car = await _context.Cars.Include("Customer").Include("Driver").Where(item => item.Id==id).FirstOrDefaultAsync();
            
            return car;
        }

        public IEnumerable<Car> GetCars()
        {
            return  _context.Cars.Include("Customer").Include("Driver");
        }

        public async Task<Car> Update(Car car)
        {
           _context.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }
}
