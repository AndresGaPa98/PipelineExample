using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scm.Controllers.Dtos;
using Scm.Data;
using Scm.Domain;
using Scm.Infrastructure.ManagedResponses;

namespace Scm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpresaController: ControllerBase
    {
        private const string V = "No se guardo el registro";
        private EmpresaRepository _empresaRepository;
        private ScmContext _context;
        private IMapper _mapper;

        public EmpresaController(EmpresaRepository EmpresaRepository, ScmContext context, IMapper mapper){
            _empresaRepository = EmpresaRepository;
            _context = context;
            _mapper = mapper;

        }
        [HttpPost("Agregar")]
        [Authorize]
        public string Agregar(EmpresaDtos empresa){   
                Empresa Empresa = _mapper.Map<Empresa>(empresa);
                _empresaRepository.Insert(Empresa);
                var regis = _context.SaveChanges();
                if(regis==0){
                    return "Fallo al momento de guardar";
                }
                else{
                    return "Registro guardado exitosamente";
                }
        }
        [HttpGet("BuscarID")]
        [Authorize]
        public IActionResult GetId(int idEmpresa){
            var Empresa = _empresaRepository.GetById(idEmpresa);
            if(Empresa == null)
                return NotFound();
            var emprdto = _mapper.Map<EmpresaResponseDto>(Empresa);
            return Ok(emprdto);
        }
        [HttpGet("BuscarTodos")]
        [Authorize]
        public IActionResult GetAll(){
            var empresas = _empresaRepository.GetAll();
            var EmpresasResult = _mapper.Map<List<EmpresaResponseDto>>(empresas);
            return Ok(EmpresasResult);
        }

        [HttpPut("Modificar")]
        [Authorize]
        /*Para modificar se requiere que el parametro de idEmpresa en el cuerpo del JSON sea el mismo que
        se usa al elegir una empresa para editar debido a que es llave foranea en factura y vale (ocurre
        lo mismo con la seccion de modificar del empleado)*/
        public IActionResult Put(int idEmpresa, [FromBody]  EmpresaResponseDto model){
            if(!ModelState.IsValid){
               return BadRequest(new ManagedErrorResponse(ManagedErrorCode.Validation,"Hay errores de validación",ModelState));
            }
            var empresa= _mapper.Map<Empresa>(model);
            _empresaRepository.Update(empresa);
            _context.SaveChanges();
            var dto = _mapper.Map<EmpresaResponseDto>(empresa);
            return Ok(dto);
        }
        [HttpDelete("Eliminar")]
        [Authorize]
        public IActionResult Delete(int idEmpresa){
            if(!ModelState.IsValid){
               return BadRequest(new ManagedErrorResponse(ManagedErrorCode.Validation,"Hay errores de validación",ModelState));
            }
            _empresaRepository.Delete(idEmpresa);
            _context.SaveChanges();
            return Ok();
        }

    }
}