using MobilVize.Core.Dtos;
using MobilVize.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Core.Repositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
        public User GetUserByEmail(LoginDto dto);
    }
}
