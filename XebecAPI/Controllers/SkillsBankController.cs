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
    public class SkillsBankController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public SkillsBankController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET: api/<SkillsBankController>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSkillsBanks()
        {
            try
            {
                var SkillsBank = await _unitOfWork.SkillsBanks.GetAll();
             
                return Ok(SkillsBank);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<SkillsBankController>/5
        [HttpGet("single/{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSkillsBank(int id)
        {
            try
            {
                var SkillsBank = await _unitOfWork.SkillsBanks.GetT(q => q.Id == id);
                return Ok(SkillsBank);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<SkillsBankController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSkillsBank([FromBody] SkillsBank SkillsBank)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                await _unitOfWork.SkillsBanks.Insert(SkillsBank);
                await _unitOfWork.Save();

                return CreatedAtAction("GetSkillsBank", new { id = SkillsBank.Id }, SkillsBank);

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
        public async Task<IActionResult> CreateSkillsBanks([FromBody] List<SkillsBank> SkillsBanks)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {
              
                    await _unitOfWork.SkillsBanks.InsertRange(SkillsBanks);
                    await _unitOfWork.Save();

                   
             

                return CreatedAtAction("GetSkillsBanks", SkillsBanks);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }



        // PUT api/<SkillsBankController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkillsBank(int id, [FromBody] SkillsBankDTO SkillsBank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalSkillsBank = await _unitOfWork.SkillsBanks.GetT(q => q.Id == id);

                if (originalSkillsBank == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                mapper.Map(SkillsBank, originalSkillsBank);
                _unitOfWork.SkillsBanks.Update(originalSkillsBank);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        // DELETE api/<SkillsBankController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSkillsBank(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var SkillsBank = await _unitOfWork.SkillsBanks.GetT(q => q.Id == id);

                if (SkillsBank == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.SkillsBanks.Delete(id);
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
