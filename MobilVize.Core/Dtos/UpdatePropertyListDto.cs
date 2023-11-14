using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Core.Dtos
{
    public class UpdatePropertyListDto
    {
        public UpdatePropertyListDto()
        {
            Properties = new List<UpdatePropertyDto>();
        }
        public Guid MaterialId { get; set; }
        public List<UpdatePropertyDto> Properties { get; set; }
    }
}
