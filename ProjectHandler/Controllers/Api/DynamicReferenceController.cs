using AutoMapper;
using ProjectHandler.Models;
using ProjectHandler.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectHandler.Controllers.Api
{
    public class DynamicReferenceController : ApiController
    {
        private ApplicationDbContext _context;

        public DynamicReferenceController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetDynamicReferences()
        {
            return Ok(_context.DynamicReferences
                      .Include(d => d.Question)
                      .ToList()
                      .Select(Mapper.Map<DynamicReference, DynamicReferenceDTO>));
        }
        [HttpGet]
        public IHttpActionResult GetDynamicReference(int id)
        {
            var dynamicReference = _context
                .DynamicReferences
                .Include(d => d.Question)
                .SingleOrDefault(d => d.Id == id);
            if (dynamicReference == null)
                return NotFound();
            return Ok(Mapper.Map<DynamicReference, DynamicReferenceDTO>(dynamicReference));
        }

        [HttpPost]
        public IHttpActionResult CreateDynamicReference(DynamicReferenceDTO dynamicReferenceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dynamicReference = Mapper.Map<DynamicReferenceDTO, DynamicReference>(dynamicReferenceDto);
            _context.DynamicReferences.Add(dynamicReference);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + dynamicReference.Id), dynamicReference);
        }

        [HttpPut]
        public void UpdateDynamicReference(int id, DynamicReferenceDTO dynamicReferenceDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var dynamicReferenceInDb = _context.DynamicReferences.SingleOrDefault(d => d.Id == id);

            if (dynamicReferenceInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(dynamicReferenceDto, dynamicReferenceInDb);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteDynamicReference(int id)
        {
            var dynamicReferenceInDb = _context.DynamicReferences.SingleOrDefault(d => d.Id == id);

            if (dynamicReferenceInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.DynamicReferences.Remove(dynamicReferenceInDb);
            _context.SaveChanges();
        }
    }
}
