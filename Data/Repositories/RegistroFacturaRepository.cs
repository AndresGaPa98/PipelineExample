using Scm.Domain;
using Scm.Data.Repositories;
using System;
using CargaDescarga;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Scm.Data{
    public class RegistroFacturaRepository : BaseRepository<RegistroFactura>
    {
        private readonly DbSet<RegistroFactura> _dbSet;
        protected readonly ScmContext _context;
        public RegistroFacturaRepository(ScmContext context) : base(context)
        {
            _context = context; 
            _dbSet = _context.Set<RegistroFactura>();  
        }

        internal object GetByID()
        {
            throw new NotImplementedException();
        }

         public List<RegistroFactura> getBetweenDate(DateTime date,DateTime date2) //Verificar xd
        {
            return _dbSet.Where(a => a.Fecha >= date && a.Fecha <= date2).ToList();

        }
        
    }
}