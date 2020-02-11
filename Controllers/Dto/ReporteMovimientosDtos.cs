using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scm.Controllers.Dtos
{
    public class ReporteMovimientosDtos
    {
         
            public decimal MontoTotal{get;set;}

    }
    public class MontoMovientosDtos
    {
            public int IdRegistroVale {get;set;}
            public decimal MontoTotal{get;set;}

    }

    public class ReporteMovFacDtos
    {
         
            public decimal Monto{get;set;}

    }
    public class MovimientosFacturas {
            public string FolioFactura { get; set; }
            
            public decimal Monto {get;set;}
    }

            
}