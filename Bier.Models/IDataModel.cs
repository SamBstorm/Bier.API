using System;
using System.Collections.Generic;
using System.Text;

namespace Bier.Models
{
    public interface IDataModel<Tid>
    {
        public Tid Id { get; }
    }
}
