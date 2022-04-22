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
    public class JobTypeHelperController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public JobTypeHelperController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET: api/<JobTypeHelpersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetJobTypeHelpers()
        {
            try
            {
                var JobTypeHelpers = await _unitOfWork.JobTypeHelpers.GetAll();
             
                return Ok(JobTypeHelpers);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<JobTypeHelpersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetJobTypeHelper(int id)
        {
            try
            {
                var JobTypeHelper = await _unitOfWork.JobTypeHelpers.GetT(q => q.Id == id);
                return Ok(JobTypeHelper);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("job/{jobId}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetJobTypeHelperbyJob(int jobId)
        {
            try
            {

                var jobTypeHelpers = await _unitOfWork.JobTypeHelpers.GetAll(q => q.JobId == jobId);

                return Ok(jobTypeHelpers);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<JobTypeHelperController>
        [HttpPost]
        [Authorize(Roles = "HRAdmin, Super Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateJobTypeHelper([FromBody] JobTypeHelper JobTypeHelper)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                await _unitOfWork.JobTypeHelpers.Insert(JobTypeHelper);
                await _unitOfWork.Save();

                return CreatedAtAction("GetJobTypeHelper", new { id = JobTypeHelper.Id }, JobTypeHelper);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }

        // POST api/<JobTypeHelperController>/list
        [HttpPost("list")]
        [Authorize(Roles = "HRAdmin, Super Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateJobTypeHelper([FromBody] List<JobTypeHelper> types)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            try
            {
                await _unitOfWork.JobTypeHelpers.InsertRange(types);

                await _unitOfWork.Save();

                return Ok(types);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }


        // PUT api/<JobTypeHelpersController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "HRAdmin, Super Admin")]
        public async Task<IActionResult> UpdateJobTypeHelper(int id, [FromBody] JobTypeHelperDTO JobTypeHelper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalJobTypeHelper = await _unitOfWork.JobTypeHelpers.GetT(q => q.Id == id);

                if (originalJobTypeHelper == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                mapper.Map(JobTypeHelper, originalJobTypeHelper);
                _unitOfWork.JobTypeHelpers.Update(originalJobTypeHelper);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        // DELETE api/<JobTypeHelpersController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "HRAdmin, Super Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteJobTypeHelper(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var JobTypeHelper = await _unitOfWork.JobTypeHelpers.GetT(q => q.Id == id);

                if (JobTypeHelper == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.JobTypeHelpers.Delete(id);
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
