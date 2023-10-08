using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;

namespace APIFARMACIA.Controllers
{
    public class DepartamentoController : BaseController
    {
        private readonly FarmacyContext _context;
        private readonly IMapper _mapper;
        public DepartamentoController( FarmacyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // [HttpGet]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]

        // public async Task<ActionResult<IEnumerable<Departamento>>>
    }
}