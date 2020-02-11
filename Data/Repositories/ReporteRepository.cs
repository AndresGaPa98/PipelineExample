using Scm.Domain;
using Scm.Data.Repositories;
using System;
using System.Collections.Generic;
using Scm.Controllers.Dtos;

namespace Scm.Data{
    public class ReporteRepository : BaseRepository<ReporteMovimientos>
    {
        public ReporteRepository(ScmContext context) : base(context)
        {
        }

        // Aqui irian metodos adicionales para funciones extra .
        public decimal GetSubTotal (List<ReporteMovimientosDtos> Algo){
            decimal suma  =0.0M;
            if(Algo != null && Algo.Count>0){
                foreach(var value in Algo)
                suma +=value.MontoTotal;
            }
            //Vales.Select(x=>suma=x.Monto);
            return suma;
         }

         
        public decimal GetIngresos (List<ReporteMovFacDtos> Algo){
            decimal suma  =0.0M;
            if(Algo != null && Algo.Count>0){
                foreach(var value in Algo)
                suma +=value.Monto;
            }
            //Vales.Select(x=>suma=x.Monto);
            return suma;
         }

         

         
        

         

    }
}