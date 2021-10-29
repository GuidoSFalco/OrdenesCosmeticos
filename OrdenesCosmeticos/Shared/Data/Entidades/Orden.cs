using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesCosmeticos.Shared.Data.Entidades
{
    [Index(nameof(Id), Name = "UQ_Orden_Id", IsUnique = true)]
    public class Orden
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe realizar una compra.")]
        public string Compra { get; set; }

        [Required(ErrorMessage = "Debe ingresr su nombre.")]
        public string Usuario { get; set; }

    }
}
