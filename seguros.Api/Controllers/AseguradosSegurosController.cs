using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seguros.Api.Modelos;
using Seguros.Api.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seguros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AseguradosSegurosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AseguradosSegurosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet()]
        [Route("seguros-asegurados/{id:int}")]
        public async Task<ActionResult<List<AseguradosSeguros>>> GetById(int id)
        {
            try
            {
                var seguros = await context.AseguradosSeguros.Where(x => x.aseguradosId == id).ToListAsync();

                if (seguros == null)
                {
                    return NotFound();
                }
                return Ok(seguros);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet()]
        [Route("asegurados-seguros/{id:int}")]
        public async Task<ActionResult<List<AseguradosSeguros>>> GetByAsegurados(int id)
        {
            try
            {
                var seguros = await context.AseguradosSeguros.Where(x => x.segurosId == id).ToListAsync();

                if (seguros == null)
                {
                    return NotFound();
                }
                return Ok(seguros);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> crear(List<AseguradosSeguros> aseguradosSeguros)
        {
            try
            {

                foreach (var aseguradoSeguro in aseguradosSeguros)
                {
                    context.AseguradosSeguros.Add(aseguradoSeguro);
                }

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
