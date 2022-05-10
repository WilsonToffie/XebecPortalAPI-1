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
    public class ProfilePortfolioLinkController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsersCustomRepo usersCustomRepo;
        private readonly IMapper mapper;

        public ProfilePortfolioLinkController(IUnitOfWork unitOfWork, IUsersCustomRepo _usersCustomRepo, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            usersCustomRepo = _usersCustomRepo;
            this.mapper = mapper;
        }

        // GET: api/<ProfilePortfolioLinkController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProfilePortfolioLinks()
        {
            try
            {
                var ProfilePortfolioLink = await _unitOfWork.ProfilePortfolioLinks.GetAll();

                return Ok(ProfilePortfolioLink);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<ProfilePortfolioLinkController>/5
        [HttpGet("single/{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProfilePortfolioLink(int id)
        {
            try
            {
                var ProfilePortfolioLink = await _unitOfWork.ProfilePortfolioLinks.GetT(q => q.Id == id);
                return Ok(ProfilePortfolioLink);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        //get by appuserId
        // GET api/<ProfilePortfolioLinkController>/5
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFirstProfilePortfolioLinkByUserID(int id)
        {
            try
            {
                var ProfilePortfolioLink = await _unitOfWork.ProfilePortfolioLinks.GetT(q => q.AppUserId == id);
                return Ok(ProfilePortfolioLink);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        //get by appuserId
        // GET api/<ProfilePortfolioLinkController>/5
        [HttpGet("all/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProfilePortfolioLinksByUserID(int id)
        {
            try
            {
                var ProfilePortfolioLink = await _unitOfWork.ProfilePortfolioLinks.GetAll(q => q.AppUserId == id);
                return Ok(ProfilePortfolioLink);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<ProfilePortfolioLinkController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProfilePortfolioLink([FromBody] ProfilePortfolioLink ProfilePortfolioLink)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                await _unitOfWork.ProfilePortfolioLinks.Insert(ProfilePortfolioLink);
                await _unitOfWork.Save();

                return CreatedAtAction("GetProfilePortfolioLink", new { id = ProfilePortfolioLink.Id }, ProfilePortfolioLink);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }


        // PUT api/<ProfilePortfolioLinkController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfilePortfolioLink(int id, [FromBody] ProfilePortfolioLinkDTO ProfilePortfolioLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalProfilePortfolioLink = await _unitOfWork.ProfilePortfolioLinks.GetT(q => q.Id == id);

                if (originalProfilePortfolioLink == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                mapper.Map(ProfilePortfolioLink, originalProfilePortfolioLink);
                _unitOfWork.ProfilePortfolioLinks.Update(originalProfilePortfolioLink);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        // DELETE api/<ProfilePortfolioLinkController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProfilePortfolioLink(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var ProfilePortfolioLink = await _unitOfWork.ProfilePortfolioLinks.GetT(q => q.Id == id);

                if (ProfilePortfolioLink == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.ProfilePortfolioLinks.Delete(id);
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
