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
    public class AdditionalCategoryMastersController : ControllerBase
    {
/*        private readonly ICrud<AdditionalCategoryMaster, IdDTO> _additionalCategoryMasterRepo;
*/        private readonly IAdditionalCategoryMasterService _additionalCategoryMasterService;


        public AdditionalCategoryMastersController(IAdditionalCategoryMasterService additionalCategoryMasterService)
        {
            _additionalCategoryMasterService = additionalCategoryMasterService;
        }

        [ProducesResponseType(typeof(AdditionalCategoryMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<AdditionalCategoryMaster>> Add_AdditionalCategoryMaster(AdditionalCategoryMaster additionalCategoryMaster)
        {
            try
            {
                if (additionalCategoryMaster.Id <=0)
                    throw new InvalidPrimaryID();
                var myAdditionalCategoryMaster = await _additionalCategoryMasterService.Add_AdditionalCategoryMaster(additionalCategoryMaster);
                if (myAdditionalCategoryMaster.Id != null)
                    return Created("AdditionalCategoryMaster created Successfully", myAdditionalCategoryMaster);
                return BadRequest(new Error(1, $"AdditionalCategoryMaster {additionalCategoryMaster.Id} is Present already"));
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

        [ProducesResponseType(typeof(AdditionalCategoryMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<AdditionalCategoryMaster>> Delete_AdditionalCategoryMaster(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <=0)
                    return BadRequest(new Error(4, "Enter Valid AdditionalCategoryMaster ID"));
                var myAdditionalCategoryMaster = await _additionalCategoryMasterService.Delete_AdditionalCategoryMaster(idDTO);
                if (myAdditionalCategoryMaster != null)
                    return Created("AdditionalCategoryMaster deleted Successfully", myAdditionalCategoryMaster);
                return BadRequest(new Error(5, $"There is no AdditionalCategoryMaster present for the id {idDTO.IdInt}"));
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

        [ProducesResponseType(typeof(AdditionalCategoryMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<AdditionalCategoryMaster>> Update_AdditionalCategoryMaster(AdditionalCategoryMaster additionalCategoryMaster)
        {
            try
            {
                if (additionalCategoryMaster.Id <=0)
                    return BadRequest(new Error(4, "Enter Valid AdditionalCategoryMaster ID"));
                var myAdditionalCategoryMaster = await _additionalCategoryMasterService.Update_AdditionalCategoryMaster(additionalCategoryMaster);
                if (myAdditionalCategoryMaster != null)
                    return Created("AdditionalCategoryMaster Updated Successfully", myAdditionalCategoryMaster);
                return BadRequest(new Error(8, $"There is no AdditionalCategoryMaster present for the id {additionalCategoryMaster.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(AdditionalCategoryMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<AdditionalCategoryMaster>> View_AdditionalCategoryMaster(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid AdditionalCategoryMaster ID"));
                var myAdditionalCategoryMaster = await _additionalCategoryMasterService.View_AdditionalCategoryMaster(idDTO);
                if (myAdditionalCategoryMaster != null)
                    return Created("AdditionalCategoryMaster", myAdditionalCategoryMaster);
                return BadRequest(new Error(9, $"There is no AdditionalCategoryMaster present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(AdditionalCategoryMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<AdditionalCategoryMaster>>> View_All_AdditionalCategoryMasters()
        {
            try
            {
                var myAdditionalCategoryMasters = await _additionalCategoryMasterService.View_All_AdditionalCategoryMasters();
                if (myAdditionalCategoryMasters.Count > 0)
                    return Ok(myAdditionalCategoryMasters);
                return BadRequest(new Error(10, "No AdditionalCategoryMasters are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

    }
}
