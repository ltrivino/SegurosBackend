using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seguros.Api.Persistencia;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seguros.Api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class SegurosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public SegurosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Modelos.Seguros>>> getAll()
        {
            try
            {
                var seguros = await context.Seguros.ToListAsync();
                return Ok(seguros);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Modelos.Seguros>> GetById(int id)
        {
            try
            {
                var seguro = await context.Seguros.FirstOrDefaultAsync(seguro => seguro.id == id);

                if (seguro == null)
                {
                    return NotFound();
                }
                return Ok(seguro);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> crear(Modelos.Seguros seguro)
        {
            try
            {

                context.Seguros.Add(seguro);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Modelos.Seguros seguros, int id)
        {
            try
            {
                seguros.id = id;
                context.Update(seguros);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var existe = await context.Seguros.AnyAsync(x => x.id == id);

                if (!existe)
                {
                    return NotFound();
                }

                context.Remove(new Modelos.Seguros() { id = id });
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }





    }
}
