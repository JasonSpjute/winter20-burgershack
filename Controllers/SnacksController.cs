using System;
using Microsoft.AspNetCore.Mvc;
using burgershack_winter20.Services;
using burgershack_winter20.Models;
using System.Collections.Generic;

namespace burgershack_winter20.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SnacksController : ControllerBase
    {
        private readonly SnackService _service;
        public SnacksController(SnackService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Snack>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Snack> Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public ActionResult<Snack> Create([FromBody] Snack newSnack)
        {
            try
            {
                return Ok(_service.Create(newSnack));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Snack> Edit([FromBody] Snack editSnack, int id)
        {
            try
            {
                editSnack.Id = id;
                return Ok(_service.Edit(editSnack));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Snack> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}