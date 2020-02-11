using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using CargaDescarga;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Scm.Controllers.Dtos;
using Scm.Service;
using Scm.Domain;
using Scm.Data;

namespace Scm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    
    [ProducesResponseType(401, Type = typeof(string))]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService _facturaService;

        private IMapper _mapper;
        private ScmContext _context;

        
        public FacturaController(FacturaService facturaService,FacturaService valeService, IMapper mapper, ScmContext context)
        {
            _facturaService = facturaService;
            _mapper = mapper;
            _context= context;
        }

        private string CurrentUserId(ClaimsPrincipal claims){
                return claims.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        /////CREAR FACTURA CON LOS VALES QUE ESTAN ENTRE LAS FECHAS QUE SE ESPECIFIQUEN
        [HttpGet("betweendate")]
        public IActionResult AgregarEntreDate([FromBody] RegisterFacturaDto model){ ///Estamos pidiendo los datos de EmpleadoDto
               
                    Factura factura = _mapper.Map<Factura>(model);
                    var valeResult = _facturaService.getBetweenDate(model.FechaInicial,model.FechaFinal);
                    if(!valeResult.isSuccess)
                    {
                        return BadRequest(valeResult.Errors);
                    }       
                    factura.FechaExpedicion = DateTime.Now; //Fecha de hoy
                    factura.Vales = valeResult.Results;
                    factura.Monto = factura.montoTotal();

                    var facturaResult = _facturaService.Save(factura, null);
                    if (facturaResult.isSuccess) {
                        return Ok(_mapper.Map<RegisterFacturaResponseDto>(facturaResult.Result));
                    }
                    else{
                        return BadRequest(facturaResult.Errors);
                    }
        }
        //Crear la factura seleccionando vales especificos
        [HttpPost]
        public IActionResult Agregar([FromBody] RegisterFacturaDateDto model){ ///Estamos pidiendo los datos de EmpleadoDto
               
                    Factura factura = _mapper.Map<Factura>(model);
                    if(model.ValesFolio.Count < 1)
                    {
                        return BadRequest("No se seleccionaron vales.");
                    }       
                    factura.FechaExpedicion = DateTime.Now; //Fecha de hoy
                    //factura.Monto = factura.montoTotal();

                    var facturaResult = _facturaService.Save(factura, model.ValesFolio);
                    if (facturaResult.isSuccess) {
                        return Ok(_mapper.Map<RegisterFacturaResponseDto>(facturaResult.Result));
                    }
                    else{
                        return BadRequest(facturaResult.Errors);
                    }
        }
        //Factura indeentediente
        [HttpPost("independiente")]
        public IActionResult AgregarIndep([FromBody] RegisterFacturaIndepDto model){ ///Estamos pidiendo los datos de EmpleadoDto
               
                    Factura factura = _mapper.Map<Factura>(model);
                    factura.FechaExpedicion = DateTime.Now; //Fecha de hoy

                    var facturaResult = _facturaService.SaveIndep(factura);
                    if (facturaResult.isSuccess) {
                        return Ok(_mapper.Map<RegisterFacturaResponseDto>(facturaResult.Result));
                    }
                    else{
                        return BadRequest(facturaResult.Errors);
                    }
        }

        [HttpPost("vale/filter/date")]        
        public IActionResult filterByDate(DateTime date,DateTime date2){
                
                var valesResult = _facturaService.getBetweenDate(date, date2);
                if (valesResult.isSuccess){
                    var result = _mapper.Map<List<ValeDto>>(valesResult.Results);
                    return Ok(result);
                }else{
                        return BadRequest(valesResult.Errors);
                }               
        }
        
    }
}