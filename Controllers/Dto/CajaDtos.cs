using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Scm.Controllers.Dtos
{
    public class CajaDtosOpen
    {
        [Required]
        public DateTime FechaApertura{get;set;}
        [Required]
        public string Username { get; set; }
        [Required]
        public decimal CantidadInicial { get; set; }
        public int StatusCaja{get;set;}
        
    }
    public class CajaDtosClouse
    {
        public int idCaja{get;set;}
        [Required]
        public DateTime FechaCierre{get;set;}
        //[Required]
        //public decimal CantidadFinal{get;set;}

    }
}