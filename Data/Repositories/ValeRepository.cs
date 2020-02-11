using System;
using System.Collections.Generic;
using CargaDescarga;
using Scm.Domain;
using Scm.Controllers.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Scm.Data.Repositories
{
    public class ValeRepository
    {
        protected readonly ScmContext _context;
        private readonly DbSet<Vale> _dbSet;

        public ValeRepository(ScmContext context)
        {
            _context = context; 
            _dbSet = _context.Set<Vale>();   
        }

        public List<Vale> getBetweenDate(DateTime date,DateTime date2) //Verificar xd
        {
            return _dbSet.Where(a => a.FechaExpedicionVale >= date && a.FechaExpedicionVale <= date2).ToList();
        }
        public List<Vale> getByBusinessId(int emp)
        {
            return _dbSet.Where(a => a.IdEmpresa == emp ).ToList();
        }
        public List<Vale> GetAll(){
            return _dbSet.ToList();
        }

        public void Insert(Vale entity){
            _dbSet.Add(entity);
        }

        public Vale GetByFolio(string folio){
            var valeConsult = _dbSet.Where(v => v.FolioVale == folio);
            if(valeConsult.Count() < 1) // Cuenta cuantos hay actualmente segun la consulta
            {
                return null;
            }            
            return valeConsult.Single();
        }

          public void Update(Vale entity){
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(params object[] keyValues){
            var entityForDelete = _dbSet.Find(keyValues);
            _dbSet.Remove(entityForDelete);     
        }
    }

}