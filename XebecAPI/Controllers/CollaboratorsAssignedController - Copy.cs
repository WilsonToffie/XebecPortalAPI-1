using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.DTOs;
using XebecAPI.IRepositories;
using XebecAPI.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XebecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateRecommenderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public CandidateRecommenderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        // GET: api/<CandidatesRecommenderController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCandidatesRecommender()
        {
            try
            {
                var CandidatesRecommender = await _unitOfWork.CandidatesRecommender.GetAll();

                return Ok(CandidatesRecommender);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<CandidatesRecommenderController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCandidatesRecommender(int id)
        {
            try
            {
                var CandidatesRecommender = await _unitOfWork.CandidatesRecommender.GetT(q => q.Id == id);
                return Ok(CandidatesRecommender);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<CandidatesRecommenderController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCandidatesRecommender([FromBody] CandidateRecommender CandidatesRecommender)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                await _unitOfWork.CandidatesRecommender.Insert(CandidatesRecommender);
                await _unitOfWork.Save();

                return CreatedAtAction("GetCandidatesRecommender", new { id = CandidatesRecommender.Id }, CandidatesRecommender);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }

        // PUT api/<CandidatesRecommenderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCandidatesRecommender(int id, [FromBody] CandidateRecommenderDTO CandidatesRecommender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalAdditionalInformation = await _unitOfWork.CandidatesRecommender.GetT(q => q.Id == id);

                if (originalAdditionalInformation == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                mapper.Map(CandidatesRecommender, originalAdditionalInformation);
                _unitOfWork.CandidatesRecommender.Update(originalAdditionalInformation);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }



        // DELETE api/<CandidatesRecommenderController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCandidatesRecommender(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var AdditionalInformation = await _unitOfWork.CandidatesRecommender.GetT(q => q.Id == id);

                if (AdditionalInformation == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.AdditionalInformation.Delete(id);
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
