using Microsoft.AspNetCore.Mvc;
using MobilVize.Core.Dtos;
using MobilVize.Core.Services;

namespace MobilVize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : CustomBaseController
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() { 
            var result = await _materialService.GetAllForPreview();
            return CreateActionResult(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddMaterialDto dto) {
            var result = await _materialService.Add(dto);
            return CreateActionResult(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id) {
            var result = await _materialService.GetMaterialWithPropertyById(id);
            return CreateActionResult(result);
        }
    }
}
