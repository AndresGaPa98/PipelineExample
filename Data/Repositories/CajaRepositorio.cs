using Scm.Domain;
using Scm.Data.Repositories;
using System;

namespace Scm.Data{
        public class CajaRepositorio : BaseRepository<Caja>
    {
        
        
        
        public CajaRepositorio(ScmContext context) : base(context)
        {

        }
       

        


    }
    
}