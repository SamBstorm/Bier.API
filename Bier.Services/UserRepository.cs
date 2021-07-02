using Bier.DataBase;
using Bier.Models;
using Bier.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;

namespace Bier.Services
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        private Func<UserProfile, UserPublic> mapping =
        (pro) =>
        {
            if (pro is null) return null;
            return new UserPublic
            {
                Id = pro.Id,
                FirstName = pro.FirstName,
                LastName = pro.LastName,
                BirthDate = pro.BirthDate,
                Email = pro.Email,
                Token = null
            };
        };

        //private UserPublic Mapping(UserProfile pro) { 
        //    if (pro is null) return null;
        //    return new UserPublic
        //    {
        //        Id = pro.Id,
        //        FirstName = pro.FirstName,
        //        LastName = pro.LastName,
        //        BirthDate = pro.BirthDate,
        //        Email = pro.Email,
        //        Token = null
        //    };
        //}

        public UserRepository(DataContext db) : base(db)
        {
        }

        public UserPublic Check(string mail, string password)
        {
            UserProfile user = db.Users.Where(u => u.Email == mail).SingleOrDefault();
            if (user == null) return null;
            byte[] possiblePassword = PasswordHasher.Hashing(user, password, p => p.Salt);
            if(possiblePassword.SequenceEqual(user.Password)) return mapping(user);
            return null;
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
