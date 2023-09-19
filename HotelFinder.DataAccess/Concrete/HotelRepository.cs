using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{

    public class HotelRepository : IHotelReposiyory
    {
        private readonly HotelDbContext _dbcontext;
        public HotelRepository(HotelDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<Hotel> GetAllHotels()
        {
            return _dbcontext.Hotels.ToList();
        }

        public Hotel GetHotelById(int Id)
        {
            return _dbcontext.Hotels.FirstOrDefault(a => a.Id == Id);
            //_dbcontext.Hotels.Find(Id); primary key ile bulma yapıyorsa find methodunu kullanabiliriz

        }

        public void DeleteHotel(int Id)
        {
            var silinecekHotel = GetHotelById(Id);
            _dbcontext.Hotels.Remove(silinecekHotel);
            _dbcontext.SaveChanges();
        }


        public Hotel CreateHotel(Hotel Hotel)
        {
            if (Hotel!=null)
            {
                _dbcontext.Hotels.Add(Hotel);
                _dbcontext.SaveChanges();
                
            }
            else
            {
                
            }
            return Hotel;
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            if (hotel.Id!=null&& hotel.Id!=0)
            {
                _dbcontext.Update(hotel);
                _dbcontext.SaveChanges();
            }
            return hotel;
        }
    }
}
