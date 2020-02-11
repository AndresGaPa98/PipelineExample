using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CargaDescarga;
using Scm.Domain;

namespace Scm.Controllers.Dtos
{
   
    public class RegisterFacturaDto
    {
        [Required]
        public string FolioFactura { get; set; }
        [Required]
        public int IdEmpresa {get; set;}
        [Required]
        public DateTime FechaInicial {get; set;}
        [Required]
        public DateTime FechaFinal {get; set;}
        [Required]
        public string Concepto {get; set;}
        [Required]
        public int StatusFactura {get; set;}
    }
    public class RegisterFacturaDateDto
    {
        [Required]
        public string FolioFactura { get; set; }
        [Required]
        public int IdEmpresa {get; set;}
        [Required]
        public List<String> ValesFolio {get; set;}
        [Required]
        public string Concepto {get; set;}
        [Required]
        public int StatusFactura {get; set;}
    }
    public class RegisterFacturaIndepDto
    {
        [Required]
        public string FolioFactura { get; set; }
        [Required]
        public string Concepto {get; set;}
        [Required]
        public decimal Monto {get; set;}        
        [Required]
        public DateTime FechaExpedicion {get; set;}
        [Required]
        public int IdEmpresa { get; set; }
        [Required]
        public int StatusFactura {get; set;}
    }
    public class RegisterFacturaResponseDto
    {
        public string FolioFactura { get; set; }
        public decimal Monto { get; set; }
        public string Concepto { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public int StatusFactura { get; set; }
        public List<Vale> Vales {get; set;}
        public int IdEmpresa { get; set; }
    }
}