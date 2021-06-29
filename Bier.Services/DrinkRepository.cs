using Bier.DataBase;
using Bier.Models;
using Bier.Services.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bier.Services
{
    public class DrinkRepository : IDrinkRepository
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
            return db.Drinks
                .Include(d => d.Brewer)
                .SingleOrDefault(d => d.Id == id);
        }

        public Drink Insert(Drink entity)
        {
            EntityEntry<Drink> result = db.Drinks.Add(entity);
            db.SaveChanges();
            return result.Entity;
        }

        public IEnumerable<Drink> Search(string name, decimal? min_alcohol, decimal? max_alcohol, DrinkColors? color, DrinkTypes? type)
        {
            IQueryable<Drink> query = db.Drinks;
            if (!string.IsNullOrEmpty(name)) 
                query = query.Where(d => d.Name.Contains(name));
            if (min_alcohol != null && max_alcohol != null)
                query = query.Where(d => d.AlcoholIntensity >= min_alcohol && d.AlcoholIntensity <= max_alcohol);
            if (color != null)
                query = query.Where(d => d.Color == color);
            if (type != null)
                query = query.Where(d => d.Type == type);
            return query.ToList();
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
