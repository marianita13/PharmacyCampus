using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;

namespace Infraestructura.Repositories;

    public class PaisRepository : GenericRepository<Pais>, IPais
    {
        private readonly FarmacyContext _context;
        public PaisRepository(FarmacyContext context) : base(context){
            _context = context;
        }
    }
