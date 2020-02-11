using CargaDescarga;
using Scm.Domain;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Scm.Data.Repositories
{
    public class RegistroValeRepository : BaseRepository<RegistroVale>
    {

        private readonly DbSet<RegistroVale> _dbSet;
        protected readonly ScmContext _context;
        
        public RegistroValeRepository(ScmContext context) : base(context)
        {
            _context = context; 
            _dbSet = _context.Set<RegistroVale>();  
        }

        public List<RegistroVale> getBetweenDate(DateTime date,DateTime date2) //Verificar xd
        {
            return _dbSet.Where(a => a.Fecha >= date && a.Fecha <= date2).ToList();
        }


    }
}