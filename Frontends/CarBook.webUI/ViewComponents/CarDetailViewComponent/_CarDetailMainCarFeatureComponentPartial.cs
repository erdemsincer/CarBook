using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.webUI.ViewComponents.CarDetailViewComponent
{
	public class _CarDetailMainCarFeatureComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarDetailMainCarFeatureComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.carId = id;

			var client = _httpClientFactory.CreateClient(); 
			var responseMessage = await client.GetAsync($"https://localhost:7015/api/Cars/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var carDetail = JsonConvert.DeserializeObject<ResultCarWithBrandsDtos>(jsonData); 
				return View(carDetail);
			}

			return View();
		}
	}
}
