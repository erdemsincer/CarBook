using CarBook.Dto.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.webUI.ViewComponents.UILayoutComponents
{
    public class _FooterUILayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync() {

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7015/api/FooterAddresses");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var footerAddresses = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(responseString);
                return View(footerAddresses);
            }
            return View(); 
        }
    }
}
