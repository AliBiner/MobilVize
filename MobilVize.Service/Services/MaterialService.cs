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
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Service.Services
{
    public class MaterialService : GenericService<Material>, IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MaterialService(IGenericRepository<Material> repository, IUnitOfWork unitOfWork, IMaterialRepository materialRepository, IMapper mapper, IPropertyRepository propertyRepository) : base(repository, unitOfWork)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
            _propertyRepository = propertyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<Material>> Add(AddMaterialDto dto)
        {
            try
            {
                var mapped = _mapper.Map<Material>(dto);
                mapped.Id = Guid.NewGuid();
                mapped.CreateDate = DateTime.Now;
                mapped.IsActive=true;
                mapped.UpdateDate = DateTime.Now;
                await AddAsyncTask(mapped);
                
                foreach (var item in dto.PropertyName)
                {
                    var prop = new Property { Id = Guid.NewGuid(),Name=item,MaterialId=mapped.Id,CreateDate=DateTime.Now,UpdateDate=DateTime.Now };
                    await _propertyRepository.AddAsyncTask(prop);
                    
                }
                
                return CustomResponseDto<Material>.Success(200);
            }
            catch (Exception e)
            {
                return CustomResponseDto<Material>.Fail(400,e.Message);
                
            }
            

        }

        public async Task<CustomResponseDto<GetAllMaterialForPreviewDto>> GetAllForPreview()
        {
            var listModel = WhereQueryable(x=>x.IsActive==true).ToList();
            var mapped = _mapper.Map< IEnumerable < Material > ,IEnumerable<GetAllMaterialForPreviewDto>>(listModel);
            return CustomResponseDto<GetAllMaterialForPreviewDto>.Success(200, mapped);
        }

        public async Task<CustomResponseDto<MaterialWithPropertyDto>> GetMaterialWithPropertyById(Guid id)
        {
            try
            {
                var material = await WhereQueryable(x => x.Id == id).Include(x=>x.Properties).SingleOrDefaultAsync();
                var mapped = _mapper.Map<MaterialWithPropertyDto>(material);
                return CustomResponseDto<MaterialWithPropertyDto>.Success(200, mapped);
            }
            catch (Exception e)
            {
                return CustomResponseDto<MaterialWithPropertyDto>.Fail(400, e.Message);
               
            }
           
           
        }
    }
}
