using System;
using System.Collections.Generic;
using Scm.Domain;
using scm.Service;
using Scm.Data;
using Scm.Data.Repositories;

namespace Scm.Service
{

    public class FacturaService
    {   
        private ValeRepository _valeRepository;
        private FacturaRepository _facturaRepository;
        private RetencionRepository _retencionRepository;
        private ScmContext _context;
        public FacturaService(ScmContext context, FacturaRepository facturaRepository, ValeRepository valeRepository, RetencionRepository retencionRepository)
        {
            _valeRepository = valeRepository;
            _facturaRepository = facturaRepository;
            _retencionRepository = retencionRepository;
            _context = context;
        }
        public ServiceResult<Vale> getValeByFolio(string folio){ ///FALTA RETORNO DE ERRORES
                Vale vale = _valeRepository.GetByFolio(folio);
                var result = new ServiceResult<Vale>();
                if(vale != null)
                {
                    result.isSuccess = true;
                    result.Result = vale;
                }
                else{
                    result.isSuccess = false;
                    result.Errors = new List<string>();
                    result.Errors.Add("No existe ninguno con ese folio");
                }
                return result;
        }
        public ServiceResult<Factura> SaveIndep(Factura factura){
            var result = new ServiceResult<Factura>();
            try {    

                ///Retenciones
                factura.Monto -= factura.Monto*(_retencionRepository.GetById("IVA").Value/100);
                factura.Monto -= factura.Monto*(_retencionRepository.GetById("Gastos Cobranza Inversion").Value/100);
                factura.Monto -= factura.Monto*(_retencionRepository.GetById("Seguridad Social").Value/100);                

                _facturaRepository.Insert(factura); //Se registra la factura
                var affectedRows = _context.SaveChanges();
                if( affectedRows == 0) {
                    //Hubo un pex
                    result.isSuccess = false;
                    result.Errors = new List<string>();
                    result.Errors.Add("No se pudo guardar la factura");
                    return result;
                }
                else {                   
                    result.isSuccess = true;
                    result.Result = factura;
                    return result;
                }
            }
            catch(Exception ex) //fix
            {
                result.isSuccess = false;
                result.Errors = new List<string>();
                result.Errors.Add("No se pudo guardar la factura.");
                Console.WriteLine(ex);
                return result;
            }
        }
        public ServiceResult<Factura> Save(Factura factura, List<string> valesFolio){
            var result = new ServiceResult<Factura>();
            try {                
                if(valesFolio.Count > 0) //deben haber vales para generar una facturass
                {
                    factura.Vales = new List<Vale>();
                    foreach(string folio in valesFolio)
                    {
                        Vale v = _valeRepository.GetByFolio(folio); 
                        if(v.FacturaFolioFactura != null) //Solo para las  que no esten facturadas
                        {
                            continue;
                        }                    
                        v.FacturaFolioFactura = factura.FolioFactura;
                        factura.Vales.Add(v);
                        _valeRepository.Update(v);
                    }
                    factura.Monto = factura.montoTotal();
                    _facturaRepository.Insert(factura); //Se registra la factura
                    var affectedRows = _context.SaveChanges();
                    if( affectedRows == 0) {
                        //Hubo un pex
                        result.isSuccess = false;
                        result.Errors = new List<string>();
                        result.Errors.Add("No se pudo guardar la factura");
                        return result;
                    }
                    else {                   
                        result.isSuccess = true;
                        result.Result = factura;
                        return result;
                    }
                }                       
                result.isSuccess = false;
                result.Errors = new List<string>();
                result.Errors.Add("No se pudo guardar porque no hay vales.");
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
        public ServiceResult<Vale> getBetweenDate(DateTime date, DateTime date2)
        { ///FALTA RETORNO DE ERRORES
                
            var result = new ServiceResult<Vale>();
            try{
                result.isSuccess = true;
                result.Results = _valeRepository.getBetweenDate(date, date2);
                if(result.Results.Count < 1)
                {
                    result.isSuccess = false;
                    result.Errors = new List<string>();
                    result.Errors.Add("No existe ningun vale entre esas fechas");
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