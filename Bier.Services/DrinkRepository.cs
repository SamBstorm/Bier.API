using Bier.DataBase;
using Bier.Models;
using Bier.Services.Bases;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bier.Services
{
    public class DrinkRepository : IRepository<Drink, int>
    {
        private readonly DataContext db;

        public DrinkRepository(DataContext db)
        {
            this.db = db;
        }

        public void Delete(int id)
        {
            Drink result = Get(id);

            if(result != null)
            {
                db.Drinks.Remove(result);
                db.SaveChanges();
            }
        }

        public IEnumerable<Drink> Get()
        {
            return db.Drinks.ToList();
        }

        public Drink Get(int id)
        {
            return db.Drinks.SingleOrDefault(d => d.Id == id);
        }

        public Drink Insert(Drink entity)
        {
            EntityEntry<Drink> result = db.Drinks.Add(entity);
            db.SaveChanges();
            return result.Entity;
        }

        public Drink Update(Drink entity)
        {
            Drink result = Get(entity.Id);

            if(result != null)
            {
                result.Name = entity.Name;
                result.AlcoholIntensity = entity.AlcoholIntensity;
                result.BrewerId = entity.BrewerId;
                result.Color = entity.Color;
                result.Type = entity.Type;

                db.SaveChanges();
            }

            return result;
        }
    }
}
