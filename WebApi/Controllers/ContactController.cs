using Infrustructure.Services;

namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Domain.Dtos;
[ApiController]
[Route("[controller]")]
public class ContactController :ControllerBase
{
        private ContactServices _contactServices;

        public ContactController()
        {
                _contactServices = new ContactServices();
                
        }
        [HttpGet("GetContact")]
        public List<Contact> GetContact()
        {
                return  _contactServices.GetContact();
        }
        [HttpPut("UpdateContact")]
        public bool UpdateCategori(Contact contact)
        {
                return  _contactServices.UpdateContact(contact);
      
        }
        [HttpPost("AddContact")]
        public bool Add(Contact contact)
        {
                return _contactServices.AddContact(contact);
        }
        [HttpDelete("Delete")]
        public bool Delete(int id)
        {
                return _contactServices.DeleteContact(id);
        }
        [HttpGet("FindByName")]
        public List<Contact> FindByName(string name)
        {
                return _contactServices.FindByName(name);
        }
        
}]