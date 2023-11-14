using MobilVize.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Core.Dtos
{
    public class MaterialWithPropertyDto
    {
        public MaterialWithPropertyDto()
        {
            Properties = new List<PropertForPreviewDto>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<PropertForPreviewDto> Properties { get; set; }
        

    }
}
