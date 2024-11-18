using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroErp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactRepository _contactRepository;

        public ContactsController(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Contacts>> GetContacts()
        {
            var contacts = await _contactRepository.GetContactsAsync();

            return contacts ?? Enumerable.Empty<Contacts>();
        }

        [HttpPost]
        public async Task<ActionResult> AddContact([FromBody] Contacts contact)
        {
            if (contact == null)
            {
                return BadRequest("Contact data is null.");
            }

            try
            {

                contact.CreatedAt = DateTime.UtcNow;
                contact.ModifiedAt = DateTime.UtcNow;

                await _contactRepository.AddContactAsync(contact);
                return CreatedAtAction(nameof(GetContacts), new { id = contact.Id }, contact);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error adding contact: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    }
}
