using Chat_App.services;
using Chat_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : Controller
    {
        private readonly IContactService _service;
        private readonly Chat_App.services.FireBaseService _firebase;

        public TransferController(ContactService service, FireBaseService fireBaseService)
        {
            _service = service;
            _firebase = fireBaseService;
        }

        [HttpPost]
        public IActionResult Create([Bind("From,To,Content")] Transfer transfer)
        {
            if (transfer.From == null)
            {
                return NotFound();
            }

            var contact = _service.Get(transfer.From);

            if (contact == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                int id2 = _service.CreateMessageFrom(transfer.To, transfer.From, transfer.Content);
                if (_firebase.getToken(transfer.To) != null)
                {
                    _firebase.SendNotification(_firebase.getToken(transfer.To),
                        "New Message", transfer.From + " says: " + transfer.Content);
                }
                return Created(String.Format("/api/contact/{0}/messages/{0}", transfer.From, id2), _service.GetMessage(transfer.From, id2));

            }
            return BadRequest();
        }
    }
}
