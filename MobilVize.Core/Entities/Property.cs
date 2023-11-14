using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Core.Entities
{
    public class Property:BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public Guid MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
