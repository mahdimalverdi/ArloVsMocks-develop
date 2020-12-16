using ArloVsMocks.Models;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace ArloVsMocks.Data
{
    public class MovieReviewEntities : DbContext
    {
        public MovieReviewEntities()
            : base(new SqlCeConnectionFactory("System.Data.SqlServerCe.3.5").CreateConnection("Data/MovieReviews"), true)
        {
        }
        
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Critic> Critics { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Ratings)
                .WithRequired(r => r.Movie);

            modelBuilder.Entity<Critic>()
                .HasMany(c => c.Ratings)
                .WithRequired(r => r.Critic);



            base.OnModelCreating(modelBuilder);
        }
    }
}