using APIFARMACIA.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace APIFARMACIA.Controllers;

public class CiudadController : BaseController
{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _mapper;

    public CiudadController(IUnitOfWork unitOfWork, IMapper mapper){
        _UnitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Ciudad>>> Get(){
        var nameVar = await _UnitOfWork.Ciudades.GetAllAsync();
        return Ok(nameVar);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<IEnumerable<Ciudad>>> Get(int id){
        var ciudad = await _UnitOfWork.Ciudades.GetIdAsync(id);
        return Ok(ciudad); 
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Ciudad>> Post(CiudadDto ciudadDto){
        var ciudad = _mapper.Map<Ciudad>(ciudadDto);
        this._UnitOfWork.Ciudades.Add(ciudad);
        await _UnitOfWork.SaveAsync();
        if (ciudad==null){
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = ciudad.Id }, ciudad);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Ciudad>> Put(int id, [FromBody] Ciudad ciudad){
        if (ciudad.Id == 0){
            ciudad.Id=id;
        }
        if (ciudad.Id != id){
            return BadRequest();
        }
        if (ciudad == null){
            return NotFound();
        }
        _UnitOfWork.Ciudades.Update(ciudad);
        await _UnitOfWork.SaveAsync();
        return ciudad;
    }

    public async Task<ActionResult> Delete(int id){
        var ciudad = await _UnitOfWork.Ciudades.GetIdAsync(id);
        if (ciudad == null){
            return NotFound();
        }
        _UnitOfWork.Ciudades.Remove(ciudad);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
}
