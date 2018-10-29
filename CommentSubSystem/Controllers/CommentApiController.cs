using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T120B143.Models;

namespace T120B143.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentApiController : ControllerBase
    {

        private readonly IDb _service;

        public CommentApiController(IDb service)
        {
            _service = service;
        }

        [Route("Like/{id}")]
        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            try
            {
                if (await _service.Like(id))
                {
                    return Ok();
                }
                else
                {
                    var message = string.Format("Comment with id = {0} not found", id);
                    var err = new HttpError(message);
                    return NotFound(err);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("Dislike/{id}")]
        [HttpPost]
        public async Task<IActionResult> Dislike(int id)
        {
            try
            {
                if (await _service.Dislike(id))
                {
                    return Ok();
                }
                else
                {
                    var message = string.Format("Comment with id = {0} not found", id);
                    var err = new HttpError(message);
                    return NotFound(err);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("Add/")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CommentJson com)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Wrong model");
                }

                if (await _service.Add(com))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
