using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CSCAP.Models;
using Microsoft.Extensions.Hosting;

namespace CSCAP.Data
{
    public class CSCAPContext : DbContext
    {
        public CSCAPContext (DbContextOptions<CSCAPContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(p => p.ParentUser).WithMany(b => b.ChildrenUser).OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<CSCAP.Models.Bank> Bank { get; set; } = default!;

        public DbSet<CSCAP.Models.Card> Card { get; set; } = default!;

        public DbSet<CSCAP.Models.CardOwner> CardOwner { get; set; } = default!;

        public DbSet<CSCAP.Models.Payment> Payment { get; set; } = default!;

        public DbSet<CSCAP.Models.User> User { get; set; } = default!;

        public DbSet<CSCAP.Models.Server> Server { get; set; } = default!;
    }
}
