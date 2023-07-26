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
    public class PlateSizesController : ControllerBase
    {
        private readonly IPlateSizeService _plateSizeService;

        public PlateSizesController(IPlateSizeService plateSizeService)
        {
            _plateSizeService = plateSizeService;
        }

        [ProducesResponseType(typeof(PlateSize), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<PlateSize>> Add_PlateSize(PlateSize PlateSize)
        {
            try
            {
                if (PlateSize.Id <= 0)
                    throw new InvalidPrimaryID();
                var myPlateSize = await _plateSizeService.Add_PlateSize(PlateSize);
                if (myPlateSize.Id != null)
                    return Created("PlateSize created Successfully", myPlateSize);
                return BadRequest(new Error(1, $"PlateSize {PlateSize.Id} is Present already"));
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

        [ProducesResponseType(typeof(PlateSize), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<PlateSize>> Delete_PlateSize(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid PlateSize ID"));
                var myPlateSize = await _plateSizeService.Delete_PlateSize(idDTO);
                if (myPlateSize != null)
                    return Created("PlateSize deleted Successfully", myPlateSize);
                return BadRequest(new Error(5, $"There is no PlateSize present for the id {idDTO.IdInt}"));
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

        [ProducesResponseType(typeof(PlateSize), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<PlateSize>> Update_PlateSize(PlateSize PlateSize)
        {
            try
            {
                if (PlateSize.Id <=0)
                    return BadRequest(new Error(4, "Enter Valid PlateSize ID"));
                var myPlateSize = await _plateSizeService.Update_PlateSize(PlateSize);
                if (myPlateSize != null)
                    return Created("PlateSize Updated Successfully", myPlateSize);
                return BadRequest(new Error(8, $"There is no PlateSize present for the id {PlateSize.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(PlateSize), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<PlateSize>> View_PlateSize(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid PlateSize ID"));
                var myPlateSize = await _plateSizeService.View_PlateSize(idDTO);
                if (myPlateSize != null)
                    return Created("PlateSize", myPlateSize);
                return BadRequest(new Error(9, $"There is no PlateSize present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(PlateSize), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<PlateSize>>> View_All_PlateSizes()
        {
            try
            {
                var myPlateSizes = await _plateSizeService.View_All_PlateSizes();
                if (myPlateSizes.Count > 0)
                    return Ok(myPlateSizes);
                return BadRequest(new Error(10, "No PlateSizes are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
