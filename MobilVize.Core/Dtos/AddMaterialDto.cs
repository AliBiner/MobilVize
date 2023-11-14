using MobilVize.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Core.Dtos
{
    public class AddMaterialDto
    {
        public string Name { get; set; }
        public List<string> PropertyName { get; set; }
    }
}
