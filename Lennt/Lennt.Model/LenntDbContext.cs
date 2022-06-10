using Lennt.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Lennt.Model
{
    public partial class LenntDbContext : DbContext
    {
        public LenntDbContext(DbContextOptions<LenntDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<VacancyType> VacancyTypes { get; set; }


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

            builder.Entity<Person>().HasOne(d => d.Category)
                .WithMany(d => d.Persons)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Persons_Categories_CategoryId");
            #endregion

            #region Categories
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(e => e.Id);

            #endregion

            #region Vacancies
            builder.Entity<Vacancy>().ToTable("Vacancies");
            builder.Entity<Vacancy>().HasKey(e => e.Id);
            builder.Entity<Vacancy>().HasOne(d => d.Category)
                .WithMany(d => d.Vacancies)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Vacancies_Categories_CategoryId");

            builder.Entity<Vacancy>().HasOne(d => d.VacancyType)
               .WithMany(d => d.Vacancies)
               .HasForeignKey(d => d.VacancyTypeId)
               .HasConstraintName("FK_Vacancies_VacancyTypes_VacancyTypeId");
            #endregion

        }
    }
}