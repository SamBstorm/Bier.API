using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bier.Models
{
    public class Drink : IDataModel<int>
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(3,1)")]
        public decimal AlcoholIntensity { get; set; }
        [Required]
        public DrinkColors Color { get; set; }
        [Required]
        public DrinkTypes Type { get; set; }
        [Required]
        public int BrewerId { get; set; }

        public Brewer Brewer { get; set; }
    }
}
