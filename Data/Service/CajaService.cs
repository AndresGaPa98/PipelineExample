using System;
using System.Collections.Generic;
using CargaDescarga;
using scm.Service;
using Scm.Data;
using Scm.Data.Repositories;
using Scm.Domain;

namespace Scm.Service
{
    public class CajaService
    {
        private RegistroValeRepository _RegistroVale;

        private RegistroFacturaRepository _registroFactura;
        private CajaRepositorio _cajaRepositorio;
        private ScmContext _context;
        public CajaService(ScmContext context,CajaRepositorio cajaRepositorio, RegistroValeRepository registroVale, RegistroFacturaRepository registroFactura)
        {
            _cajaRepositorio = cajaRepositorio;
            _registroFactura = registroFactura;
            _RegistroVale = registroVale;
            _context = context;

        }
       

         public ServiceResult<RegistroVale> GetRegistrosVales(DateTime date, DateTime date2)
        { 

            var result = new ServiceResult<RegistroVale>();
            try{
                result.isSuccess = true;
                result.Results = _RegistroVale.getBetweenDate(date, date2);
                if(result.Results.Count < 1)
                {
                    result.isSuccess = false;
                    result.Errors = new List<string>();
                    result.Errors.Add("No existe ningun registro de vales entre esas fechas");
                }
                return result;
            }
            catch(Exception ex)
            {
                result.isSuccess = false;
                result.Errors = new List<string>();
                result.Errors.Add(ex.ToString());
                return result;
            }
        }

         public ServiceResult<RegistroFactura> GetRegistrosFactura(DateTime date, DateTime date2)
        { 

            var result = new ServiceResult<RegistroFactura>();
            try{
                result.isSuccess = true;
                result.Results = _registroFactura.getBetweenDate(date, date2);
                if(result.Results.Count < 1)
                {
                    result.isSuccess = false;
                    result.Errors = new List<string>();
                    result.Errors.Add("No existe ningun registro de factura entre esas fechas");
                }
                return result;
            }
            catch(Exception ex)
            {
                result.isSuccess = false;
                result.Errors = new List<string>();
                result.Errors.Add(ex.ToString());
                return result;
            }
        }
    }
}