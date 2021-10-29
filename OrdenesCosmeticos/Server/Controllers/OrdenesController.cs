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

        [HttpPost]
        public ActionResult<Orden> Post(Orden orden)
        {
            
                context.Ordenes.Add(orden);
                context.SaveChanges();
                return orden;
            
        }
    }
}
