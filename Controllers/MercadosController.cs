using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MercadoFinanciero.Models;

namespace MercadoFinanciero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercadosController : ControllerBase
    {
        private readonly MercadoContext _context;

        public MercadosController(MercadoContext context)
        {
            _context = context;
        }

        // GET: api/Mercados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MercadoF>>> GetMercadoFs()
        {
            return await _context.MercadoFs.ToListAsync();
        }

        // GET: api/Mercados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MercadoF>> GetMercadoF(string id)
        {
            var mercadoF = await _context.MercadoFs.FindAsync(id);

            if (mercadoF == null)
            {
                return NotFound();
            }
            var randomNumber = new Random().Next(0, 100);
            mercadoF.Ultimo = mercadoF.Ultimo * randomNumber;
            
            //Actualizando el valor
            if( mercadoF.Ultimo > mercadoF.Max){
                mercadoF.Max = mercadoF.Ultimo;
            }

              await _context.SaveChangesAsync();


            return mercadoF;

        }

        // PUT: api/Mercados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMercadoF(string id, MercadoF mercadoF)
        {
            if (id != mercadoF.Nombre)
            {
                return BadRequest();
            }

            _context.Entry(mercadoF).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MercadoFExists(id))
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

        // POST: api/Mercados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MercadoF>> PostMercadoF(MercadoF mercadoF)
        {
            _context.MercadoFs.Add(mercadoF);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MercadoFExists(mercadoF.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMercadoF", new { id = mercadoF.Nombre }, mercadoF);
        }

        // DELETE: api/Mercados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMercadoF(string id)
        {
            var mercadoF = await _context.MercadoFs.FindAsync(id);
            if (mercadoF == null)
            {
                return NotFound();
            }

            _context.MercadoFs.Remove(mercadoF);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MercadoFExists(string id)
        {
            return _context.MercadoFs.Any(e => e.Nombre == id);
        }
    }
}
