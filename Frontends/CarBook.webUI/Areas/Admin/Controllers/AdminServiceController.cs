using CarBook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.webUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminService")]
    public class AdminServiceController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AdminServiceController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

       
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7015/api/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]

        [Route("CreateService")]
        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateService")]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7015/api/Services", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminService", new { area = "Admin" });
            }
            return View();
        }
        [Route("RemoveService/{id}")]
        public async Task<IActionResult> RemoveService(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7015/api/Services/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminService", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _clientFactory.CreateClient();
            var resposenMessage = await client.GetAsync($"https://localhost:7015/api/Services/{id}");
            if (resposenMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposenMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7015/api/Services/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminService", new { area = "Admin" });
            }
            return View();
        }
    }
}
