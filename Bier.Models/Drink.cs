using System;

namespace Bier.Models
{
    public class Drink : IDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AlcoholIntensity { get; set; }
        public DrinkColors Color { get; set; }
        public DrinkTypes Type { get; set; }
        public int BrewerId { get; set; }

        public Brewer Brewer { get; set; }
    }
}
