namespace CarsMangment.Models
{
    public class Driver
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool? IsAbsence { get; set; }
    }
}
