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
    [Authorize]
    public class RejectedCandidateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public RejectedCandidateController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET: api/<RejectedCandidateController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRejectedCandidate()
        {
            try
            {
                var RejectedCandidate = await _unitOfWork.RejectedCandidates.GetAll();

                return Ok(RejectedCandidate);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<RejectedCandidateController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRejectedCandidate(int id)
        {
            try
            {
                var RejectedCandidate = await _unitOfWork.RejectedCandidates.GetT(q => q.Id == id);
                return Ok(RejectedCandidate);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        // POST api/<RejectedCandidateController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateRejectedCandidate([FromBody] RejectedCandidate rejectedCandidate)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                await _unitOfWork.RejectedCandidates.Insert(rejectedCandidate);
                await _unitOfWork.Save();

                return CreatedAtAction("GetRejectedCandidate", new { id = rejectedCandidate.Id }, rejectedCandidate);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }


        // PUT api/<RejectedCandidateController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRejectedCandidate(int id, [FromBody] RejectedCandidateDTO rejectedCandidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalRejectedCandidate = await _unitOfWork.RejectedCandidates.GetT(q => q.Id == id);

                if (originalRejectedCandidate == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                mapper.Map(rejectedCandidate, originalRejectedCandidate);
                _unitOfWork.RejectedCandidates.Update(originalRejectedCandidate);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        // DELETE api/<RejectedCandidateController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRejectedCandidate(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var rejectedCandidate = await _unitOfWork.RejectedCandidates.GetT(q => q.Id == id);

                if (rejectedCandidate == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.RejectedCandidates.Delete(id);
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
