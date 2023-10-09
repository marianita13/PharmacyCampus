using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIFARMACIA.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;

namespace APIFARMACIA.Controllers
{
    public class DepartamentoController : BaseController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        public DepartamentoController( IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _UnitOfWork = UnitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Departamento>>> Get(){
            var departamento = await _UnitOfWork.Departamentos.GetAllAsync();
            return Ok(departamento);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<Departamento>>> GetId(int id){
            var departamento = await _UnitOfWork.Departamentos.GetIdAsync(id);
            if (departamento == null){
                return NotFound();
            }
            return Ok(departamento);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Departamento>> Post(DepartamentoDto departamentoDto){
            var departamento = _mapper.Map<Departamento>(departamentoDto);
            this._UnitOfWork.Departamentos.Add(departamento);
            await _UnitOfWork.SaveAsync();
            if(departamento == null){
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = departamento.Id}, departamento);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Departamento>> Put(int id, Departamento departamento){
            if (departamento.Id == 0){
                departamento.Id = id;
            }
            if (departamento.Id != id){
                return BadRequest();
            }
            if (departamento == null){
                return NotFound();
            }
            _UnitOfWork.Departamentos.Update(departamento);
            await _UnitOfWork.SaveAsync();
            return Ok(departamento);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var departamento = await _UnitOfWork.Departamentos.GetIdAsync(id);
            if (departamento == null){
                return NotFound();
            }
            _UnitOfWork.Departamentos.Remove(departamento);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}