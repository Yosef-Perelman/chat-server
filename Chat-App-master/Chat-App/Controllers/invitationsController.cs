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
        private readonly Chat_App.services.FireBaseService _firebase;

        public invitationsController(ContactService service, FireBaseService fireBaseService)
        {
            _service = service;
            _firebase = fireBaseService;
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
                if (_firebase.getToken(invitation.To) != null)
                {
                    _firebase.SendNotification(_firebase.getToken(invitation.To),
                        "New Contact", invitation.From + " wants to talk with you");
                }
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost("{user}/{token}")]
        public IActionResult addToken(string user, string token)
        {
            _firebase.addToken(user, token);
            return NoContent();
        }
       
    }
}
