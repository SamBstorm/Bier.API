using System;
using System.Collections.Generic;
using System.Text;

namespace Bier.Models
{
    public class Brewer : IDataModel
    {
        public int Id { get; set; }
        public string SocietyName { get; set; }
        public string Country { get; set; }

        public IEnumerable<Drink> Drinks { get; set; }
    }
}
