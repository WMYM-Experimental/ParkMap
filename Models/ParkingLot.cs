using System.ComponentModel.DataAnnotations;

namespace ParkMap.Models
{
    public class ParkingLot
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int Availability { get; set; }

        public int? FreeSpots { get; set; }
        public DateTime DateTime { get; set; }
    }
}