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
    public class AddOnsMastersController : ControllerBase
    {
        private readonly IAddOnsMasterService _addOnsMasterService;

        public AddOnsMastersController(IAddOnsMasterService addOnsMasterService)
        {
            _addOnsMasterService = addOnsMasterService;
        }

        [ProducesResponseType(typeof(AddOnsMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<AddOnsMaster>> Add_AddOnsMaster(AddOnsMaster AddOnsMaster)
        {
            try
            {
                if (AddOnsMaster.Id <=0)
                    throw new InvalidPrimaryID();
                var myAddOnsMaster = await _addOnsMasterService.Add_AddOnsMaster(AddOnsMaster);
                if (myAddOnsMaster.Id != null)
                    return Created("AddOnsMaster created Successfully", myAddOnsMaster);
                return BadRequest(new Error(1, $"AddOnsMaster {AddOnsMaster.Id} is Present already"));
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

        [ProducesResponseType(typeof(AddOnsMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<AddOnsMaster>> Delete_AddOnsMaster(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid AddOnsMaster ID"));
                var myAddOnsMaster = await _addOnsMasterService.Delete_AddOnsMaster(idDTO);
                if (myAddOnsMaster != null)
                    return Created("AddOnsMaster deleted Successfully", myAddOnsMaster);
                return BadRequest(new Error(5, $"There is no AddOnsMaster present for the id {idDTO.IdInt}"));
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

        [ProducesResponseType(typeof(AddOnsMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<AddOnsMaster>> Update_AddOnsMaster(AddOnsMaster AddOnsMaster)
        {
            try
            {
                if (AddOnsMaster.Id <= 0)
                    return BadRequest(new Error(4, "Enter Valid AddOnsMaster ID"));
                var myAddOnsMaster = await _addOnsMasterService.Update_AddOnsMaster(AddOnsMaster);
                if (myAddOnsMaster != null)
                    return Created("AddOnsMaster Updated Successfully", myAddOnsMaster);
                return BadRequest(new Error(8, $"There is no AddOnsMaster present for the id {AddOnsMaster.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(AddOnsMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<AddOnsMaster>> View_AddOnsMaster(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid AddOnsMaster ID"));
                var myAddOnsMaster = await _addOnsMasterService.View_AddOnsMaster(idDTO);
                if (myAddOnsMaster != null)
                    return Created("AddOnsMaster", myAddOnsMaster);
                return BadRequest(new Error(9, $"There is no AddOnsMaster present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(AddOnsMaster), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<AddOnsMaster>>> View_All_AddOnsMasters()
        {
            try
            {
                var myAddOnsMasters = await _addOnsMasterService.View_All_AddOnsMasters();
                if (myAddOnsMasters.Count > 0)
                    return Ok(myAddOnsMasters);
                return BadRequest(new Error(10, "No AddOnsMasters are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
