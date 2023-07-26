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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;



        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<Order>> Add_Order(Order Order)
        {
            try
            {
                if (Order.Id == "")
                    throw new InvalidPrimaryID();
                var myOrder = await _orderService.Add_Order(Order);
                if (myOrder.Id != null)
                    return Created("Order created Successfully", myOrder);
                return BadRequest(new Error(1, $"Order {Order.Id} is Present already"));
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

        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<Order>> Delete_Order(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdString == "")
                    return BadRequest(new Error(4, "Enter Valid Order ID"));
                var myOrder = await _orderService.Delete_Order(idDTO);
                if (myOrder != null)
                    return Created("Order deleted Successfully", myOrder);
                return BadRequest(new Error(5, $"There is no Order present for the id {idDTO.IdString}"));
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

        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<Order>> Update_Order(Order Order)
        {
            try
            {
                if (Order.Id == "")
                    return BadRequest(new Error(4, "Enter Valid Order ID"));
                var myOrder = await _orderService.Update_Order(Order);
                if (myOrder != null)
                    return Created("Order Updated Successfully", myOrder);
                return BadRequest(new Error(8, $"There is no Order present for the id {Order.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<Order>> View_Order(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdString == "")
                    return BadRequest(new Error(4, "Enter Valid Order ID"));
                var myOrder = await _orderService.View_Order(idDTO);
                if (myOrder != null)
                    return Created("Order", myOrder);
                return BadRequest(new Error(9, $"There is no Order present for the id {idDTO.IdString}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<Order>>> View_All_Orders()
        {
            try
            {
                var myOrders = await _orderService.View_All_Orders();
                if (myOrders.Count > 0)
                    return Ok(myOrders);
                return BadRequest(new Error(10, "No Orders are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet("UnAvailableDate{date}")]
        public async Task<ActionResult<List<AvailabilityDTO>>> GetUnAvailableDate(DateTime date)
        {
            var availableDate = await _orderService.GetUnAvailableDate(date);
            if (availableDate == null)
                return NotFound();

            return Ok(availableDate);
        }

        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet("AvailableTimeSlot{date}")]
        public async Task<ActionResult<List<AvailabilityDTO>>> GetAvailableTimeSlot(DateTime date)
        {
            var availableDate = await _orderService.GetAvailableTimeSlot(date);
            if (availableDate == null)
                return NotFound();

            return Ok(availableDate);
        }
    }
}
