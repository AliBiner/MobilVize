using MobilVize.Core.Dtos;
using MobilVize.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Core.Services
{
    public interface IUserService:IGenericService<User>
    {
        public void Signup(SignupDto dto);
        public Task<CustomResponseDto<LoginSuccessDto>> Login(LoginDto dto);

        public Task<CustomResponseDto<UpdateUserDto>> UpdateUser(UpdateUserDto dto);

    }
}
