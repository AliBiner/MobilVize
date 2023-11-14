using Microsoft.AspNetCore.Mvc;
using MobilVize.Core.Dtos;
using MobilVize.Core.Services;

namespace MobilVize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : CustomBaseController
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdatePropertyListDto dto)
        {
            var result = await _propertyService.UpdatePropertiesAsync(dto);
            return CreateActionResult(result);

        }
    }
}
