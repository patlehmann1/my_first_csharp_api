using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        public RestaurantController()
        {
        }

        [HttpGet]
        public ActionResult<List<Restaurant>> GetAll() =>
            RestaurantService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get(int id)
        {
            var Restaurant = RestaurantService.Get(id);

            if(Restaurant == null)
                return NotFound();

            return Restaurant;
        }

        [HttpPost]
        public IActionResult Create(Restaurant Restaurant)
        {            
            RestaurantService.Add(Restaurant);
            return CreatedAtAction(nameof(Create), new { id = Restaurant.Id }, Restaurant);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Restaurant Restaurant)
        {
            if (id != Restaurant.Id)
                return BadRequest();

            var existingRestaurant = RestaurantService.Get(id);
            if(existingRestaurant is null)
                return NotFound();

            RestaurantService.Update(Restaurant);           

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Restaurant = RestaurantService.Get(id);

            if (Restaurant is null)
                return NotFound();

            RestaurantService.Delete(id);

            return NoContent();
        }
    }
};