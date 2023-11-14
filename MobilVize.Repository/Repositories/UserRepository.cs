using Microsoft.EntityFrameworkCore;
using MobilVize.Core.Dtos;
using MobilVize.Core.Entities;
using MobilVize.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext appDbContext, AppDbContext context) : base(appDbContext)
        {
            this.context = context;
        }

        public User GetUserByEmail(LoginDto dto)
        {
           
            var user =  context.Users.Where(x => x.Email == dto.Email && x.Password == dto.Password).FirstOrDefault();
            return user;
        }
    }
}
