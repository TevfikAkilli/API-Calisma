using AutoMapper;
using HotelFinder.Bussines.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.DTO;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Bussines.Concrete
{
    public class HotelMenager : IHotelService
    {
        private readonly IHotelReposiyory _hotelReposiyory;
         
        public HotelMenager(IHotelReposiyory hotelReposiyory )
        {
            _hotelReposiyory = hotelReposiyory;
             
        }
        public Hotel CreateHotel(Hotel  Hotel)
        {
           
          return  _hotelReposiyory.CreateHotel(Hotel);
             
        }

        public void DeleteHotel(int Id)
        {
            _hotelReposiyory.DeleteHotel(Id);
        }

        public List<Hotel> GetAllHotels()
        {
            return _hotelReposiyory.GetAllHotels() ;
        }

        public Hotel GetHotelById(int Id)
        {
            return _hotelReposiyory.GetHotelById(Id) ;
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
           return _hotelReposiyory.UpdateHotel(hotel);
        }
    }
}
