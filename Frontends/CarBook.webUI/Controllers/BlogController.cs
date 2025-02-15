using CarBook.Dto.BlogDtos;
using CarBook.Dto.CommentDto;
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
            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync($"https://localhost:7015/api/Comments/GetCountCommentByBlog?id=" + id);
            var jsondata2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.commentCount = jsondata2;
            return View();
        }


        [HttpGet]

        public PartialViewResult AddComment(int id)
        {
            return PartialView();
        }

        [HttpPost]

        public IActionResult AddComment(CreateCommentDto createCommentDto)
        {
            return View();
        }
    }
}
