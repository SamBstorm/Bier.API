using Bier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bier.Services.Bases
{
    public interface IRepository<Tentity,Tid> where Tentity : IDataModel<Tid>
    {
        public IEnumerable<Tentity> Get();
        public Tentity Get(Tid id);
        public Tentity Insert(Tentity entity);
        public Tentity Update(Tentity entity);
        public void Delete(Tid id);
    }
}
