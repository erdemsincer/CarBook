using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.webUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardCarPricingListComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardCarPricingListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7015/api/CarPricing/GetCarPricingWithTimePeriodList");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var carPricingList = JsonConvert.DeserializeObject<List<ResultCarPricingListWithModelDto>>(jsonData);
                return View(carPricingList);
            }
        

            return View();
        }
    }
}
