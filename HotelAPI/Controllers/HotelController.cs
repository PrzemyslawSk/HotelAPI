using HotelAPI.Models;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelAPI.Controllers
{
    [Route("api/hotel")]
    //Validation check
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateHotelDto dto, [FromRoute] int id)
        {
            _hotelService.Update(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _hotelService.Delete(id);

            return NoContent();
        }

        [HttpPost]
        public ActionResult CreateHotel([FromBody] CreateHotelDto dto)
        {
            var id = _hotelService.Create(dto);

            return Created($"/api/hotel/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<HotelDto>> GetAll()
        {
            var hotelsDtos = _hotelService.GetAll();

            return Ok(hotelsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<HotelDto> Get([FromRoute] int id)
        {
            var hotel = _hotelService.GetById(id);

            return Ok(hotel);
        }
    }
}
