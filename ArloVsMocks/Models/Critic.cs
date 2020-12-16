using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArloVsMocks.Models
{
    [Table("Critic")]
    public class Critic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double RatingWeight { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}