using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Scm.Controllers.Dtos;
using Scm.Domain;
using Scm.Infrastructure.Authentication;
using Scm.Infrastructure.ManagedResponses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Scm.Data;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace scm.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpleadoController:ControllerBase
    {

      
        private EmpleadoRepository _EmpleadoRepository;
     
        private ScmContext _context;
        private IMapper _mapper;
        public EmpleadoController(EmpleadoRepository _EmpleadoRepository, ScmContext _context, IMapper _mapper){
            this._EmpleadoRepository = _EmpleadoRepository;
            this._context = _context;
            this._mapper = _mapper;

        }
        [HttpPost ("Agregar")]
        public string Agregar([FromBody] EmpleadoDtos model){ ///Estamos pidiendo los datos de EmpleadoDto
                try{
                    Empleado Empleado = _mapper.Map<Empleado>(model);///De dto a Empleado
                    _EmpleadoRepository.Insert(Empleado); ///inserta xd
                    
                    _context.SaveChanges(); ///guarda en la base de datos
                }catch(Exception e){
                    Console.WriteLine(e);
                    return "No se agrego";
                }
            return "Se ha agregado correctamente";
        }



        [HttpDelete("Eliminar")]
        public string Eliminar(int IdEmpleado){
                try{
                    
                    _EmpleadoRepository.Delete(IdEmpleado); ///inserta xd       
                    _context.SaveChanges(); ///guarda en la base de datos
                }catch(Exception e){
                    Console.WriteLine(e);
                    return e.ToString();
                    
                }
            return "Se ha eliminado correctamente";
        }
        [HttpGet("Todos")]
        public IActionResult Get(){
            var Emps = _EmpleadoRepository.GetAll();
            var EmpsDtos = _mapper.Map<List<EmpleadoResponseDto>>(Emps);
            return Ok(EmpsDtos);
        }
        [HttpGet ("BuscarID")]
        public IActionResult GetId(int idEmpleado){
            var Emp = _EmpleadoRepository.GetById(idEmpleado);
            if(Emp == null)
                return NotFound();
            var EmpsDtos = _mapper.Map<EmpleadoResponseDto>(Emp);
            return Ok(EmpsDtos);
        }
        [HttpPut("Modificar")]
        public IActionResult Modificar(int idEmpleado, [FromBody] EmpleadoUpdateDto model){
             
        var Emp = _mapper.Map<Empleado>(model);
        _EmpleadoRepository.Update(Emp);
        _context.SaveChanges();
            var Dto = _mapper.Map<EmpleadoResponseDto>(Emp);
            
            return Ok(Dto);
        }

    }
}