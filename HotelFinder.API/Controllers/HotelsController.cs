using AutoMapper;
using HotelFinder.Bussines.Abstract;
using HotelFinder.DataAccess.DTO;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;
        public HotelsController(IHotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }
        [HttpGet]
        public List<Hotel> Get()
        {
            return _hotelService.GetAllHotels();
        }
        [HttpGet("{id}")]
        public Hotel Get(int id)
        {
            return _hotelService.GetHotelById(id);
        }
        [HttpPost("add")]
        public Hotel Post([FromBody] HotelDTO hoteldto)
        {
            var hotelDtoTipineDonusanDeger = _mapper.Map<Hotel>(hoteldto);
            return _hotelService.CreateHotel(hotelDtoTipineDonusanDeger);
        }

        [HttpPut]
        public Hotel Put([FromBody] Hotel hotel)
        {
            return _hotelService.UpdateHotel(hotel);
        }

        [HttpDelete("{id}")]
        public void Delete(int Id)
        {
            _hotelService.DeleteHotel(Id);
        }
    }
}
