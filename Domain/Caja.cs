using System;
using System.Collections.Generic;
using CargaDescarga;
using Scm.Domain;
namespace Scm.Domain
{
    public class Caja
    {
        public int Idcaja { get; set; }
         public string Username { get; set; }
        public int StatusCaja { get; set; }
        public decimal CantidadFinal { get; set; }
        public decimal CantidadInicial { get; set; }
        public DateTime FechaApertuta {get;set;}
        public DateTime FechaCiere {get;set;}

        //calculo para corte de caja diferencia de dinero inicial+
        // contra diferencia de dinero final
        public decimal OptenerCorte()
        {
            decimal subtotalCierre =0.0M;
            if(StatusCaja != 1){
            subtotalCierre = CantidadFinal - CantidadInicial;
            }
            return subtotalCierre; 
        }


        //Refencia un objeto de otra clase
        public AppUser Usuario {get;set;}
        public string UsuarioId {get;set;}
    }

    
}