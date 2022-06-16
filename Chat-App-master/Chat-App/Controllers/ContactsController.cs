using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chat_App.Data;
using Chat_App.Models;
using Chat_App.services;

namespace Chat_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class contactsController : Controller
    {
        private readonly IContactService _service;

        public contactsController(ContactService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return Json(_service.GetAll());
        }

        [HttpGet("{user}")]
        public IActionResult AllUserContacts(string user)
        {
            return Json(_service.UserGetAll(user));
        }


        [HttpGet("{user}/{id}")]
        public IActionResult Details(string user, string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _service.UserGet(user, id);

            if (contact == null)
            {
                return NotFound();
            }

            return Json(contact);
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,Name,Server")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _service.Create(contact.Id, contact.Name, contact.Server);
                return Created(String.Format("/api/contact/{0}", contact.Id), contact);
            }
            return BadRequest();
        }

        [HttpPost("{user}")]
        public IActionResult UserCreate(string user, [Bind("Id,Name,Server")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _service.UserCreate(contact.Id, contact.Name, contact.Server, user);
                return Created(String.Format("/api/contact/{0}", contact.Id), contact);
            }
            return BadRequest();
        }

        [HttpPut("{user}/{id}")]
        public IActionResult Edit(string user, string id, [Bind("Name,Server")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                    return NotFound();
                if (_service.UserGet(user, id) == null)
                    return NotFound();
                _service.UserEdit(user, id, contact.Name, contact.Server);
                return NoContent();
            }
            return BadRequest();
        }


        [HttpDelete("{user}/{id}")]
        public IActionResult DeleteConfirmed(string user, string id)
        {
            if (_service.Get(id) == null)
            {
                return NotFound();
            }
            var contact = _service.UserGet(user, id);
            if (contact != null)
            {
                _service.UserDelete(user, id);
            }
            return NoContent();
        }

        [HttpGet("{user}/{id}/messages")]
        public IActionResult MessagesDetails(string user, string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _service.UserGet(user, id);

            if (contact == null)
            {
                return NotFound();
            }

            return Json(_service.UserGetAllMessages(user, id));
        }

        [HttpGet("{id}/messages/{id2}")]
        public IActionResult Message(string id, int id2)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _service.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            if (id2 == null)
            {
                return NotFound();
            }

            var message = contact.Messages.Find(c => c.Id == id2);

            if (message == null)
            {
                return NotFound();
            }
            return Json(_service.GetMessage(id, id2));
        }

        [HttpDelete("{id}/messages/{id2}")]
        public IActionResult DeleteMessage(string id, int id2)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _service.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            if (id2 == null)
            {
                return NotFound();
            }

            _service.DeleteMessage(id, id2);
            return NoContent();
        }


        [HttpPost("{user}/{id}/messages")]
        public IActionResult CreateMessage(string user, string id, [Bind("Content")] Message message)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _service.UserGet(user, id);

            if (contact == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                int id2 = _service.UserCreateMessage(user, id, message.Content);
                return Created(String.Format("/api/contact/{0}/messages/{0}", id, id2), _service.GetMessage(id, id2));
            }
            return BadRequest();
        }

        [HttpPut("{id}/messages/{id2}")]
        public IActionResult EditMessage(string id, int id2, [Bind("Content")] Message message)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _service.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            if (id2 == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.EditMessage(id, id2, message.Content);
                return NoContent();
            }
            return BadRequest();
        }
    }
}
