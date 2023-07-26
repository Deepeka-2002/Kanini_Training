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
    public class TrackStatusController : ControllerBase
    {
        private readonly ITrackStatusService _trackStatusService;

        public TrackStatusController(ITrackStatusService trackStatusService)
        {
            _trackStatusService = trackStatusService;
        }

        [ProducesResponseType(typeof(TrackStatus), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<TrackStatus>> Add_TrackStatus(TrackStatus TrackStatus)
        {
            try
            {
                if (TrackStatus.Id == "")
                    throw new InvalidPrimaryID();
                var myTrackStatus = await _trackStatusService.Add_TrackStatus(TrackStatus);
                if (myTrackStatus != null)
                    return Created("TrackStatus created Successfully", myTrackStatus);
                return BadRequest(new Error(1, $"TrackStatus {TrackStatus.Id} is Present already"));
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

        [ProducesResponseType(typeof(TrackStatus), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<TrackStatus>> Delete_TrackStatus(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdString == "")
                    return BadRequest(new Error(4, "Enter Valid TrackStatus ID"));
                var myTrackStatus = await _trackStatusService.Delete_TrackStatus(idDTO);
                if (myTrackStatus != null)
                    return Created("TrackStatus deleted Successfully", myTrackStatus);
                return BadRequest(new Error(5, $"There is no TrackStatus present for the id {idDTO.IdString}"));
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

        [ProducesResponseType(typeof(TrackStatus), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<TrackStatus>> Update_TrackStatus(TrackStatus TrackStatus)
        {
            try
            {
                if (TrackStatus.Id == "")
                    return BadRequest(new Error(4, "Enter Valid TrackStatus ID"));
                var myTrackStatus = await _trackStatusService.Update_TrackStatus(TrackStatus);
                if (myTrackStatus != null)
                    return Created("TrackStatus Updated Successfully", myTrackStatus);
                return BadRequest(new Error(8, $"There is no TrackStatus present for the id {TrackStatus.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(TrackStatus), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<TrackStatus>> View_TrackStatus(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdString == "")
                    return BadRequest(new Error(4, "Enter Valid TrackStatus ID"));
                var myTrackStatus = await _trackStatusService.View_TrackStatus(idDTO);
                if (myTrackStatus != null)
                    return Created("TrackStatus", myTrackStatus);
                return BadRequest(new Error(9, $"There is no TrackStatus present for the id {idDTO.IdString}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(TrackStatus), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<TrackStatus>>> View_All_TrackStatuss()
        {
            try
            {
                var myTrackStatuss = await _trackStatusService.View_All_TrackStatuss();
                if (myTrackStatuss.Count > 0)
                    return Ok(myTrackStatuss);
                return BadRequest(new Error(10, "No TrackStatuss are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [ProducesResponseType(typeof(List<TrackDTO>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("TrackId")]

        public async Task<ActionResult<List<TrackDTO>>> Get_Order_Summary(IdDTO id)
        {
            try
            {
                var myTrackStatuss = await _trackStatusService.Get_Order_Summary(id.IdString);
                if (myTrackStatuss != null)
                    return Ok(myTrackStatuss);
                return BadRequest(new Error(10, "No TrackStatuss are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
