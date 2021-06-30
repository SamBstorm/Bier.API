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
        public UserRepository(DataContext db) : base(db)
        {
        }

        public UserProfile Check(string mail, string password)
        {
            return db.Users
                .Where(u => u.Email == mail)
                .SingleOrDefault(u => u.Password == PasswordHasher.Hashing(u, password, u => u.Salt));
        }

        public IEnumerable<UserProfile> Get()
        {
            return db.Users.ToList();
        }

        public UserProfile Get(int id)
        {
            return db.Users.SingleOrDefault(u => u.Id == id);
        }
    }
}
