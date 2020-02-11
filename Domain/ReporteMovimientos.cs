using System;
using CargaDescarga;

namespace Scm.Domain
{
    public class ReporteMovimientos
    {
        public decimal TotalEgreso { get; set; }
        public decimal TotalIngreso { get; set; }
       // public DateTime FechaReporte { get; set; }

        public RegistroFactura registroFactura{get;set;}
        public RegistroVale registroVale {get;set;}

        public Caja caja {get;set;}

    }
}