using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodPortal.Models;
using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Services;

namespace FoodPortal.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AllergyDetailsController : ControllerBase
    {
        private readonly IAllergyDetailService _allergyDetailService;

        public AllergyDetailsController(IAllergyDetailService allergyDetailService)
        {
            _allergyDetailService = allergyDetailService;
        }

        [ProducesResponseType(typeof(List<AllergyDetail>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<List<AllergyDetail>>> Add_AllergyDetail(List<AllergyDetail> AllergyDetail)
        {
           

            try
            {
                var myAllergyDetail = await _allergyDetailService.Add_AllergyDetail(AllergyDetail);

                if (myAllergyDetail.Count > 0)
                {
                    return Created("AllergyDetail created Successfully", myAllergyDetail);
                }

                return BadRequest(new Error(1, "No AllergyDetail were added."));
            }
            catch (InvalidPrimaryID ip)
            {
                return BadRequest(new Error(2, ip.Message));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }

        }

        [ProducesResponseType(typeof(AllergyDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<AllergyDetail>> Delete_AllergyDetail(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid AllergyDetail ID"));
                var myAllergyDetail = await _allergyDetailService.Delete_AllergyDetail(idDTO);
                if (myAllergyDetail != null)
                    return Created("AllergyDetail deleted Successfully", myAllergyDetail);
                return BadRequest(new Error(5, $"There is no AllergyDetail present for the id {idDTO.IdInt}"));
            }
            catch (FormatException fe)
            {
                return BadRequest(new Error(6, fe.Message));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [ProducesResponseType(typeof(AllergyDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<AllergyDetail>> Update_AllergyDetail(AllergyDetail AllergyDetail)
        {
            try
            {
                if (AllergyDetail.Id <= 0)
                    return BadRequest(new Error(4, "Enter Valid AllergyDetail ID"));
                var myAllergyDetail = await _allergyDetailService.Update_AllergyDetail(AllergyDetail);
                if (myAllergyDetail != null)
                    return Created("AllergyDetail Updated Successfully", myAllergyDetail);
                return BadRequest(new Error(8, $"There is no AllergyDetail present for the id {AllergyDetail.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(AllergyDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<AllergyDetail>> View_AllergyDetail(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid AllergyDetail ID"));
                var myAllergyDetail = await _allergyDetailService.View_AllergyDetail(idDTO);
                if (myAllergyDetail != null)
                    return Created("AllergyDetail", myAllergyDetail);
                return BadRequest(new Error(9, $"There is no AllergyDetail present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(AllergyDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<AllergyDetail>>> View_All_AllergyDetails()
        {
            try
            {
                var myAllergyDetails = await _allergyDetailService.View_All_AllergyDetails();
                if (myAllergyDetails.Count > 0)
                    return Ok(myAllergyDetails);
                return BadRequest(new Error(10, "No AllergyDetails are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
