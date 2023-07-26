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
    public class AdditionalProductsController : ControllerBase
    {
        private readonly IAdditionalProductService _additionalCategoryMasterService;

        public AdditionalProductsController(IAdditionalProductService additionalCategoryMasterService)
        {
            _additionalCategoryMasterService = additionalCategoryMasterService;
        }

        [ProducesResponseType(typeof(AdditionalProduct), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<AdditionalProduct>> Add_AdditionalProduct(AdditionalProduct AdditionalProduct)
        {
            try
            {
                if (AdditionalProduct.Id <= 0)
                    throw new InvalidPrimaryID();
                var myAdditionalProduct = await _additionalCategoryMasterService.Add_AdditionalProduct(AdditionalProduct);
                if (myAdditionalProduct.Id != null)
                    return Created("AdditionalProduct created Successfully", myAdditionalProduct);
                return BadRequest(new Error(1, $"AdditionalProduct {AdditionalProduct.Id} is Present already"));
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

        [ProducesResponseType(typeof(AdditionalProduct), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<AdditionalProduct>> Delete_AdditionalProduct(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid AdditionalProduct ID"));
                var myAdditionalProduct = await _additionalCategoryMasterService.Delete_AdditionalProduct(idDTO);
                if (myAdditionalProduct != null)
                    return Created("AdditionalProduct deleted Successfully", myAdditionalProduct);
                return BadRequest(new Error(5, $"There is no AdditionalProduct present for the id {idDTO.IdInt}"));
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

        [ProducesResponseType(typeof(AdditionalProduct), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]

        public async Task<ActionResult<AdditionalProduct>> Update_AdditionalProduct(AdditionalProduct AdditionalProduct)
        {
            try
            {
                if (AdditionalProduct.Id <= 0)
                    return BadRequest(new Error(4, "Enter Valid AdditionalProduct ID"));
                var myAdditionalProduct = await _additionalCategoryMasterService.Update_AdditionalProduct(AdditionalProduct);
                if (myAdditionalProduct.Id != null)
                    return Created("AdditionalProduct Updated Successfully", myAdditionalProduct);
                return BadRequest(new Error(8, $"There is no AdditionalProduct present for the id {AdditionalProduct.Id}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(AdditionalProduct), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<AdditionalProduct>> View_AdditionalProduct(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid AdditionalProduct ID"));
                var myAdditionalProduct = await _additionalCategoryMasterService.View_AdditionalProduct(idDTO);
                if (myAdditionalProduct != null)
                    return Created("AdditionalProduct", myAdditionalProduct);
                return BadRequest(new Error(9, $"There is no AdditionalProduct present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
        [ProducesResponseType(typeof(AdditionalProduct), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<AdditionalProduct>>> View_All_AdditionalProducts()
        {
            try
            {
                var myAdditionalProducts = await _additionalCategoryMasterService.View_All_AdditionalProducts();
                if (myAdditionalProducts.Count > 0)
                    return Ok(myAdditionalProducts);
                return BadRequest(new Error(10, "No AdditionalProducts are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [ProducesResponseType(typeof(AdditionalProduct), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<AdditionalProduct>>> View_by_category_AdditionalProducts(int cat)
        {
            try
            {
                var myAdditionalProducts = await _additionalCategoryMasterService.View_by_category_AdditionalProducts(cat);
                if (myAdditionalProducts.Count > 0)
                    return Ok(myAdditionalProducts);
                return BadRequest(new Error(10, "No AdditionalProducts are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [ProducesResponseType(typeof(StdProduct), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<AdditionalProduct>>> View_by_foodtype_AdditionalProducts(bool isveg, int cat)
        {
            try
            {
                var myAdditionalProducts = await _additionalCategoryMasterService.View_by_foodtype_AdditionalProducts(isveg, cat);
                if (myAdditionalProducts.Count > 0)
                    return Ok(myAdditionalProducts);
                return BadRequest(new Error(10, "No AdditionalProducts are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
