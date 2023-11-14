using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Core.Entities
{
    public class Material:BaseEntity
    {
        public Material()
        {
            Properties = new List<Property>();
        }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public IList<Property> Properties { get; set; }

    }
}
