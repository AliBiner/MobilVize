using MobilVize.Core.Entities;
using MobilVize.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Repository.Repositories
{
    public class MaterialRepository : GenericRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
