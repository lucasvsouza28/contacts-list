using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ContactsList.Infrasctructure.Repositories.Abstract;
using ContactsList.Infrasctructure.Model;  
using Microsoft.EntityFrameworkCore;

namespace ContactsList.Controllers
{
    [Route("/api/{controller}")]
    public class ContactsController : Controller
    {
        IContactsRepository Repo;
        IContactInfoRepository InfoRepo;

        public ContactsController(IContactsRepository _repo, IContactInfoRepository _infoRepo)
        {
            this.Repo = _repo;
            this.InfoRepo = _infoRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(this.Repo.GetAll());
        }

        private IActionResult ValidateContactRequest(int id) 
        {
            var contact = this.Repo.GetById(id);

            if (contact == null)
                return StatusCode(400, "Contato não encontrado");

            return null;
        }

        private IActionResult ValidateContactInfoRequest(int id) 
        {
            var contact = this.InfoRepo.GetById(id);

            if (contact == null)
                return StatusCode(400, "Detalhe do contato não encontrado");

            return null;
        }


        [HttpPost]
        public IActionResult Create([FromBody]Contact contact)
        {
            this.Repo.Insert(contact);

            return Json(contact);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Json(this.Repo.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var validationResult = this.ValidateContactRequest(id);
            if (validationResult != null)
                return validationResult;

            this.Repo.DeleteById(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Contact contact)
        {
            var validationResult = this.ValidateContactRequest(id);
            if (validationResult != null)
                return validationResult;
            
            if (id != contact.Id)
                return StatusCode(500, "Requisição inválida");

            this.Repo.Update(contact);

            return Json(contact);
        }

        [HttpGet("{id}/info")]
        public IActionResult GetContactInfos(int id)
        {
            var validationResult = this.ValidateContactRequest(id);
            if (validationResult != null)
                return validationResult;

            var contact = this.Repo.GetById(id, "Infos");
            
            return Json(contact.Infos);
        }

        [HttpDelete("{id}/info/{infoId}")]
        public IActionResult DeleteContactInfo(int infoId)
        {
            var validationResult = this.ValidateContactInfoRequest(infoId);            
            if (validationResult != null)
                return validationResult;

            this.InfoRepo.DeleteById(infoId);
            
            return Ok();
        }

        [HttpPut("{id}/info/{infoId}")]
        public IActionResult UpdateContactInfo(int infoId, [FromBody]ContactInfo info)
        {
            var validationResult = this.ValidateContactInfoRequest(infoId);            
            if (validationResult != null)
                return validationResult;

            this.InfoRepo.Update(info);
            
            return Ok();
        }
    }
}
