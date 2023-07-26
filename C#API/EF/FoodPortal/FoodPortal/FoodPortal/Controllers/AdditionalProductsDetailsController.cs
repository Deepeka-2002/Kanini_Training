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
    public class AdditionalProductsDetailsController : ControllerBase
    {
        private readonly IAdditionalProductsDetailService _additionalProductsDetailService;

        public AdditionalProductsDetailsController(IAdditionalProductsDetailService additionalProductsDetailService)
        {
            _additionalProductsDetailService = additionalProductsDetailService;
        }

        [ProducesResponseType(typeof(AdditionalProductsDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<List<AdditionalProductsDetail>>> Add_AdditionalProductsDetail(List<AdditionalProductsDetail> AdditionalProductsDetail)
        {
            
            try
            {
                var myAdditionalProductsDetail = await _additionalProductsDetailService.Add_AdditionalProductsDetail(AdditionalProductsDetail);

                if (myAdditionalProductsDetail.Count > 0)
                {
                    return Created("AdditionalProductsDetail created Successfully", myAdditionalProductsDetail);
                }

                return BadRequest(new Error(1, "No AdditionalProductsDetail were added."));
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

        [ProducesResponseType(typeof(AdditionalProductsDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<AdditionalProductsDetail>> Delete_AdditionalProductsDetail(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid AdditionalProductsDetail ID"));
                var myAdditionalProductsDetail = await _additionalProductsDetailService.Delete_AdditionalProductsDetail(idDTO);
                if (myAdditionalProductsDetail != null)
                    return Created("AdditionalProductsDetail deleted Successfully", myAdditionalProductsDetail);
                return BadRequest(new Error(5, $"There is no AdditionalProductsDetail present for the id {idDTO.IdInt}"));
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

        [ProducesResponseType(typeof(AdditionalProductsDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<AdditionalProductsDetail>> Update_AdditionalProductsDetail(AdditionalProductsDetail AdditionalProductsDetail)
        {
            try
            {
                if (AdditionalProductsDetail.Id <= 0)
                    return BadRequest(new Error(4, "Enter Valid AdditionalProductsDetail ID"));
                var myAdditionalProductsDetail = await _additionalProductsDetailService.Update_AdditionalProductsDetail(AdditionalProductsDetail);
                if (myAdditionalProductsDetail != null)
                    return Created("AdditionalProductsDetail Updated Successfully", myAdditionalProductsDetail);
                return BadRequest(new Error(8, $"There is no AdditionalProductsDetail present for the id {AdditionalProductsDetail.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(AdditionalProductsDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<AdditionalProductsDetail>> View_AdditionalProductsDetail(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid AdditionalProductsDetail ID"));
                var myAdditionalProductsDetail = await _additionalProductsDetailService.View_AdditionalProductsDetail(idDTO);
                if (myAdditionalProductsDetail != null)
                    return Created("AdditionalProductsDetail", myAdditionalProductsDetail);
                return BadRequest(new Error(9, $"There is no AdditionalProductsDetail present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(AdditionalProductsDetail), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<AdditionalProductsDetail>>> View_All_AdditionalProductsDetails()
        {
            try
            {
                var myAdditionalProductsDetails = await _additionalProductsDetailService.View_All_AdditionalProductsDetails();
                if (myAdditionalProductsDetails.Count > 0)
                    return Ok(myAdditionalProductsDetails);
                return BadRequest(new Error(10, "No AdditionalProductsDetails are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
