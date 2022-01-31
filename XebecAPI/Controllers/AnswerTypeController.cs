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

namespace XebecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public AnswerTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET: api/<AdditionalInformationController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAnswerTypes()
        {
            try
            {
                var Type = await _unitOfWork.AnswerTypes.GetAll();

                return Ok(Type);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<AdditionalInformationController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAnswerType(int id)
        {
            try
            {
                var Type = await _unitOfWork.AnswerTypes.GetT(q => q.Id == id);
                return Ok(Type);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<AdditionalInformationController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateType([FromBody] AnswerType Type)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                await _unitOfWork.AnswerTypes.Insert(Type);
                await _unitOfWork.Save();

                return CreatedAtAction("GetType", new { id = Type.Id }, Type);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }


        // PUT api/<AdditionalInformationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateType(int id, [FromBody] AnswerTypeDTO Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalType = await _unitOfWork.AnswerTypes.GetT(q => q.Id == id);

                if (originalType == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                mapper.Map(Type, originalType);
                _unitOfWork.AnswerTypes.Update(originalType);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        // DELETE api/<AdditionalInformationController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteType(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var Type= await _unitOfWork.AnswerTypes.GetT(q => q.Id == id);

                if (Type == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.AnswerTypes.Delete(id);
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
