using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly DataContext _context;
        public AnimalController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Animal>>> Get()
        {
            return Ok(await _context.Animals.ToListAsync());
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<List<Animal>>> Get(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return BadRequest("Animal not found");
            }
            return Ok(animal);
        }

        [HttpPost]
        public async Task<ActionResult<List<Animal>>> AddAnimal(Animal animal)
        {
            _context.Animals.Add(animal); 
            await _context.SaveChangesAsync();
            return Ok(await _context.Animals.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Animal>>> UpdateAnimal(Animal req)
        {
            var dbAnimal = await _context.Animals.FindAsync(req.Id);
            if (dbAnimal == null)
            {
                return BadRequest("Animal not found");
            }

            dbAnimal.Name = req.Name;
            dbAnimal.Species = req.Species;
            await _context.SaveChangesAsync();
            return Ok(await _context.Animals.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Animal>>> Delete(int id)
        {
            var dbAnimal = await _context.Animals.FindAsync(id);
            if (dbAnimal == null)
            {
                return BadRequest("Animal not found");
            }
            _context.Animals.Remove(dbAnimal);
            await _context.SaveChangesAsync();
            return Ok(await _context.Animals.ToListAsync());
        }


    }
}
