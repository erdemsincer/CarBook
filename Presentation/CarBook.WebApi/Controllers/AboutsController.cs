using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
      

        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler,
            UpdateAboutCommandHandler updateAboutCommandHandler,
            RemoveAboutCommandHandler removeAboutCommandHandler,
            GetAboutByIdQueryHandler getAboutByIdQueryHandler,
            GetAboutQueryHandler getAboutQueryHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _removeAboutCommandHandler = removeAboutCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
           
        }
        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var values = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CrateAbout(CreateAboutCommands createAboutCommand)
        {
            await _createAboutCommandHandler.Handle(createAboutCommand);
            return Ok("Hakkımda bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommands(id));
            return Ok("Hakkımda bilgisi silindi");

            }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommands updateAboutCommand)
        {
            await _updateAboutCommandHandler.Handle(updateAboutCommand);
            return Ok("Hakkımda Bilgisi güncellendi");
        }
        }
    }

