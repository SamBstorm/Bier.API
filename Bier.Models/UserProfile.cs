using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bier.Models
{
    public class UserProfile : IDataModel<int>
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "VARBINARY(32)")]
        public byte[] Password { get; set; }
        [Required]
        [Column(TypeName = "CHAR(36)")]
        public string Salt { get; set; }
    }
}
