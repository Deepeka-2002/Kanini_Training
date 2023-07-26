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
    public class StdFoodOrderDetailsController : ControllerBase
    {
        private readonly IStdFoodOrderDetailService _stdFoodOrderDetailService;

        public StdFoodOrderDetailsController(IStdFoodOrderDetailService stdFoodOrderDetailService)
        {
            _stdFoodOrderDetailService = stdFoodOrderDetailService;
        }


        [ProducesResponseType(typeof(List<StdFoodOrderDetail>), StatusCodes.Status200OK)] // Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Failure Response
        [HttpPost]
        public async Task<ActionResult<List<StdFoodOrderDetail>>> Add_StdFoodOrderDetail(List<StdFoodOrderDetail> StdFoodOrderDetails)
        {
            try
            {
                var addedStdFoodOrderDetails = await _stdFoodOrderDetailService.Add_StdFoodOrderDetail(StdFoodOrderDetails);

                if (addedStdFoodOrderDetails.Count >0)
                {
                    return Created("StdFoodOrderDetails created Successfully", addedStdFoodOrderDetails);
                }

                return BadRequest(new Error(1, "No StdFoodOrderDetails were added."));
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


        [ProducesResponseType(typeof(StdFoodOrderDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<StdFoodOrderDetail>> Delete_StdFoodOrderDetail(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid StdFoodOrderDetail ID"));
                var myStdFoodOrderDetail = await _stdFoodOrderDetailService.Delete_StdFoodOrderDetail(idDTO);
                if (myStdFoodOrderDetail != null)
                    return Created("StdFoodOrderDetail deleted Successfully", myStdFoodOrderDetail);
                return BadRequest(new Error(5, $"There is no StdFoodOrderDetail present for the id {idDTO.IdInt}"));
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

        [ProducesResponseType(typeof(StdFoodOrderDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<StdFoodOrderDetail>> Update_StdFoodOrderDetail(StdFoodOrderDetail StdFoodOrderDetail)
        {
            try
            {
                if (StdFoodOrderDetail.Id <= 0)
                    return BadRequest(new Error(4, "Enter Valid StdFoodOrderDetail ID"));
                var myStdFoodOrderDetail = await _stdFoodOrderDetailService.Update_StdFoodOrderDetail(StdFoodOrderDetail);
                if (myStdFoodOrderDetail != null)
                    return Created("StdFoodOrderDetail Updated Successfully", myStdFoodOrderDetail);
                return BadRequest(new Error(8, $"There is no StdFoodOrderDetail present for the id {StdFoodOrderDetail.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(StdFoodOrderDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<StdFoodOrderDetail>> View_StdFoodOrderDetail(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid StdFoodOrderDetail ID"));
                var myStdFoodOrderDetail = await _stdFoodOrderDetailService.View_StdFoodOrderDetail(idDTO);
                if (myStdFoodOrderDetail != null)
                    return Created("StdFoodOrderDetail", myStdFoodOrderDetail);
                return BadRequest(new Error(9, $"There is no StdFoodOrderDetail present for the id {idDTO.IdString}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(StdFoodOrderDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<StdFoodOrderDetail>>> View_All_StdFoodOrderDetails()
        {
            try
            {
                var myStdFoodOrderDetails = await _stdFoodOrderDetailService.View_All_StdFoodOrderDetails();
                if (myStdFoodOrderDetails.Count > 0)
                    return Ok(myStdFoodOrderDetails);
                return BadRequest(new Error(10, "No StdFoodOrderDetails are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
