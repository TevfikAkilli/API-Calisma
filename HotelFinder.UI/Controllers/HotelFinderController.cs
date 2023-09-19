using HotelFinder.Bussines.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using HotelFinder.UI.APIService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelFinder.UI.Controllers
{
    public class HotelFinderController : Controller
    { 
        private readonly HotelAPIService _apiService;
        public HotelFinderController(  HotelAPIService aPIService)
        { 
            _apiService = aPIService;
        }
        public async Task<IActionResult> HotelList()
        {
                        
           ViewBag.HotelListAll= await _apiService.HotelListService();
            return View();
        }

        public IActionResult HotelAdd()
        {
            return View();
        }
    }
}
