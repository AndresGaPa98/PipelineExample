using System;
using System.Collections.Generic;
using CargaDescarga;
using Scm.Domain;

namespace Scm.Domain
{
    public class Factura
    {   
        public string FolioFactura { get; set; }
        public decimal Monto { get; set; }
        public string Concepto { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public int StatusFactura { get; set; }
        public List<Vale> Vales { get; set; }
        public Empresa Empresa { get; set; }
        public int IdEmpresa { get; set; }
        
        public decimal montoTotal()
        {
            decimal SUM = 0.0M;
            foreach(Vale v in Vales)
            {
                SUM += v.Monto;
            }
            return SUM;
        }
    }
}