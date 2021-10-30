using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdenesCosmeticos.Shared.Data;
using OrdenesCosmeticos.Shared.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdenesCosmeticos.Server.Controllers
{
    [ApiController]
    [Route("api/ordenes")]
    public class OrdenesController : ControllerBase
    {
        private readonly dbContext context;

        public OrdenesController(dbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<List<Orden>> Get()
        {
            //return await context.Paises.Include(x => x.Provincias).ToListAsync();
            return context.Ordenes.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Orden> Get(int id)
        {
            var orden = context.Ordenes.Where(x => x.Id == id).FirstOrDefault();
            if (orden == null)
            {
                return NotFound($"No existe el pais con id igual a {id}.");
            }
            return orden;
        }

        [HttpPost]
        public ActionResult<Orden> Post(Orden orden)
        {
            try
            {
                
            context.Ordenes.Add(orden);
                context.SaveChanges();
                return orden;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

         [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Orden orden)
        {
            if(id != orden.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var pepe = context.Ordenes.Where(x => x.Id == id).FirstOrDefault();
            if (pepe == null)
            {
                return NotFound("no existe el pais a modificar.");
            }
            pepe.Usuario = orden.Usuario;
            pepe.Compra = orden.Compra;
            try
            {
                context.Ordenes.Update(pepe);
                context.SaveChanges();
                return Ok("Los datos han sido cambiados");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var orden = context.Ordenes.Where(x => x.Id == id).FirstOrDefault();
            if (orden == null)
            {
                return NotFound($"No existe el pais con id igual a {id}.");
            }

            try
            {
                context.Ordenes.Remove(orden);
                context.SaveChanges();
                return Ok($"La orden {orden.Compra} de {orden.Usuario} ha sido borrado.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
