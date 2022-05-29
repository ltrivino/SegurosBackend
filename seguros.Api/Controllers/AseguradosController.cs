using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seguros.Api.Modelos;
using Seguros.Api.Persistencia;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seguros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AseguradosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AseguradosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Asegurados>>> getAll()
        {
            try
            {
                var asegurados = await   context.Asegurados.ToListAsync();
                return Ok(asegurados);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Asegurados>> getAll(int id)
        {
            try
            {
                var asegurado = await context.Asegurados.FirstOrDefaultAsync(asegurado =>  asegurado.id == id);
                if (asegurado == null)
                {
                    return NotFound();
                }
                return Ok(asegurado);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> crear(List<Asegurados> asegurados)
        {
            try
            {
                foreach (var asegurado in asegurados)
                {
                    context.Asegurados.Add(asegurado);
                }
                    
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
