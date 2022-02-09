using AutoMapper;
using ElectromarketAPI.Entities;
using ElectromarketAPI.Models;
using ElectromarketAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectromarketAPI.Controllers
{
    [Route("api/electromarket")]
    [ApiController]
    public class ElectromarketController : ControllerBase
    {
        private readonly IElectromarketService _electromarketService;
        public ElectromarketController(IElectromarketService electromarketService)
        {
            _electromarketService = electromarketService;
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _electromarketService.Delete(id);
         
            return NotFound();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateElectromarketDto dto, [FromRoute] int id)
        {
            
             _electromarketService.Update(id, dto);
            
            return Ok();

        }
        [HttpPost]
        public ActionResult CreateElectromarket([FromBody]CreateElectromarketDto dto)
        {
            
            var id = _electromarketService.Create(dto);

            return Created($"/api/restaurant/{id}", null);
        }
        [HttpGet]
        public ActionResult<IEnumerable<ElectromarketDto>> GetAll()
        {
            var electromarketsDtos = _electromarketService.GetAll();
            return Ok(electromarketsDtos);
        }
        [HttpGet("{id}")]
        public ActionResult<ElectromarketDto> Get([FromRoute] int id)
        {
            var electromarket = _electromarketService.GetById(id);
            
            
            return Ok(electromarket);
        }
    }
}
