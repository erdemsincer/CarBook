using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        

        public ContactsController(CreateContactCommandHandler createContactCommandHandler,
            UpdateContactCommandHandler updateContactCommandHandler,
            RemoveContactCommandHandler removeContactCommandHandler,
            GetContactByIdQueryHandler getContactByIdQueryHandler,
            GetContactQueryHandler getContactQueryHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var values = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommands commands)
        {
            await _createContactCommandHandler.Handle(commands);
            return Ok("Yeni Contact alanı eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommands commands)
        {
            await _updateContactCommandHandler.Handle(commands);
            return Ok("Contact Alanı Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommands(id));
            return Ok("Contact Alanı Silindi");
        }
    }
}
