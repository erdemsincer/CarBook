using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;

using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;

        public BannersController(CreateBannerCommandHandler createBannerCommandHandler, 
            UpdateBannerCommandHandler updateBannerCommandHandler, 
            RemoveBannerCommandHandler removeBannerCommandHandler, 
            GetBannerByIdQueryHandler getBannerByIdQueryHandler,
            GetBannerQueryHandler getBannerQueryHandler)
        {
            _createBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getBannerQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var values=await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommands createBannerCommands)
        {
            await _createBannerCommandHandler.Handle(createBannerCommands);
            return Ok("Yeni Banner Alanı Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommands(id));
            return Ok("Banner Alanı Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommands updateBannerCommands)
        {
            await _updateBannerCommandHandler.Handle(updateBannerCommands);
            return Ok("Banner Alanı Güncellendi");
        }
    }
}
