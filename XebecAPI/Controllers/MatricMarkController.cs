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
    [Authorize]
    [ApiController]
    public class MatricMarkController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public MatricMarkController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET: api/<MatricMarkController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMatricMarks()
        {
            try
            {
                var MatricMark = await _unitOfWork.MatricMarks.GetAll();
             
                return Ok(MatricMark);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<MatricMarkController>/5
        [HttpGet("single/{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMatricMark(int id)
        {
            try
            {
                var MatricMark = await _unitOfWork.MatricMarks.GetT(q => q.Id == id);
                return Ok(MatricMark);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<MatricMarkController>/userId=1
        [HttpGet("all/{userId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMatricMarkByUserId(int userId)
        {
            try
            {
                var MatricMark = await _unitOfWork.MatricMarks.GetAll(q => q.AppUserId == userId);
                return Ok(MatricMark);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        //get by appuserid
        // GET api/<MatricMarkController>/5
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingleMatricMarkByUserID(int id)
        {
            try
            {
                var MatricMark = await _unitOfWork.MatricMarks.GetT(q => q.AppUserId == id);
                return Ok(MatricMark);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<MatricMarkController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateMatricMark([FromBody] MatricMark MatricMark)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                await _unitOfWork.MatricMarks.Insert(MatricMark);
                await _unitOfWork.Save();

                return CreatedAtAction("GetMatricMark", new { id = MatricMark.Id }, MatricMark);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }

        [HttpPost("List")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateMatricMarks([FromBody] List<MatricMark> MatricMark)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {
              
                    await _unitOfWork.MatricMarks.InsertRange(MatricMark);
                    await _unitOfWork.Save();

                   
             

                return CreatedAtAction("GetMatricMarks", MatricMark);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }



        // PUT api/<MatricMarkController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatricMark(int id, [FromBody] MatricMarkDTO MatricMark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalMatricMark = await _unitOfWork.MatricMarks.GetT(q => q.Id == id);

                if (originalMatricMark == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                mapper.Map(MatricMark, originalMatricMark);
                _unitOfWork.MatricMarks.Update(originalMatricMark);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        // DELETE api/<MatricMarkController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteMatricMark(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var MatricMark = await _unitOfWork.MatricMarks.GetT(q => q.Id == id);

                if (MatricMark == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.MatricMarks.Delete(id);
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
