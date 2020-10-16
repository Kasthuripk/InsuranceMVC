using Online_Insurance.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Insurance.Models
{
    public class RegisterMap
    {
        public static void Map()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<CustomerDetail, User>()
                .ForMember(dest => dest.role, opt => opt.MapFrom(src => "User"));
                config.CreateMap<SignInDetails, User>();
                config.CreateMap<InsuranceDetails, Admin>();
            }
            );
        }
    }
}