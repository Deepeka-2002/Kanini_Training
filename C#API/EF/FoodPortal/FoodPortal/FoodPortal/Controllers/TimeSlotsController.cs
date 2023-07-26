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
    public class TimeSlotsController : ControllerBase
    {
        private readonly ITimeSlotService _timeSlotService;

        public TimeSlotsController(ITimeSlotService timeSlotService)
        {
            _timeSlotService = timeSlotService;
        }

        [ProducesResponseType(typeof(TimeSlot), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<TimeSlot>> Add_TimeSlot(TimeSlot TimeSlot)
        {
            try
            {
                if (TimeSlot.Id <= 0)
                    throw new InvalidPrimaryID();
                var myTimeSlot = await _timeSlotService.Add_TimeSlot(TimeSlot);
                if (myTimeSlot.Id != 0)
                    return Created("TimeSlot created Successfully", myTimeSlot);
                return BadRequest(new Error(1, $"TimeSlot {TimeSlot.Id} is Present already"));
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

        [ProducesResponseType(typeof(TimeSlot), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<TimeSlot>> Delete_TimeSlot(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid TimeSlot ID"));
                var myTimeSlot = await _timeSlotService.Delete_TimeSlot(idDTO);
                if (myTimeSlot != null)
                    return Created("TimeSlot deleted Successfully", myTimeSlot);
                return BadRequest(new Error(5, $"There is no TimeSlot present for the id {idDTO.IdInt}"));
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

        [ProducesResponseType(typeof(TimeSlot), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<TimeSlot>> Update_TimeSlot(TimeSlot TimeSlot)
        {
            try
            {
                if (TimeSlot.Id <= 0)
                    return BadRequest(new Error(4, "Enter Valid TimeSlot ID"));
                var myTimeSlot = await _timeSlotService.Update_TimeSlot(TimeSlot);
                if (myTimeSlot != null)
                    return Created("TimeSlot Updated Successfully", myTimeSlot);
                return BadRequest(new Error(8, $"There is no TimeSlot present for the id {TimeSlot.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(TimeSlot), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<TimeSlot>> View_TimeSlot(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdString == "")
                    return BadRequest(new Error(4, "Enter Valid TimeSlot ID"));
                var myTimeSlot = await _timeSlotService.View_TimeSlot(idDTO);
                if (myTimeSlot != null)
                    return Created("TimeSlot", myTimeSlot);
                return BadRequest(new Error(9, $"There is no TimeSlot present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(TimeSlot), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<TimeSlot>>> View_All_TimeSlots()
        {
            try
            {
                var myTimeSlots = await _timeSlotService.View_All_TimeSlots();
                if (myTimeSlots.Count > 0)
                    return Ok(myTimeSlots);
                return BadRequest(new Error(10, "No TimeSlots are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
