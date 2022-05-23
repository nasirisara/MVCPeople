using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPeople.Models;
using Microsoft.AspNetCore.Identity;

namespace MVCPeople.Data
{
    public class PeopleDbContext:IdentityDbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonLanguage>().HasKey(dtk => new
            {
                dtk.PersonId,
                dtk.LanguageId
            });



            modelBuilder.Entity<PersonLanguage>() 
                .HasOne(dtk => dtk.Person)
                .WithMany(dt => dt.PersonLanguages)
                .HasForeignKey(dtk => dtk.PersonId);

            modelBuilder.Entity<PersonLanguage>() 
                .HasOne(dtk => dtk.Language)
                .WithMany(dt => dt.PersonLanguages)
                .HasForeignKey(dtk => dtk.LanguageId);

        }
        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }
    }

}

