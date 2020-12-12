using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LandmarkRemark.Models
{
  /*  public interface IDbContext
    {
        DbSet<user> user { get; set; }
        int SaveChanges();
    }*/
    public class userContext : DbContext//, IDbContext
    {
        public userContext (DbContextOptions<userContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
