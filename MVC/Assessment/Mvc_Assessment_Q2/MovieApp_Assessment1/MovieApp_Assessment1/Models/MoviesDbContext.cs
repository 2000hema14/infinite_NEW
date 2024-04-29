using System;
using System.Data.Entity;
using MVC_Movie_Assessment1;
namespace MVC_Movie_Assessment1
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext() : base("connectstr")
        { }
        public DbSet<Movie> Movies { get; set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}