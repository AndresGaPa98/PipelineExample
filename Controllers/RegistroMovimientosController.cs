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
using Scm.Data.Repositories;
using CargaDescarga;
using Microsoft.AspNetCore.Authorization;

namespace Scm.Controllers
{
[Route("api/[controller]")]
    [ApiController]
    [Authorize]
    
    public class RegistroMovimientosController:ControllerBase{

        private FacturaRepository _FacturaRepository;
        private RegistroValeRepository _registroValeRepository;

        private ReporteRepository _reporteRepository;
     private IMapper _mapper;

public RegistroMovimientosController(RegistroValeRepository registroValeRepository, IMapper mapper,ReporteRepository _reporteRepository,FacturaRepository _FacturaRepository){

    _registroValeRepository = registroValeRepository;
   this._FacturaRepository = _FacturaRepository;
    _mapper = mapper;
    this._reporteRepository = _reporteRepository;
}

        [HttpGet("Lista-Egresos")]
        public IActionResult getLista(){
            var Regs = _registroValeRepository.GetAll();
             var RegsDtos1 = _mapper.Map<List<MontoMovientosDtos>>(Regs);
            return Ok(RegsDtos1);
        }
        [HttpGet("Total-Egresos")]
        public IActionResult GetAll(){
            var Regs = _registroValeRepository.GetAll();
            
            
            //public static T[] FindAll<T> (T[] array, Predicate<T> match);

            var RegsDtos1 = _mapper.Map<List<ReporteMovimientosDtos>>(Regs);
            
            decimal total = _reporteRepository.GetSubTotal(RegsDtos1);

          //  RegsDtos = _reporteRepository.GetSubTotal(RegsDtos);

            return Ok(total);
        }

        [HttpGet("Total-Ingresos")]
        public IActionResult GetIngresos(){
            var Regs = _FacturaRepository.GetAll();
            
            
            //public static T[] FindAll<T> (T[] array, Predicate<T> match);

            var RegsDtos1 = _mapper.Map<List<ReporteMovFacDtos>>(Regs);
            
            decimal total = _reporteRepository.GetIngresos(RegsDtos1);

          //  RegsDtos = _reporteRepository.GetSubTotal(RegsDtos);

            return Ok(total);
        }
         [HttpGet("Lista-Ingresos")]
        public IActionResult getListaIng(){
             var Regs = _FacturaRepository.GetAll();
             var RegsDtos1 = _mapper.Map<List<MovimientosFacturas>>(Regs);
            return Ok(RegsDtos1);
        }


        


    }







}