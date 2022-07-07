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
        public DbSet<VacancyPerson> VacancyPersons { get; set; }
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
            builder.Entity<Vacancy>().Property(e => e.IsActive)
            .IsRequired()
            .HasDefaultValue(true);
            builder.Entity<Vacancy>().HasOne(d => d.Category)
                .WithMany(d => d.Vacancies)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Vacancies_Categories_CategoryId");

            builder.Entity<Vacancy>().HasOne(d => d.VacancyType)
               .WithMany(d => d.Vacancies)
               .HasForeignKey(d => d.VacancyTypeId)
               .HasConstraintName("FK_Vacancies_VacancyTypes_VacancyTypeId");
            #endregion
            #region vacancyPerson
            builder.Entity<VacancyPerson>().ToTable("VacancyPersons");
            builder.Entity<VacancyPerson>().HasKey(e => e.Id);
            builder.Entity<VacancyPerson>().Property(e => e.IsDeleted)
              .IsRequired()
              .HasDefaultValue(false);
            builder.Entity<VacancyPerson>().Property(e => e.IsApproved)
              .IsRequired()
              .HasDefaultValue(false);
            builder.Entity<VacancyPerson>().Property(e => e.IsActive)
              .IsRequired()
              .HasDefaultValue(true);
            builder.Entity<VacancyPerson>().Property(e => e.PersonId)
              .IsRequired();
            builder.Entity<VacancyPerson>().Property(e => e.VacancyId)
              .IsRequired();
            builder.Entity<VacancyPerson>().HasOne(d => d.Person)
               .WithMany(d => d.VacancyPersons)
               .HasForeignKey(d => d.PersonId)
               .HasConstraintName("FK_VacancyPersons_Persons_PersonId");
            builder.Entity<VacancyPerson>().HasOne(d => d.Vacancy)
               .WithMany(d => d.VacancyPersons)
               .HasForeignKey(d => d.VacancyId)
               .HasConstraintName("FK_VacancyPersons_Vacancies_VacancyId");
            #endregion

            #region VacancyType
            builder.Entity<VacancyType>().ToTable("VacancyTypes");
            builder.Entity<VacancyType>().HasKey(e => e.Id);

            #endregion

        }
    }
}