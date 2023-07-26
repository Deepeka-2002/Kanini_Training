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

namespace FoodPortal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AllergyMastersController : ControllerBase
    {
        private readonly IAllergyMasterService _AllergyMasterService;


        public AllergyMastersController(IAllergyMasterService AllergyMasterService)
        {
            _AllergyMasterService = AllergyMasterService;
        }

        [ProducesResponseType(typeof(AllergyMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<AllergyMaster>> Add_AllergyMaster(AllergyMaster AllergyMaster)
        {
            try
            {
                if (AllergyMaster.Id <= 0)
                    throw new InvalidPrimaryID();
                var myAllergyMaster = await _AllergyMasterService.Add_AllergyMaster(AllergyMaster);
                if (myAllergyMaster.Id != null)
                    return Created("AllergyMaster created Successfully", myAllergyMaster);
                return BadRequest(new Error(1, $"AllergyMaster {AllergyMaster.Id} is Present already"));
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

        [ProducesResponseType(typeof(AllergyMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<AllergyMaster>> Delete_AllergyMaster(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid AllergyMaster ID"));
                var myAllergyMaster = await _AllergyMasterService.Delete_AllergyMaster(idDTO);
                if (myAllergyMaster != null)
                    return Created("AllergyMaster deleted Successfully", myAllergyMaster);
                return BadRequest(new Error(5, $"There is no AllergyMaster present for the id {idDTO.IdInt}"));
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

        [ProducesResponseType(typeof(AllergyMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<AllergyMaster>> Update_AllergyMaster(AllergyMaster AllergyMaster)
        {
            try
            {
                if (AllergyMaster.Id <= 0)
                    return BadRequest(new Error(4, "Enter Valid AllergyMaster ID"));
                var myAllergyMaster = await _AllergyMasterService.Update_AllergyMaster(AllergyMaster);
                if (myAllergyMaster != null)
                    return Created("AllergyMaster Updated Successfully", myAllergyMaster);
                return BadRequest(new Error(8, $"There is no AllergyMaster present for the id {AllergyMaster.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(AllergyMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<AllergyMaster>> View_AllergyMaster(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid AllergyMaster ID"));
                var myAllergyMaster = await _AllergyMasterService.View_AllergyMaster(idDTO);
                if (myAllergyMaster != null)
                    return Created("AllergyMaster", myAllergyMaster);
                return BadRequest(new Error(9, $"There is no AllergyMaster present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(AllergyMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<AllergyMaster>>> View_All_AllergyMasters()
        {
            try
            {
                var myAllergyMasters = await _AllergyMasterService.View_All_AllergyMasters();
                if (myAllergyMasters.Count > 0)
                    return Ok(myAllergyMasters);
                return BadRequest(new Error(10, "No AllergyMasters are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
