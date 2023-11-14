using MobilVize.Core.Dtos;
using MobilVize.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Core.Services
{
    public interface IMaterialService:IGenericService<Material>
    {
        public Task<CustomResponseDto<Material>> Add(AddMaterialDto dto);
        public Task<CustomResponseDto<GetAllMaterialForPreviewDto>> GetAllForPreview();

        public Task<CustomResponseDto<MaterialWithPropertyDto>> GetMaterialWithPropertyById(Guid id);
    }
}
