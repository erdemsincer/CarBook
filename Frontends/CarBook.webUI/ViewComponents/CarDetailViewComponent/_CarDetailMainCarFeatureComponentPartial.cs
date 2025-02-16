using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.ViewComponents.CarDetailViewComponent
{
	public class _CarDetailMainCarFeatureComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarDetailMainCarFeatureComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task< IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
