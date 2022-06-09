using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.IRepositories;
using XebecAPI.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XebecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobAlertController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public JobAlertController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET: api/<JobAlertController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetJobAlerts()
        {
            try
            {
                var JobAlerts = await _unitOfWork.JobAlerts.GetAll();

                return Ok(JobAlerts);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<JobAlertController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetJobAlert(int id)
        {
            try
            {
                var JobAlert = await _unitOfWork.JobAlerts.GetT(q => q.Id == id);
                return Ok(JobAlert);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<JobAlertController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateJobAlert([FromBody] JobAlert JobAlert)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                await _unitOfWork.JobAlerts.Insert(JobAlert);
                await _unitOfWork.Save();

                return CreatedAtAction("GetJobAlert", new { id = JobAlert.Id }, JobAlert);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }
        }

        // PUT api/<JobAlertController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJobAlert(int id, [FromBody] JobAlert jobsArlet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalJobAlert = await _unitOfWork.JobAlerts.GetT(q => q.Id == id);

                if (originalJobAlert == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                mapper.Map(jobsArlet, originalJobAlert);
                _unitOfWork.JobAlerts.Update(originalJobAlert);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        // DELETE api/<JobAlertController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteJobAlert(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var JobAlert = await _unitOfWork.JobAlerts.GetT(q => q.Id == id);

                if (JobAlert == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.JobAlerts.Delete(id);
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
