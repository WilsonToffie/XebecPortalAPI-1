using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XebecAPI.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using XebecAPI.Shared;
using XebecAPI.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace XebecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "HRAdmin, Super Admin")]
    public class UnsuccessfulReasonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public UnsuccessfulReasonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET: api/<UnsuccessfulReasonController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUnsuccessfulReason()
        {
            try
            {
                var UnsuccessfulReason = await _unitOfWork.UnsuccessfulReasons.GetAll();

                return Ok(UnsuccessfulReason);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<UnsuccessfulReasonController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUnsuccessfulReason(int id)
        {
            try
            {
                var UnsuccessfulReason = await _unitOfWork.UnsuccessfulReasons.GetT(q => q.Id == id);
                return Ok(UnsuccessfulReason);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<UnsuccessfulReasonController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUnsuccessfulReason([FromBody] UnsuccessfulReason unsuccessfulReason)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                await _unitOfWork.UnsuccessfulReasons.Insert(unsuccessfulReason);
                await _unitOfWork.Save();

                return CreatedAtAction("GetUnsuccessfulReason", new { id = unsuccessfulReason.Id }, unsuccessfulReason);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }


        // PUT api/<UnsuccessfulReasonController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUnsuccessfulReason(int id, [FromBody] UnsuccessfulReasonDTO unsuccessfulReason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalUnsuccessfulReason = await _unitOfWork.UnsuccessfulReasons.GetT(q => q.Id == id);

                if (originalUnsuccessfulReason == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                mapper.Map(unsuccessfulReason, originalUnsuccessfulReason);
                _unitOfWork.UnsuccessfulReasons.Update(originalUnsuccessfulReason);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        // DELETE api/<UnsuccessfulReasonController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UnsuccessfulReasonQuestion(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var unsuccessfulReason = await _unitOfWork.UnsuccessfulReasons.GetT(q => q.Id == id);

                if (unsuccessfulReason == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.UnsuccessfulReasons.Delete(id);
                await _unitOfWork.Save();

                return NoContent();


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
    }
}
