using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LandmarkRemark.Data
{
  /*  public interface IDbContext
    {
        DbSet<user> user { get; set; }
        int SaveChanges();
    }*/
    public class userContext : DbContext//, IDbContext
    {

        public userContext(DbContextOptions<userContext> options) : base(options)
        { }

        public userContext() // for testing 
        { }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Pin> Pin { get; set; }
     }
}
