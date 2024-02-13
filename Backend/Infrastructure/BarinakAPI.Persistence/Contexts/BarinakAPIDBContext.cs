using BarinakAPI.Domain.Entities;
using BarinakAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Persistence.Contexts
{
    public class BarinakAPIDBContext : IdentityDbContext<AppUser,AppRole,string>

    {
        
        public BarinakAPIDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Domain.Entities.File> Files{ get; set; }
        public DbSet<AnimalImageFile> AnimalImageFiles { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles{ get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Applicant>()
                .HasKey(b=>b.Id);
            builder.Entity<Applicant>()
                .HasIndex(o=>o.ApplicantCode).
                IsUnique();

            builder.Entity<Basket>()
                .HasOne(b => b.Applicant)
                .WithOne(o => o.Basket)
                .HasForeignKey<Applicant>(b => b.Id);
            base.OnModelCreating(builder);
             
        }

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    var datas = ChangeTracker.Entries<BaseEntity>();

        //    foreach (var data in datas)
        //    {
        //        _ = data.State switch
        //        {
        //            EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow,
        //            EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow

        //        };
        //    }

        //    return await base.SaveChangesAsync(cancellationToken);
        //}

    }
}
