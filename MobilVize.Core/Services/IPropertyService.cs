
using MobilVize.Core.Dtos;
using MobilVize.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Core.Services
{
    public interface IPropertyService:IGenericService<Property>
    {
        public Task<CustomResponseDto<UpdatePropertyListDto>> UpdatePropertiesAsync(UpdatePropertyListDto dto);
    }
}
