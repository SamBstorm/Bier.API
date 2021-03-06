using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bier.Models
{
    public class Brewer : IDataModel<int>
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string SocietyName { get; set; }
        [Required]
        [MaxLength(32)]
        public string Country { get; set; }
    }
}
