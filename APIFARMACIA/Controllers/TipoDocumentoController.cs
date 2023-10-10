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
    public class TipoDocumentoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoDocumentoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<TipoDeDocumento>>> Get(){
            var tiposDoc= await _unitOfWork.TiposDocumentos.GetAllAsync();
            return Ok(tiposDoc);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TipoDeDocumento>> GetId(int id){
            var tiposDoc = await _unitOfWork.TiposDocumentos.GetIdAsync(id);
            if (tiposDoc == null){
                return NotFound();
            }
            return Ok(tiposDoc);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TipoDeDocumento>> Post(TipoDocumentoDto tipoDocumentoDto){
            var documento = _mapper.Map<TipoDeDocumento>(tipoDocumentoDto);
            _unitOfWork.TiposDocumentos.Add(documento);
            await _unitOfWork.SaveAsync();
            if (documento == null){
                return BadRequest();
            }
            tipoDocumentoDto.Id = documento.Id;
            return CreatedAtAction(nameof(Post), new { id = tipoDocumentoDto.Id}, tipoDocumentoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TipoDeDocumento>> Put(int id, TipoDeDocumento tipoDeDocumento){
            if (tipoDeDocumento.Id == 0){
                tipoDeDocumento.Id = id;
            }
            if (tipoDeDocumento.Id != id){
                return BadRequest();
            }
            if (tipoDeDocumento == null){
                return NotFound();
            }
            _unitOfWork.TiposDocumentos.Update(tipoDeDocumento);
            await _unitOfWork.SaveAsync();
            return tipoDeDocumento;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var documento = await _unitOfWork.TiposDocumentos.GetIdAsync(id);
            if (documento == null){
                return NotFound();
            }
            _unitOfWork.TiposDocumentos.Remove(documento);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}