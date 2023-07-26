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
    public class FoodTypeCountsController : ControllerBase
    {
        private readonly IFoodTypeCountService _foodTypeCountService;

        public FoodTypeCountsController(IFoodTypeCountService foodTypeCountService)
        {
            _foodTypeCountService = foodTypeCountService;
        }

        [ProducesResponseType(typeof(List<FoodTypeCount>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<List<FoodTypeCount>>> Add_FoodTypeCount(List<FoodTypeCount> FoodTypeCount)
        {
           

            try
            {
                var myFoodTypeCount = await _foodTypeCountService.Add_FoodTypeCount(FoodTypeCount);

                if (myFoodTypeCount.Count > 0)
                {
                    return Created("FoodTypeCount created Successfully", myFoodTypeCount);
                }

                return BadRequest(new Error(1, "No FoodTypeCount were added."));
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

        [ProducesResponseType(typeof(FoodTypeCount), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<FoodTypeCount>> Delete_FoodTypeCount(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid FoodTypeCount ID"));
                var myFoodTypeCount = await _foodTypeCountService.Delete_FoodTypeCount(idDTO);
                if (myFoodTypeCount != null)
                    return Created("FoodTypeCount deleted Successfully", myFoodTypeCount);
                return BadRequest(new Error(5, $"There is no FoodTypeCount present for the id {idDTO.IdInt}"));
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

        [ProducesResponseType(typeof(FoodTypeCount), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<FoodTypeCount>> Update_FoodTypeCount(FoodTypeCount FoodTypeCount)
        {
            try
            {
                if (FoodTypeCount.Id <= 0)
                    return BadRequest(new Error(4, "Enter Valid FoodTypeCount ID"));
                var myFoodTypeCount = await _foodTypeCountService.Update_FoodTypeCount(FoodTypeCount);
                if (myFoodTypeCount != null)
                    return Created("FoodTypeCount Updated Successfully", myFoodTypeCount);
                return BadRequest(new Error(8, $"There is no FoodTypeCount present for the id {FoodTypeCount.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(FoodTypeCount), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<FoodTypeCount>> View_FoodTypeCount(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid FoodTypeCount ID"));
                var myFoodTypeCount = await _foodTypeCountService.View_FoodTypeCount(idDTO);
                if (myFoodTypeCount != null)
                    return Created("FoodTypeCount", myFoodTypeCount);
                return BadRequest(new Error(9, $"There is no FoodTypeCount present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(FoodTypeCount), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<FoodTypeCount>>> View_All_FoodTypeCounts()
        {
            try
            {
                var myFoodTypeCounts = await _foodTypeCountService.View_All_FoodTypeCounts();
                if (myFoodTypeCounts.Count > 0)
                    return Ok(myFoodTypeCounts);
                return BadRequest(new Error(10, "No FoodTypeCounts are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
