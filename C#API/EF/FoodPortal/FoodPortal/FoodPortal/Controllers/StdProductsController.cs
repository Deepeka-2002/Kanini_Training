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
    public class StdProductsController : ControllerBase
    {
        private readonly IStdProductService _stdProductService;

        public StdProductsController(IStdProductService stdProductService)
        {
            _stdProductService = stdProductService;
        }

        [ProducesResponseType(typeof(StdProduct), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<StdProduct>> Add_StdProduct(StdProduct StdProduct)
        {
            try
            {
                if (StdProduct.Id <= 0)
                    throw new InvalidPrimaryID();
                var myStdProduct = await _stdProductService.Add_StdProduct(StdProduct);
                if (myStdProduct.Id != null)
                    return Created("StdProduct created Successfully", myStdProduct);
                return BadRequest(new Error(1, $"StdProduct {StdProduct.Id} is Present already"));
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

        [ProducesResponseType(typeof(StdProduct), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<StdProduct>> Delete_StdProduct(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid StdProduct ID"));
                var myStdProduct = await _stdProductService.Delete_StdProduct(idDTO);
                if (myStdProduct != null)
                    return Created("StdProduct deleted Successfully", myStdProduct);
                return BadRequest(new Error(5, $"There is no StdProduct present for the id {idDTO.IdInt}"));
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

        [ProducesResponseType(typeof(StdProduct), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<StdProduct>> Update_StdProduct(StdProduct StdProduct)
        {
            try
            {
                if (StdProduct.Id <= 0)
                    return BadRequest(new Error(4, "Enter Valid StdProduct ID"));
                var myStdProduct = await _stdProductService.Update_StdProduct(StdProduct);
                if (myStdProduct != null)
                    return Created("StdProduct Updated Successfully", myStdProduct);
                return BadRequest(new Error(8, $"There is no StdProduct present for the id {StdProduct.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(StdProduct), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<StdProduct>> View_StdProduct(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid StdProduct ID"));
                var myStdProduct = await _stdProductService.View_StdProduct(idDTO);
                if (myStdProduct != null)
                    return Created("StdProduct", myStdProduct);
                return BadRequest(new Error(9, $"There is no StdProduct present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(StdProduct), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<StdProduct>>> View_All_StdProducts()
        {
            try
            {
                var myStdProducts = await _stdProductService.View_All_StdProducts();
                if (myStdProducts.Count > 0)
                    return Ok(myStdProducts);
                return BadRequest(new Error(10, "No StdProducts are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [ProducesResponseType(typeof(StdProduct), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<StdProduct>>> View_by_category_StdProducts(int cat)
        {
            try
            {
                var myStdProducts = await _stdProductService.View_by_category_StdProducts(cat);
                if (myStdProducts.Count > 0)
                    return Ok(myStdProducts);
                return BadRequest(new Error(10, "No StdProducts are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [ProducesResponseType(typeof(StdProduct), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<StdProduct>>> View_by_foodtype_StdProducts(bool isveg,int cat)
        {
            try
            {
                var myStdProducts = await _stdProductService.View_by_foodtype_StdProducts(isveg,cat);
                if (myStdProducts.Count > 0)
                    return Ok(myStdProducts);
                return BadRequest(new Error(10, "No StdProducts are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

    }
}
