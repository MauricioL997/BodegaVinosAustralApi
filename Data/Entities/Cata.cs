using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    internal class Cata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //
        public int Id { get; set; }
        // Fecha
        public DateTime Fecha { get; set; } 

        // Nombre de usuario
        public string username { get; set; }
        // Vinos
        public string wines { get; set; }
        // Lista de invitados 
        public List<string> invitados { get; set; }
    }
}

