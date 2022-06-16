using Chat_App.services;
using Chat_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class invitationsController : Controller
    {
        private readonly IContactService _service;

        public invitationsController(ContactService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create([Bind("From,To,Server")] Invitations invitation)
        {
            if (invitation.From == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.UserCreate(invitation.From, invitation.From, invitation.Server, invitation.To);
                return NoContent();
            }
            return BadRequest();
        }
    }
}
