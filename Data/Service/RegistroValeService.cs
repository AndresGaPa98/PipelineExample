using System;
using System.Collections.Generic;
using CargaDescarga;
using scm.Service;
using Scm.Data;
using Scm.Data.Repositories;

namespace Scm.Service
{

    public class RegistroValeService
    {   
        private RegistroValeRepository _registroValeRepository;

        private RetencionRepository _retencionRepository;

        private ScmContext _context;
        public RegistroValeService(ScmContext context, RegistroValeRepository registroValeRepository, RetencionRepository retencionRepository)
        {
            _registroValeRepository = registroValeRepository;
            _retencionRepository = retencionRepository;
            _context = context;
        }
        public ServiceResult<RegistroVale> Save(RegistroVale registroVale){

             //Validar que los vales no se hayan registrado previamente
            
            //Se deben realizar los cálculos y registro de ingreso y egreso
                registroVale.IVAAplicado = _retencionRepository.GetById("IVA").Value;
                registroVale.GastosCobranzaInversion = _retencionRepository.GetById("Gastos Cobranza Inversion").Value;
                registroVale.GastosFacturacion = _retencionRepository.GetById("Gastos Facturacion").Value;
                registroVale.GastosSeguridadSocial = _retencionRepository.GetById("Seguridad Social").Value;
                registroVale.MontoTotal = registroVale.Total();
                _registroValeRepository.Insert(registroVale);
                
                var affectedRows = _context.SaveChanges();
                if( affectedRows ==0 ) {
                    //Hubo un pex
                    var result = new ServiceResult<RegistroVale>();
                    result.isSuccess = false;
                    result.Errors = new List<string>();
                    result.Errors.Add("No se pudo guardar el registro vale");
                    return result;
                }
                else{
                    var result = new ServiceResult<RegistroVale>();
                    result.isSuccess = true;
                    result.Result = registroVale;
                    return result;
                    }


           


        }

    }
}