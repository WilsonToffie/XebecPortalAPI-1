using AutoMapper;
using XebecAPI.Data;
using XebecAPI.IRepositories;
using XebecAPI.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.DTOs;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XebecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CollaboratorQuestionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public CollaboratorQuestionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET: api/<CollaboratorQuestionController>
        [HttpGet]
        [Authorize(Roles = "HRAdmin, Super Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCollaboratorQuestions()
        {
            try
            {
                var CollaboratorQuestions = await _unitOfWork.CollaboratorQuestions.GetAll();
             
                return Ok(CollaboratorQuestions);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<CollaboratorQuestionController>/5
        [HttpGet("single/{id}")]
        [Authorize(Roles = "HRAdmin, Super Admin")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingleCollaboratorQuestionById(int id)
        {
            try
            {
                var CollaboratorQuestion = await _unitOfWork.CollaboratorQuestions.GetT(q => q.Id == id);
                return Ok(CollaboratorQuestion);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<CollaboratorQuestionController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCollaboratorQuestion([FromBody] CollaboratorQuestion CollaboratorQuestion)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                await _unitOfWork.CollaboratorQuestions.Insert(CollaboratorQuestion);
                await _unitOfWork.Save();
                return CreatedAtAction("GetCollaboratorQuestion", new { id = CollaboratorQuestion.Id }, CollaboratorQuestion);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }


        // PUT api/<CollaboratorQuestionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCollaboratorQuestion(int id, [FromBody] CollaboratorQuestionDTO CollaboratorQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalCollaboratorQuestion = await _unitOfWork.CollaboratorQuestions.GetT(q => q.Id == id);

                if (originalCollaboratorQuestion == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                mapper.Map(CollaboratorQuestion, originalCollaboratorQuestion);
                _unitOfWork.CollaboratorQuestions.Update(originalCollaboratorQuestion);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        // DELETE api/<CollaboratorQuestionController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCollaboratorQuestion(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var CollaboratorQuestion = await _unitOfWork.CollaboratorQuestions.GetT(q => q.Id == id);

                if (CollaboratorQuestion == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.CollaboratorQuestions.Delete(id);
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
