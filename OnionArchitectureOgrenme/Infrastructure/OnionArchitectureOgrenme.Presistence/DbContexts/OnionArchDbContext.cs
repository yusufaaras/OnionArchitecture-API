using Microsoft.EntityFrameworkCore;
using OnionArchitectureOgrenme.Domain.Common;
using OnionArchitectureOgrenme.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureOgrenme.Presistence.DbContexts
{
    public class OnionArchDbContext:DbContext
    {
        public DbSet<Event> Events { get; set; }

        //locationun veriobject olduğunu söyleme işlemi

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().OwnsOne(x => x.Location);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("OnionArchDbContext");
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //intersepction: asıl method çalışmadan önce araya girmek için 
            var data = ChangeTracker.Entries<EntityBase>();
            foreach (var entry in data)
            {
                if (entry.State==EntityState.Added)
                {
                entry.Entity.CreateDate = DateTime.UtcNow;
                }else if(entry.State == EntityState.Modified)
                    entry.Entity.UpdateDate = DateTime.UtcNow;  
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
