using AutoMapper;
using OilShop.Entities;
using OilShop.Models.Oil;
using OilShop.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilShop.Mappers
{
    public class Automapper: Profile
    {
        public Automapper()
        {
            CreateMap<Oil, ReplaceOilViewModel>();
            CreateMap<ReplaceOilViewModel, Oil>();
            CreateMap<Oil, OilViewModel>();
            CreateMap<RegisterViewModel, DbUser>()
                .ForMember("FullName",opt=>opt.MapFrom(x=>x.UserName))
                .ForMember("UserName", opt=>opt.MapFrom(x=>x.Email));
        }
    }
}
