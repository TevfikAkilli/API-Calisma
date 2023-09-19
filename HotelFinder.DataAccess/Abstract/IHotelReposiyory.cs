using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Abstract
{
    public interface IHotelReposiyory
    {
        List<Hotel> GetAllHotels();

        Hotel GetHotelById(int Id);
        Hotel CreateHotel(Hotel Hotel);
        Hotel UpdateHotel(Hotel hotel);
        void DeleteHotel(int Id);
    }
}
