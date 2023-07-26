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
    public class AddOnsDetailsController : ControllerBase
    {
        private readonly IAddOnsDetailService _addOnsDetailService;

        public AddOnsDetailsController(IAddOnsDetailService addOnsDetailService)
        {
            _addOnsDetailService = addOnsDetailService;
        }

        [ProducesResponseType(typeof(List<AddOnsDetail>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<List<AddOnsDetail>>> Add_AddOnsDetail(List<AddOnsDetail> AddOnsDetail)
        {
           

            try
            {
                var myAddOnsDetail = await _addOnsDetailService.Add_AddOnsDetail(AddOnsDetail);

                if (myAddOnsDetail.Count > 0)
                {
                    return Created("AddOnsDetail created Successfully", myAddOnsDetail);
                }

                return BadRequest(new Error(1, "No AddOnsDetail were added."));
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

        [ProducesResponseType(typeof(AddOnsDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<AddOnsDetail>> Delete_AddOnsDetail(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid AddOnsDetail ID"));
                var myAddOnsDetail = await _addOnsDetailService.Delete_AddOnsDetail(idDTO);
                if (myAddOnsDetail != null)
                    return Created("AddOnsDetail deleted Successfully", myAddOnsDetail);
                return BadRequest(new Error(5, $"There is no AddOnsDetail present for the id {idDTO.IdInt}"));
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

        [ProducesResponseType(typeof(AddOnsDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<AddOnsDetail>> Update_AddOnsDetail(AddOnsDetail AddOnsDetail)
        {
            try
            {
                if (AddOnsDetail.Id <= 0)
                    return BadRequest(new Error(4, "Enter Valid AddOnsDetail ID"));
                var myAddOnsDetail = await _addOnsDetailService.Update_AddOnsDetail(AddOnsDetail);
                if (myAddOnsDetail != null)
                    return Created("AddOnsDetail Updated Successfully", myAddOnsDetail);
                return BadRequest(new Error(8, $"There is no AddOnsDetail present for the id {AddOnsDetail.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(AddOnsDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<AddOnsDetail>> View_AddOnsDetail(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid AddOnsDetail ID"));
                var myAddOnsDetail = await _addOnsDetailService.View_AddOnsDetail(idDTO);
                if (myAddOnsDetail != null)
                    return Created("AddOnsDetail", myAddOnsDetail);
                return BadRequest(new Error(9, $"There is no AddOnsDetail present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(AddOnsDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<AddOnsDetail>>> View_All_AddOnsDetails()
        {
            try
            {
                var myAddOnsDetails = await _addOnsDetailService.View_All_AddOnsDetails();
                if (myAddOnsDetails.Count > 0)
                    return Ok(myAddOnsDetails);
                return BadRequest(new Error(10, "No AddOnsDetails are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
