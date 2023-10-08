using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infraestructura.Data;
using Infraestructura.Repositories;

namespace Infraestructura.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FarmacyContext _context;
        public UnitOfWork(FarmacyContext context){
            _context = context;
        }

        public ICiudad _Ciudades;
        public IDepartamento _Departamentos;
        public IPais _Paises;

        public ICiudad Ciudades{
            get{
                if (_Ciudades == null){
                    _Ciudades = new CiudadRepository(_context);
                }
                return _Ciudades;
            }
        }

        public IDepartamento Departamentos{
            get{
                if (_Departamentos == null){
                    _Departamentos = new DepartamentoRepository(_context);
                }
                return _Departamentos;
            }
        }

        public IPais Paises{
            get{
                if (_Paises == null){
                    _Paises = new PaisRepository(_context);
                }
                return _Paises;
            }
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}