﻿using AutoMapper;
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
    //[Authorize]
    [ApiController]
    public class AdditionalInformationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public AdditionalInformationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        } 

        // GET: api/<AdditionalInformationController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAdditionalInformation()
        {
            try
            {
                var AdditionalInformation = await _unitOfWork.AdditionalInformation.GetAll();
             
                return Ok(AdditionalInformation);

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
        public async Task<IActionResult> GetAdditionalInformation(int id)
        {
            try
            {
                var AdditionalInformation = await _unitOfWork.AdditionalInformation.GetT(q => q.Id == id);
                return Ok(AdditionalInformation);
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
        public async Task<IActionResult> CreateAdditionalInformation([FromBody] AdditionalInformation AdditionalInformation)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                await _unitOfWork.AdditionalInformation.Insert(AdditionalInformation);
                await _unitOfWork.Save();

                return CreatedAtAction("GetAdditionalInformation", new { id = AdditionalInformation.Id }, AdditionalInformation);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }


        // PUT api/<AdditionalInformationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdditionalInformation(int id, [FromBody] AdditionalInformationDTO AdditionalInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalAdditionalInformation = await _unitOfWork.AdditionalInformation.GetT(q => q.Id == id);

                if (originalAdditionalInformation == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                mapper.Map(AdditionalInformation, originalAdditionalInformation);
                _unitOfWork.AdditionalInformation.Update(originalAdditionalInformation);
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
        public async Task<IActionResult> DeleteAdditionalInformation(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var AdditionalInformation = await _unitOfWork.AdditionalInformation.GetT(q => q.Id == id);

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
