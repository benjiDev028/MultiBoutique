using AutoMapper;
using IdentityBusiniessLogic.DTO;
using IdentityDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityBusinessLogic.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {

        CreateMap<UserDto,User>().ReverseMap();
                
        }
    }

}
