using System.Runtime.InteropServices;
using System;
using Scm.Domain;

namespace Scm.Domain{
    public class Vale
    {
      public string FolioVale { get; set; } 
      public decimal Monto { get; set; } 
      public DateTime FechaExpedicionVale { get; set; } 
      public Empresa Empresa { get; set; }
      public int IdEmpresa { get; set; }
      public string FacturaFolioFactura {get; set;}

    }
}