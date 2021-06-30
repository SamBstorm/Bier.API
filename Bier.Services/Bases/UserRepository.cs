using Bier.DataBase;
using Bier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;

namespace Bier.Services.Bases
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        private Func<UserProfile, UserPublic> mapping =
        (pro) => new UserPublic {
            Id = pro.Id,
            FirstName = pro.FirstName,
            LastName = pro.LastName,
            BirthDate = pro.BirthDate,
            Email = pro.Email,
            Token = null
        };

        public UserRepository(DataContext db) : base(db)
        {
        }

        public UserPublic Check(string mail, string password)
        {
            return mapping(
                    db.Users
                    .Where(u => u.Email == mail)
                    .SingleOrDefault(u => u.Password == PasswordHasher.Hashing(u, password, u => u.Salt))
                );
        }

        public IEnumerable<UserPublic> Get()
        {
            return db.Users.Select(u => mapping(u)).ToList();
        }

        public UserPublic Get(int id)
        {
            return mapping(db.Users.SingleOrDefault(u => u.Id == id));
        }
    }
}
