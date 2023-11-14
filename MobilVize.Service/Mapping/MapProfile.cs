using AutoMapper;
using MobilVize.Core.Dtos;
using MobilVize.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilVize.Service.Mapping
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<SignupDto, User>();
            CreateMap<LoginDto,User >();
            CreateMap<User, LoginSuccessDto>();
            CreateMap<User,UpdateUserDto>().ReverseMap();
            CreateMap<AddMaterialDto, Material>();
            CreateMap<Material, GetAllMaterialForPreviewDto>();
            CreateMap<Material, MaterialWithPropertyDto>();
            CreateMap<Property,PropertForPreviewDto>();
            CreateMap<UpdatePropertyDto, Property>();
        }
    }
}
