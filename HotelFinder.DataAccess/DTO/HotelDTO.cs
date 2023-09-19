using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.DTO
{
       public class HotelDTO
        {
            public int Id { get; set; } 
            public string Name { get; set; }
        
            public string City { get; set; }
            public Hotel Hotel { get; set; }
        }
}
