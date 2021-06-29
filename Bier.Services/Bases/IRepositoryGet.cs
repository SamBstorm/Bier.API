using Bier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bier.Services.Bases
{
    public interface IRepositoryGet<Tentity, Tid> where Tentity : IDataModel<Tid>
    {
        public IEnumerable<Tentity> Get();
        public Tentity Get(Tid id);
    }
}
