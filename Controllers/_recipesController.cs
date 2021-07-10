using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrazyGrannyCookingRecipes;
using CrazyGrannyCookingRecipes.Data;

namespace CrazyGrannyCookingRecipes.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class _recipesController : ControllerBase
    {
        private readonly CrazyGrannyCookingRecipesContext _context;

        public _recipesController(CrazyGrannyCookingRecipesContext context)
        {
            _context = context;
        }

        // GET: api/_recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<_recipes>>> Get_recipes()
        {
            return await _context._recipes.ToListAsync();
        }

        // GET: api/recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<_recipes>> Get_recipes(int id)
        {
            var _recipes = await _context._recipes.FindAsync(id);

            if (_recipes == null)
            {
                return NotFound();
            }

            return _recipes;
        }


        [HttpGet("ingredents")]
        public async  Task<ActionResult<IEnumerable<_recipes>>> Search_Recipes([FromQuery]string ingredents )
        {
            var _recipes = await _context._recipes.Where(s => s.ingredients.Contains(ingredents)).ToListAsync();

            if (_recipes == null)
            {
                return NotFound();
            }

            return _recipes;
        }


        // PUT: api/_recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put_recipes(int id, _recipes _recipes)
        {
            if (id != _recipes.ID)
            {
                return BadRequest();
            }

            _context.Entry(_recipes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_recipesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/_recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<_recipes>> Post_recipes(_recipes _recipes)
        {
            _context._recipes.Add(_recipes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get_recipes", new { id = _recipes.ID }, _recipes);
        }

        // DELETE: api/_recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete_recipes(int id)
        {
            var _recipes = await _context._recipes.FindAsync(id);
            if (_recipes == null)
            {
                return NotFound();
            }

            _context._recipes.Remove(_recipes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool _recipesExists(int id)
        {
            return _context._recipes.Any(e => e.ID == id);
        }
    }
}
