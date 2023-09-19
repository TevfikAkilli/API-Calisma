using HotelFinder.DataAccess.DTO;
using HotelFinder.UI.APIService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.UI.Controllers
{
    public class HotelAddController : Controller
    {
        private readonly HotelAPIService _hotelAPIService;
        public HotelAddController(HotelAPIService hotelAPIService)
        {
            _hotelAPIService = hotelAPIService;
        }


        public IActionResult HotelAdd()
        {
             
            return View();
        }
        [HttpPost]
        public IActionResult HotelAdd( HotelDTO dto)
        {
           ViewBag.eklenenHorel= _hotelAPIService.HotelCreate(dto);
           return View() ;
        }
    }
}
