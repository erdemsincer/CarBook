using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.ViewComponents.AboutViewComponents
{
	public class _BecomeADriverComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _BecomeADriverComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{

		}
	}
}
