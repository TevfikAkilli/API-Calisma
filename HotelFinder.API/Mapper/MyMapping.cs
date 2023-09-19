using AutoMapper;
using HotelFinder.DataAccess.DTO;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API.Mapper
{
    public class MyMapping:Profile
    {
        public MyMapping()
        {
            CreateMap<Hotel, HotelDTO>().ReverseMap();

        }
    }
}
