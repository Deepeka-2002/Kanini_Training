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
    public class GroupSizesController : ControllerBase
    {
        private readonly IGroupSizeService _groupSizeService;

        public GroupSizesController(IGroupSizeService groupSizeService)
        {
            _groupSizeService = groupSizeService;
        }

        [ProducesResponseType(typeof(GroupSize), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<GroupSize>> Add_GroupSize(GroupSize GroupSize)
        {
            try
            {
                if (GroupSize.Id <= 0)
                    throw new InvalidPrimaryID();
                var myGroupSize = await _groupSizeService.Add_GroupSize(GroupSize);
                if (myGroupSize.Id != null)
                    return Created("GroupSize created Successfully", myGroupSize);
                return BadRequest(new Error(1, $"GroupSize {GroupSize.Id} is Present already"));
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

        [ProducesResponseType(typeof(GroupSize), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<GroupSize>> Delete_GroupSize(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid GroupSize ID"));
                var myGroupSize = await _groupSizeService.Delete_GroupSize(idDTO);
                if (myGroupSize != null)
                    return Created("GroupSize deleted Successfully", myGroupSize);
                return BadRequest(new Error(5, $"There is no GroupSize present for the id {idDTO.IdInt}"));
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

        [ProducesResponseType(typeof(GroupSize), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<GroupSize>> Update_GroupSize(GroupSize GroupSize)
        {
            try
            {
                if (GroupSize.Id <= 0)
                    return BadRequest(new Error(4, "Enter Valid GroupSize ID"));
                var myGroupSize = await _groupSizeService.Update_GroupSize(GroupSize);
                if (myGroupSize != null)
                    return Created("GroupSize Updated Successfully", myGroupSize);
                return BadRequest(new Error(8, $"There is no GroupSize present for the id {GroupSize.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(GroupSize), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<GroupSize>> View_GroupSize(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid GroupSize ID"));
                var myGroupSize = await _groupSizeService.View_GroupSize(idDTO);
                if (myGroupSize != null)
                    return Created("GroupSize", myGroupSize);
                return BadRequest(new Error(9, $"There is no GroupSize present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(GroupSize), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<GroupSize>>> View_All_GroupSizes()
        {
            try
            {
                var myGroupSizes = await _groupSizeService.View_All_GroupSizes();
                if (myGroupSizes.Count > 0)
                    return Ok(myGroupSizes);
                return BadRequest(new Error(10, "No GroupSizes are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
