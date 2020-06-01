using Business.Interfaces;
using Business.Interfaces.Models;
using Business.Interfaces.Models.Note;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Attributes;

namespace WebAPI.Controllers.v1
{
    [Route("api/v1/notes")]
    public class NotesController : ApiController
    {

        private readonly INoteService _noteService;
        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }
  
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = _noteService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetDetails(Guid id)
        {
            var result = _noteService.GetDetails(id);
            return Ok(result);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IHttpActionResult> Create([FromBody]CreateNoteRequest request)
        {
            var id = await _noteService.Create(request);
            return Ok(id);
        }

        [HttpPut]
        [Route("{id}")]
        [ValidateModel]
        public async Task<IHttpActionResult> Update(Guid id, [FromBody]UpdateNoteRequest request)
        {
            request.Id = id;
            await _noteService.Update(request);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            await _noteService.Delete(id);
            return Ok();
        }
    }
}