using AutoMapper;
using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_Data_Access.Domain;
using MyGalaxy_Auction_Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGalaxy_Auction_Buiness.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateVehicleDtos,Vehicle>().ReverseMap();
            CreateMap<UpdateVehicleDtos,Vehicle>().ReverseMap();
        }
    }
}
