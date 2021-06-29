using Bier.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bier.Services.Bases
{
    public abstract class RepositoryBase
    {
        protected readonly DataContext db;

        public RepositoryBase(DataContext db)
        {
            if (db is null) throw new ArgumentNullException("DataContext must be not null");
            this.db = db;
        }
    }
}
