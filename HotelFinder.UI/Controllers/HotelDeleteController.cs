using HotelFinder.Entities;
using HotelFinder.UI.APIService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.UI.Controllers
{
    public class HotelDeleteController : Controller
    {
        private readonly HotelAPIService _hotelAPIService;
        public HotelDeleteController(HotelAPIService hotelAPIService)
        {
            _hotelAPIService = hotelAPIService;
        }
        public async Task< IActionResult> HotelDelete()
        {
             var Hotels = await _hotelAPIService.HotelListService();

             ViewBag.hotelList =  new SelectList(Hotels, "Id", "Name");

            return View();
        }
        [HttpPost]
        public IActionResult HotelDelete(int Id)
        {
            _hotelAPIService.HotelDelete(Id);

          return  RedirectToAction("HotelDelete");
        }
    }
}
