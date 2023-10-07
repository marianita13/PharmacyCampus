using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data
{
    public class FarmacyContext : DbContext
    {
        public FarmacyContext(DbContextOptions<FarmacyContext> options) : base(options)
        {
        }

        public DbSet<Ciudad> Ciudades {get; set;}
        public DbSet<Departamento> Departamentos {get; set;}
        public DbSet<Pais> Paises {get; set;}
        public DbSet<TipoDeDocumento> TipoDeDocumentos {get; set;}
        // protected override void OModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //     modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        // }
    }
}