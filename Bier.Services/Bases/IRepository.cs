using Bier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bier.Services.Bases
{
    public interface IRepository<Tentity,Tid> : IRepositoryGet<Tentity,Tid>
        where Tentity : IDataModel<Tid>
    {        
        public Tentity Insert(Tentity entity);
        public Tentity Update(Tentity entity);
        public Tentity Delete(Tid id);
    }
}
