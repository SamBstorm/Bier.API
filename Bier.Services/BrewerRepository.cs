using Bier.DataBase;
using Bier.Models;
using Bier.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bier.Services
{
    public class BrewerRepository : RepositoryBase, IBrewerRepository
    {
        public BrewerRepository(DataContext db) : base(db)
        {
        }

        public IEnumerable<Brewer> Get()
        {
            return db.Brewers.ToList();
        }

        public Brewer Get(int id)
        {
            return db.Brewers.SingleOrDefault(b => b.Id == id);
        }
    }
}
