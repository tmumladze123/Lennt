using Lennt.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lennt.Model
{
    public partial class LenntDbContext : DbContext
    {
        public LenntDbContext(DbContextOptions<LenntDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            #region Person
            builder.Entity<Person>().ToTable("Persons");
            builder.Entity<Person>().HasKey(e => e.Id);
            builder.Entity<Person>().Property(x => x.Username).HasMaxLength(50);

            builder.Entity<Person>().Property(e => e.CreateDate)
                .IsRequired();

            builder.Entity<Person>().Property(e => e.IsDeleted)
              .IsRequired()
              .HasDefaultValue(false);

            builder.Entity<Person>().Property(e => e.Firstname).HasMaxLength(50)
              .IsRequired();

            builder.Entity<Person>().Property(e => e.Lastname).HasMaxLength(50)
            .IsRequired();

            builder.Entity<Person>().Property(e => e.BirthDate)
            .IsRequired();
            #endregion


        }
    }
}