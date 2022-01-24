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
using XebecAPI.Shared.Security;
using XebecAPI.DTOs;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XebecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperAssignedController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        private readonly IUsersCustomRepo usersCustomRepo;

        public DeveloperAssignedController(IUnitOfWork unitOfWork, IMapper mapper, IUsersCustomRepo usersCustomRepo)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.usersCustomRepo = usersCustomRepo;
        }

        // GET: api/<UsersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDevelopersAssigned()
        {
            try
            {
                var users = await _unitOfWork.DevelopersAssigned.GetAll();

                return Ok(users);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDeveloperAssigned(int id)
        {
            try
            {
                var user = await _unitOfWork.DevelopersAssigned.GetT(q => q.Id == id);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<UserController>/role=candidate


        // POST api/<UsersController>
        [HttpPost("jobId")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateJobApplicationPhase(int jobId, int userId, [FromBody] int[] listofId)
        {
            List<DeveloperAssigned> jobApplicationPhase = new List<DeveloperAssigned>();

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                //var jobs = _unitOfWork.Jobs.GetAll();
                //var job = jobs.Result.LastOrDefault();
                
                foreach (var items in listofId)
                {
                    jobApplicationPhase.Add(new DeveloperAssigned
                    {
                        JobId = jobId,
                        ApplicationPhaseId = items,
                        AppUserId = userId
                    });
                }
                await _unitOfWork.DevelopersAssigned.InsertRange(jobApplicationPhase);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] DeveloperAssignedDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalUser = await _unitOfWork.DevelopersAssigned.GetT(q => q.Id == id);

                if (originalUser == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                mapper.Map(user, originalUser);
                _unitOfWork.DevelopersAssigned.Update(originalUser);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _unitOfWork.JobApplicationPhases.GetT(q => q.Id == id);

                if (user == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.JobApplicationPhases.Delete(id);
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
