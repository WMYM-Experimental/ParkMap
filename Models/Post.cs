using ParkMap.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace ParkMap.Models
{
    public class Post
    {
        public Post()
        {
            Reactions = new HashSet<Reaction>();
        }

        [Key]
        public int Id { get; set; }
        public ParkMapUser? ParkMapUser { get; set; }

        public int ParkingLotId { get; set; }
        public ParkingLot? ParkingLot { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool State { get; set; } // to see if it is deprecated

        public string? Text { get; set; }

        public string? Picture { get; set; } // ask if a picture could be stored like this.

        public ICollection<Reaction>? Reactions { get; set; }

        public string MyEmail { get; set; }
    }
}
