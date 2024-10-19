using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BrandsController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;

        public BrandsController(CreateBrandCommandHandler createBrandCommandHandler,
            UpdateBrandCommandHandler updateBrandCommandHandler,
            RemoveBrandCommandHandler removeBrandCommandHandler, 
            GetBrandByIdQueryHandler getBrandByIdQueryHandler, 
            GetBrandQueryHandler getBrandQueryHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var values = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommands commands)
        {
            await _createBrandCommandHandler.Handle(commands);
            return Ok("Yeni Brand alanı eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommands commands)
        {
            await _updateBrandCommandHandler.Handle(commands);
            return Ok("Brand Alanı Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommands(id));
            return Ok("Brand Alanı Silindi");
        }
    }
}
