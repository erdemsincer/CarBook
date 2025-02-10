using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.webUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AdminStatisticsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [Route("Index")]

        public async Task< IActionResult> Index()
        {
            Random random = new Random(); 
            var client=_clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7015/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int v1 = random.Next(0, 101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.v = values.carCount;
                ViewBag.v1=v1;
            }

            var client2 = _clientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("https://localhost:7015/api/Statistics/GetBrandCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int brandCountRandom = random.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.brandCount = values2.brandCount;
                ViewBag.brandCountRandom = brandCountRandom;
            }
            var responseMessage4 = await client.GetAsync("https://localhost:7015/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int blogCountRandom = random.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.blogCount = values4.blogCount;
                ViewBag.blogCountRandom = blogCountRandom;
            }
            var responseMessage5 = await client.GetAsync("https://localhost:7015/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int brandCountRandom = random.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.brandCount = values5.brandCount;
                ViewBag.brandCountRandom = brandCountRandom;
            }

            var responseMessage6 = await client.GetAsync("https://localhost:7015/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int avgRentPriceForDailyRandom = random.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.avgRentPriceForDaily = values6.avgPriceForDaily;
                ViewBag.avgRentPriceForDailyRandom = avgRentPriceForDailyRandom;
            }
            return View();
         
        }
    }
}
