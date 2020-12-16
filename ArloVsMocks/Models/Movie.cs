using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArloVsMocks.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public double? AverageRating { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}