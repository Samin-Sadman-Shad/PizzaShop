using Microsoft.AspNetCore.Mvc;
using PizzaShopApi.Models;
using PizzaShopApi.Services;


namespace PizzaShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController: ControllerBase
    {
        public PizzaController() 
        {
            
        }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAllPizza() => PizzaService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Pizza> GetPizzaById([FromRoute]int id)
        {
            var pizza = PizzaService.Get(id);
            if(pizza == null)
            {
                Console.WriteLine("pizza is null");
                return NotFound();
            }
            return pizza;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(GetPizzaById), new { id = pizza.Id }, pizza);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody]Pizza pizza)
        {

            if (pizza == null) 
            {
                return BadRequest();
            }
            if (pizza != null && pizza.Id != id) 
            {
                return BadRequest();
            }
            var p = PizzaService.Get(id);
            if (p == null) 
            {
                return NotFound();
            }

            PizzaService.Update(pizza);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var existingPizza = PizzaService.Get(id);
            if(existingPizza == null)
            {
                return NotFound();
            }
            PizzaService.Delete(id);
            return NoContent();
        }
    }
}
