using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace apiProyecto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class canchaController : ControllerBase
    {
        private readonly DBContext _Db;
        private readonly CanchaAppService _canchasAppServices;
        public canchaController(DBContext _DBcontext, CanchaAppService canchasAppServices)
        {
            _Db = _DBcontext;
            _canchasAppServices = canchasAppServices;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cancha>>> getCanchas()
        {
            return await _Db.Canchas.Include(x => x.complejo).ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cancha>> getCanchas(int id)
        {
            return await _Db.Canchas.Include(x => x.complejo).FirstOrDefaultAsync(i => i.idCancha == id);
        }

        [HttpPost]
        public async Task<ActionResult<Cancha>> postCanchas(Cancha cancha)
        {
            var respuesta = await _canchasAppServices.AgregarCancha(cancha);
            if (respuesta == null)
            {
                return Ok("Exito");
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPut("{idCancha}")]

        public async Task<ActionResult> putCanchas(int idCancha, Cancha cancha)
        {

            if (idCancha == cancha.idCancha)
            {
                _Db.Entry(cancha).State = EntityState.Modified;
                await _Db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }

        [HttpDelete("{idCancha}")]
        public async Task<ActionResult> deleteCanchas(int idCancha)
        {
            var cancha = await _Db.Canchas.FindAsync(idCancha);
            if (cancha == null)
            {
                return NotFound();
            }
            _Db.Canchas.Remove(cancha);
            await _Db.SaveChangesAsync();
            return Ok();
        }
    }
}