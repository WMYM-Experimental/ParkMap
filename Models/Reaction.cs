using ParkMap.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace ParkMap.Models
{
    public class Reaction
    {
        [Key]
        public int Id { get; set; }
        public ParkMapUser? ParkMapUser { get; set; }
        public bool Type { get; set; } // true for like, false for dislike
    }
}