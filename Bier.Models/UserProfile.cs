using System;
using System.Collections.Generic;
using System.Text;

namespace Bier.Models
{
    public class UserProfile : IDataModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
