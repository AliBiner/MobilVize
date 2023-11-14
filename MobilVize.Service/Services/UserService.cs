using AutoMapper;
using MobilVize.Core.Dtos;
using MobilVize.Core.Entities;
using MobilVize.Core.Repositories;
using MobilVize.Core.Services;
using MobilVize.Core.UnitOfWork;
using MobilVize.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Service.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork,IUserRepository userRepository,IMapper mapper) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async  Task<CustomResponseDto<LoginSuccessDto>> Login(LoginDto dto)
        {
            
            var user = _userRepository.GetUserByEmail(dto);
            if (user == null)
            {
                
                return CustomResponseDto<LoginSuccessDto>.Fail(404,"Böyle Bir Kullanıcı Bulunamadı.");
            }
            else
            {
                var model = _mapper.Map<LoginSuccessDto>(user);
                return CustomResponseDto<LoginSuccessDto>.Success(200, model);
            }
            
            
        }

        public void Signup(SignupDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.Id = Guid.NewGuid();
            user.CreateDate = DateTime.Now;
            user.UpdateDate = DateTime.Now;
            AddAsyncTask(user);
            
        }

        public async Task<CustomResponseDto<UpdateUserDto>> UpdateUser(UpdateUserDto dto)
        {
            var user = await _userRepository.GetByIdAsyncTask(dto.Id);
            if (user == null)
            {
                return CustomResponseDto<UpdateUserDto>.Fail(404, "Böyle bir kullanıcı bulunamadı.");

            }
            else {
                try
                {
                    var dataToUpdate = _mapper.Map<User>(dto);
                    dataToUpdate.UpdateDate = DateTime.Now;
                    dataToUpdate.CreateDate = user.CreateDate;

                    await UpdateAsyncTask(dataToUpdate);
                    var data = await _userRepository.GetByIdAsyncTask(dataToUpdate.Id);
                    var mapped = _mapper.Map<UpdateUserDto>(data);
                    return CustomResponseDto<UpdateUserDto>.Success(200, mapped);
                }
                catch (Exception e)
                {
                    return CustomResponseDto<UpdateUserDto>.Fail(400, e.Message);
                }
                
            }
        }
    }
}
