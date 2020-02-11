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

namespace scm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    

    public class CajaController : ControllerBase
    {

        private RegistroFacturaRepository _registroFactura;
        private RegistroValeRepository _registroVales;
        private CajaRepositorio _cajaRepositorio;
        private ScmContext _context;
        private IMapper _mapper;

        public CajaController(CajaRepositorio _cajaRepositorio, ScmContext _context, IMapper _mapper, RegistroFacturaRepository registroFacturaRepository, RegistroValeRepository registroValeRepository){
            this._cajaRepositorio=_cajaRepositorio;
            this._context = _context;
            this._mapper = _mapper;
            _registroVales = registroValeRepository;
            _registroFactura = registroFacturaRepository;

        }

        [HttpPost ("inicioCaja")]
        public string InicioCaja([FromBody] CajaDtosOpen model){ ///Estamos pidiendo los datos de EmpleadoDto
                 
                // Caja.FechaApertura=DateTime.Now;
                //try{
                    Caja Caja = _mapper.Map<Caja>(model);///De dto a Empleado
                    _cajaRepositorio.Insert(Caja); ///inserta xd
                   Caja.FechaApertuta=DateTime.Now;
                    _context.SaveChanges(); ///guarda en la base de datos
                ///}catch(Exception e){
                   // Console.WriteLine(e);
                    //return "No se agrego";
                //}
            return "Se ha agregado correctamente";
        }

        [HttpPut("CierreCaja")]
                public IActionResult Put(int IdCaja, [FromBody]  CajaDtosClouse model){

                var cajaActual = _cajaRepositorio.GetById(IdCaja);
                cajaActual.FechaCiere = DateTime.Now;
                 var regs = _registroVales.getBetweenDate(cajaActual.FechaApertuta,cajaActual.FechaCiere);
                var regsDtos = _mapper.Map<List<RegisterValesResponseDto>>(regs);
                decimal monto = 0.0M;
                

                foreach(RegisterValesResponseDto registroVales in regsDtos){


                        monto += registroVales.Total;

                }


                 var regsFac = _registroFactura.getBetweenDate(cajaActual.FechaApertuta,cajaActual.FechaCiere);
                var regsFacDtos = _mapper.Map<List<RegisterFacturaIndepDto>>(regsFac);

                decimal monto2 = 0.0M;


                 foreach(RegisterFacturaIndepDto registroFactura in regsFacDtos){


                        monto2 += registroFactura.Monto;

                }
                
                cajaActual.CantidadFinal = cajaActual.CantidadInicial- monto;
                cajaActual.CantidadFinal += monto2;

            //var Caja= _mapper.Map<Caja>(model);
            _cajaRepositorio.Update(cajaActual);
            _context.SaveChanges();
            var dto = _mapper.Map<CajaDtosClouse>(cajaActual);
            return Ok(dto);
        }

    }

    


}