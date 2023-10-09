using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace APIFARMACIA.Dtos
{
    public class PaisDto
    {
        public int Id {get; set;}
        public string Nombre { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}