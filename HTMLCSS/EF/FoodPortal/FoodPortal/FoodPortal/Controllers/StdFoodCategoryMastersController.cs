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
using FoodPortal.Repos;

namespace FoodPortal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StdFoodCategoryMastersController : ControllerBase
    {
        private readonly IStdFoodCategoryMasterService _stdFoodCategoryMasterService;

        public StdFoodCategoryMastersController(IStdFoodCategoryMasterService stdFoodCategoryMasterService)
        {
            _stdFoodCategoryMasterService = stdFoodCategoryMasterService;
        }

        [ProducesResponseType(typeof(StdFoodCategoryMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<StdFoodCategoryMaster>> Add_StdFoodCategoryMaster(StdFoodCategoryMaster StdFoodCategoryMaster)
        {
            try
            {
                if (StdFoodCategoryMaster.Id <= 0)
                    throw new InvalidPrimaryID();
                var myStdFoodCategoryMaster = await _stdFoodCategoryMasterService.Add_StdFoodCategoryMaster(StdFoodCategoryMaster);
                if (myStdFoodCategoryMaster.Id != null)
                    return Created("StdFoodCategoryMaster created Successfully", myStdFoodCategoryMaster);
                return BadRequest(new Error(1, $"StdFoodCategoryMaster {StdFoodCategoryMaster.Id} is Present already"));
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

        [ProducesResponseType(typeof(StdFoodCategoryMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<StdFoodCategoryMaster>> Delete_StdFoodCategoryMaster(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid StdFoodCategoryMaster ID"));
                var myStdFoodCategoryMaster = await _stdFoodCategoryMasterService.Delete_StdFoodCategoryMaster(idDTO);
                if (myStdFoodCategoryMaster != null)
                    return Created("StdFoodCategoryMaster deleted Successfully", myStdFoodCategoryMaster);
                return BadRequest(new Error(5, $"There is no StdFoodCategoryMaster present for the id {idDTO.IdInt}"));
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

        [ProducesResponseType(typeof(StdFoodCategoryMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<StdFoodCategoryMaster>> Update_StdFoodCategoryMaster(StdFoodCategoryMaster StdFoodCategoryMaster)
        {
            try
            {
                if (StdFoodCategoryMaster.Id <= 0)
                    return BadRequest(new Error(4, "Enter Valid StdFoodCategoryMaster ID"));
                var myStdFoodCategoryMaster = await _stdFoodCategoryMasterService.Update_StdFoodCategoryMaster(StdFoodCategoryMaster);
                if (myStdFoodCategoryMaster != null)
                    return Created("StdFoodCategoryMaster Updated Successfully", myStdFoodCategoryMaster);
                return BadRequest(new Error(8, $"There is no StdFoodCategoryMaster present for the id {StdFoodCategoryMaster.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(StdFoodCategoryMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<StdFoodCategoryMaster>> View_StdFoodCategoryMaster(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid StdFoodCategoryMaster ID"));
                var myStdFoodCategoryMaster = await _stdFoodCategoryMasterService.View_StdFoodCategoryMaster(idDTO);
                if (myStdFoodCategoryMaster != null)
                    return Created("StdFoodCategoryMaster", myStdFoodCategoryMaster);
                return BadRequest(new Error(9, $"There is no StdFoodCategoryMaster present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(StdFoodCategoryMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<StdFoodCategoryMaster>>> View_All_StdFoodCategoryMasters()
        {
            try
            {
                var myStdFoodCategoryMasters = await _stdFoodCategoryMasterService.View_All_StdFoodCategoryMasters();
                if (myStdFoodCategoryMasters.Count > 0)
                    return Ok(myStdFoodCategoryMasters);
                return BadRequest(new Error(10, "No StdFoodCategoryMasters are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
