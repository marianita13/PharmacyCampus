using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Ciudad : BaseEntity
    {
        [Required]
        public string Nombre { get; set; }
        public int IdDepartamento { get; set; }
        public Departamento Departamentos { get; set; }
    }
}