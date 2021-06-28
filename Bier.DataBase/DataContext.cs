using Bier.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bier.DataBase
{
    public class DataContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Brewer> Brewers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Brewers
            modelBuilder.Entity<Brewer>().HasData(new Brewer { Id = 1, SocietyName = "AB inbev", Country = "Belgium" });
            modelBuilder.Entity<Brewer>().HasData(new Brewer { Id = 2, SocietyName = "Duvel Mortgat", Country = "Belgium" });
            modelBuilder.Entity<Brewer>().HasData(new Brewer { Id = 3, SocietyName = "Heineken", Country = "Nederland" });
            modelBuilder.Entity<Brewer>().HasData(new Brewer { Id = 4, SocietyName = "Carlsberg", Country = "Danemark" });

            //Drinks
            modelBuilder.Entity<Drink>().HasData(new Drink { Id = 1, Name = "Jupiler", AlcoholIntensity = 5.5, Color = DrinkColors.Blond, Type = DrinkTypes.Pils, BrewerId = 1 });
            modelBuilder.Entity<Drink>().HasData(
                new Drink
                {
                    Id = 2,
                    Name = "Jupiler 0",
                    AlcoholIntensity = 0,
                    Color = DrinkColors.Blond,
                    Type = DrinkTypes.Pils,
                    BrewerId = 1
                });
            modelBuilder.Entity<Drink>().HasData(
                new Drink
                {
                    Id = 3,
                    Name = "Duvel",
                    AlcoholIntensity = 6.2,
                    Color = DrinkColors.Blond,
                    Type = DrinkTypes.Abbey,
                    BrewerId = 2
                });
            modelBuilder.Entity<Drink>().HasData(
                new Drink
                {
                    Id = 4,
                    Name = "Maredsous",
                    AlcoholIntensity = 8,
                    Color = DrinkColors.Brown,
                    Type = DrinkTypes.Abbey,
                    BrewerId = 2
                });
            modelBuilder.Entity<Drink>().HasData(
                new Drink
                {
                    Id = 5,
                    Name = "Heineken",
                    AlcoholIntensity = 4.5,
                    Color = DrinkColors.Blond,
                    Type = DrinkTypes.Pils,
                    BrewerId = 3
                });
            modelBuilder.Entity<Drink>().HasData(
                new Drink
                {
                    Id = 6,
                    Name = "Heineken Special",
                    AlcoholIntensity = 4.5,
                    Color = DrinkColors.Red,
                    Type = DrinkTypes.Pils,
                    BrewerId = 3
                });
            modelBuilder.Entity<Drink>().HasData(
                new Drink
                {
                    Id = 7,
                    Name = "Carlsberg",
                    AlcoholIntensity = 5,
                    Color = DrinkColors.Blond,
                    Type = DrinkTypes.Pils,
                    BrewerId = 4
                });
        }
    }
}
