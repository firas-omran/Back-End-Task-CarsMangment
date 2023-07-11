using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsMangment.Models
{
    [Index(nameof(Car.CarNumber), IsUnique = true)]
    public class Car
    {
        public int Id { get; set; }
        
        public string CarNumber { get; set; } = null!;

        public string Type { get; set; } = null!;

        public int Capacity { get; set; }

        public string Color { get; set; } = null!;

        public double Fare { get; set; }

        public bool HasDriver { get; set; }

        public int? DriverId { get; set; }

        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }

        public virtual Driver? Driver { get; set; }
    }
}
