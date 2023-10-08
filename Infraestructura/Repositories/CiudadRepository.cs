using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;

namespace Infraestructura.Repositories;

public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
    // GETID, GETALL, ADD, ADDRANGE, FIND, REMOVE, REMOVERANGE, UPDATE
    private readonly FarmacyContext _context;

    public CiudadRepository(FarmacyContext context) : base(context)
    {
        _context = context;
    }
}
