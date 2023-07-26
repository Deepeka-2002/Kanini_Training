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
    public class DeliveryOptionsController : ControllerBase
    {
        private readonly IDeliveryOptionService _deliveryOptionService;

        public DeliveryOptionsController(IDeliveryOptionService deliveryOptionService)
        {
            _deliveryOptionService = deliveryOptionService;
        }

        [ProducesResponseType(typeof(DeliveryOption), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<DeliveryOption>> Add_DeliveryOption(DeliveryOption DeliveryOption)
        {
            try
            {
                if (DeliveryOption.Id <= 0)
                    throw new InvalidPrimaryID();
                var myDeliveryOption = await _deliveryOptionService.Add_DeliveryOption(DeliveryOption);
                if (myDeliveryOption.Id != null)
                    return Created("DeliveryOption created Successfully", myDeliveryOption);
                return BadRequest(new Error(1, $"DeliveryOption {DeliveryOption.Id} is Present already"));
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

        [ProducesResponseType(typeof(DeliveryOption), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<DeliveryOption>> Delete_DeliveryOption(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid DeliveryOption ID"));
                var myDeliveryOption = await _deliveryOptionService.Delete_DeliveryOption(idDTO);
                if (myDeliveryOption != null)
                    return Created("DeliveryOption deleted Successfully", myDeliveryOption);
                return BadRequest(new Error(5, $"There is no DeliveryOption present for the id {idDTO.IdInt}"));
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

        [ProducesResponseType(typeof(DeliveryOption), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<DeliveryOption>> Update_DeliveryOption(DeliveryOption DeliveryOption)
        {
            try
            {
                if (DeliveryOption.Id <=0)
                    return BadRequest(new Error(4, "Enter Valid DeliveryOption ID"));
                var myDeliveryOption = await _deliveryOptionService.Update_DeliveryOption(DeliveryOption);
                if (myDeliveryOption != null)
                    return Created("DeliveryOption Updated Successfully", myDeliveryOption);
                return BadRequest(new Error(8, $"There is no DeliveryOption present for the id {DeliveryOption.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(DeliveryOption), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<DeliveryOption>> View_DeliveryOption(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid DeliveryOption ID"));
                var myDeliveryOption = await _deliveryOptionService.View_DeliveryOption(idDTO);
                if (myDeliveryOption != null)
                    return Created("DeliveryOption", myDeliveryOption);
                return BadRequest(new Error(9, $"There is no DeliveryOption present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(DeliveryOption), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<DeliveryOption>>> View_All_DeliveryOptions()
        {
            try
            {
                var myDeliveryOptions = await _deliveryOptionService.View_All_DeliveryOptions();
                if (myDeliveryOptions.Count > 0)
                    return Ok(myDeliveryOptions);
                return BadRequest(new Error(10, "No DeliveryOptions are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
