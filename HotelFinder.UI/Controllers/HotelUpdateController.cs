using HotelFinder.Entities;
using HotelFinder.UI.APIService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.UI.Controllers
{
    public class HotelUpdateController : Controller
    {
        private readonly HotelAPIService _hotelAPIService;
        public HotelUpdateController(HotelAPIService hotelAPIService)
        {
            _hotelAPIService = hotelAPIService;
        }
        public async Task<IActionResult> HotelUpdate()
        {
            ViewBag.hotellist = new SelectList(await _hotelAPIService.HotelListService(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult HotelUpdate(Hotel hotel)
        {
            
            _hotelAPIService.HotelUpdate(hotel);
            return View();
        }
    }

    
}
