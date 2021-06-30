using Bier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bier.Services.Bases
{
    public interface IUserRepository : IRepositoryGet<UserProfile,int>
    {
        public UserProfile Check(string mail, string password);
    }
}
