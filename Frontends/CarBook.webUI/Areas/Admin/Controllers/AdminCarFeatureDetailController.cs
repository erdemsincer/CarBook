﻿using CarBook.Dto.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.webUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
        [HttpGet]
        public async Task< IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7015/api/CarFeatures?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> _resultCarFeatureByCarIdDtos)
        {
            foreach (var item in _resultCarFeatureByCarIdDtos)
            {
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    var responseMessage = await client.GetAsync("https://localhost:7015/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureID);
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    var responseMessage = await client.GetAsync("https://localhost:7015/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureID);
                }


            }
            return RedirectToAction("Index", "AdminCar");
        }
        }
        }
