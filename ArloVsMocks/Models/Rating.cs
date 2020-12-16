using System.ComponentModel.DataAnnotations;

namespace ArloVsMocks.Models
{
    [Table("Rating")]
    public class Rating
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Critic")]
        public int CriticId { get; set; }
        public int Stars { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Critic Critic { get; set; }
    }
}