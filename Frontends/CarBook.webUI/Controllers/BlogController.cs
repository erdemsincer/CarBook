using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.webUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> Index()
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Yazarlarımızın Blogları";
            var client =_httpClientFactory.CreateClient();
            var ResponseMessage = await client.GetAsync("http://localhost:5026/api/Blogs/GetAllBlogsWithAuthorList");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                var jsonData=await ResponseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayı ve yorumlar";
            ViewBag.blogid=id;

            return View();
        }
    }
}
