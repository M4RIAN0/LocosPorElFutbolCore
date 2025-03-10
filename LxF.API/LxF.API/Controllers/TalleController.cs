using Infraestructura;
using IServicio;
using Lxf.Support.BuildingBlocks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace LxF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalleController : ControllerBase
    {
        private readonly LxfContext _db;
        private readonly ITalleServicio _service;

        public TalleController(LxfContext db, ITalleServicio service)
        {
            _db = db;
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetTalles()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetTallesById(int id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetByFilter")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetTallesByFilter(string word)
        {
            var result = _service.GetByFilter(word);
            return Ok(result);
        }

    }
}
