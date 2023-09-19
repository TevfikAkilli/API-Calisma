using HotelFinder.DataAccess.DTO;
using HotelFinder.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HotelFinder.UI.APIService
{
    public class HotelAPIService
    {
        private readonly HttpClient _httpClient;
        public HotelAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Hotel>> HotelListService()
        {
            List<Hotel> hotelList = null;
            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:10948/api/hotels");
            if (response.IsSuccessStatusCode)
            {
                var jasonResponse = await response.Content.ReadAsStringAsync();
                hotelList = JsonConvert.DeserializeObject<List<Hotel>>(jasonResponse);

            }

            return hotelList;

        }

        public async Task<Hotel> HotelCreate(HotelDTO dto)
        {
            Hotel hotel = null;
            var eklenecekDto = new StringContent(JsonConvert.SerializeObject(dto));
            eklenecekDto.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:10948/api/hotels/add", eklenecekDto);
            if (response.IsSuccessStatusCode)
            {
                var jsonresponse = await response.Content.ReadAsStringAsync();
                hotel = JsonConvert.DeserializeObject<Hotel>(jsonresponse);
            }
            if (!response.IsSuccessStatusCode)
            {


                throw new ApplicationException($"Error {response.StatusCode}: {response.ReasonPhrase}");

            }

            return hotel;
        }



        public async Task HotelDelete(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:10948/api/Hotels/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Error {response.StatusCode}: {response.ReasonPhrase}");
            }
        }


        public async Task<Hotel> HotelUpdate(Hotel hotel)

        {
            var updateData = new StringContent(JsonConvert.SerializeObject(hotel));
            updateData.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await _httpClient.PutAsync("http://localhost:10948/api/Hotels", updateData);
            if (response.IsSuccessStatusCode)
            {
                var jsonresponse = await response.Content.ReadAsStringAsync();
                hotel = JsonConvert.DeserializeObject<Hotel>(jsonresponse);
            }
            return hotel;


        }
    }
}
