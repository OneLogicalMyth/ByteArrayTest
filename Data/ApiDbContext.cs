using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ByteArrayTest.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<MyObject> Objects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var myObjectEntity = modelBuilder.Entity<MyObject>();

            myObjectEntity
                .HasKey(x => x.Id);

            myObjectEntity
                .HasIndex(x => x.Name)
                .IsUnique();

            myObjectEntity
                .Property(p => p.RowVersion)
                .IsRowVersion();

            modelBuilder
                .Entity<MyObject>()
                .HasData(new List<MyObject>
                {
                    new MyObject{ Id = Guid.NewGuid(), Name = "Testing 123" },
                    new MyObject{ Id = Guid.NewGuid(), Name = "Testing 345" },
                    new MyObject{ Id = Guid.NewGuid(), Name = "Testing 678" },
                    new MyObject{ Id = Guid.NewGuid(), Name = "Testing 901" },
                    new MyObject{ Id = Guid.NewGuid(), Name = "Testing 234" },
                    new MyObject{ Id = Guid.NewGuid(), Name = "Testing 567" },
                    new MyObject{ Id = Guid.NewGuid(), Name = "Testing 890" }
                });
        }
    }
}