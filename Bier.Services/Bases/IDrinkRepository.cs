using Bier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bier.Services.Bases
{
    public interface IDrinkRepository : IRepository<Drink,int>
    {
        public IEnumerable<Drink> Search(
            string name,
            decimal? min_alcohol,
            decimal? max_alcohol,
            DrinkColors? color,
            DrinkTypes? type);
    }
}
