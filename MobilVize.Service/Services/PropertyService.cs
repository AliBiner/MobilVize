using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MobilVize.Core.Dtos;
using MobilVize.Core.Entities;
using MobilVize.Core.Repositories;
using MobilVize.Core.Services;
using MobilVize.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Service.Services
{
    public class PropertyService : GenericService<Property>, IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PropertyService(IGenericRepository<Property> repository, IUnitOfWork unitOfWork, IMapper mapper, IPropertyRepository propertyRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _propertyRepository = propertyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<UpdatePropertyListDto>> UpdatePropertiesAsync(UpdatePropertyListDto dto)
        {
            try
            {
                var model = await _propertyRepository.WhereQueryable(x => x.MaterialId == dto.MaterialId).OrderBy(x=>x.Id).ToListAsync();
                var listDto = dto.Properties.OrderBy(x=>x.Id).ToList();
                int i = 0;
                foreach (var item in model)
                {
                    
                    item.Value= listDto[i].Value;
                    item.UpdateDate = DateTime.Now;
                    await _unitOfWork.CommitAsyncTask();
                    i++;
                }
                //foreach (var property in dto.Properties)
                //{


                //    var mapped = _mapper.Map<Property>(property);
                //    foreach (var property2 in model)
                //    {
                //        mapped.MaterialId = dto.MaterialId;
                //        mapped.CreateDate = property2.CreateDate;
                //    }
                   
                //    _propertyRepository.Update(mapped);
                //    _unitOfWork.Commit();
                //}
                
                return CustomResponseDto<UpdatePropertyListDto>.Success(200, dto);
            }
            catch (Exception e)
            {
                return CustomResponseDto<UpdatePropertyListDto>.Fail(400, e.Message);
                
            }
            
            
        }
    }
}
