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
    [Authorize(Roles = "HRAdmin, Super Admin")]
    public class LoginHelperController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public LoginHelperController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET: api/<LoginHelpersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLoginHelpers()
        {
            try
            {
                var LoginHelpers = await _unitOfWork.LoginHelpers.GetAll();
             
                return Ok(LoginHelpers);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<LoginHelpersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLoginHelper(int id)
        {
            try
            {
                var LoginHelper = await _unitOfWork.LoginHelpers.GetT(q => q.Id == id);
                return Ok(LoginHelper);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<LoginHelperController>/userId=1
        [HttpGet("userId={userId}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLoggedInInfoByUserId(int userId)
        {
            try
            {
                var loginHeler = await _unitOfWork.LoginHelpers.GetAll(q => q.AppUserId == userId);
                return Ok(loginHeler);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<LoginHelpersController>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateLoginHelper([FromBody] LoginHelper LoginHelper)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                await _unitOfWork.LoginHelpers.Insert(LoginHelper);
                await _unitOfWork.Save();

                return CreatedAtAction("GetLoginHelper", new { id = LoginHelper.Id }, LoginHelper);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }


        // PUT api/<LoginHelpersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoginHelper(int id, [FromBody] LoginHelperDTO LoginHelper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalLoginHelper = await _unitOfWork.LoginHelpers.GetT(q => q.Id == id);

                if (originalLoginHelper == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                mapper.Map(LoginHelper, originalLoginHelper);
                _unitOfWork.LoginHelpers.Update(originalLoginHelper);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        // DELETE api/<LoginHelpersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLoginHelper(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var LoginHelper = await _unitOfWork.LoginHelpers.GetT(q => q.Id == id);

                if (LoginHelper == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.LoginHelpers.Delete(id);
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
