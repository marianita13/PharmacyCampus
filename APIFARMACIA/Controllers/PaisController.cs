using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using APIFARMACIA.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIFARMACIA.Controllers
{
    public class PaisController : BaseController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Pais>>> Get(){
            var namevar = await _UnitOfWork.Paises.GetAllAsync();
            return Ok(namevar);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<Pais>>> GetId(int id){
            var pais = await _UnitOfWork.Paises.GetIdAsync(id);
            if (pais == null){
                return NotFound();
            }
            return Ok(pais);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Pais>> Post(PaisDto paisDto){
            var pais = _mapper.Map<Pais>(paisDto);
            this._UnitOfWork.Paises.Add(pais);
            await _UnitOfWork.SaveAsync();
            if (pais == null){
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new {id = pais.Id}, pais);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Pais>> Put (int id, [FromBody] Pais pais){
            if (pais.Id == 0){
                pais.Id = id;
            }
            if (pais.Id != id){
                return BadRequest();
            }
            if (pais == null){
                return NotFound();
            }
            _UnitOfWork.Paises.Update(pais);
            await _UnitOfWork.SaveAsync();
            return Ok(pais);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var pais = await _UnitOfWork.Paises.GetIdAsync(id);
            if (pais == null){
                return NotFound();
            }
            _UnitOfWork.Paises.Remove(pais);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}