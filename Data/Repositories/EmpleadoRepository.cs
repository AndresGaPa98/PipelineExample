using Scm.Domain;
using Scm.Data.Repositories;
using System;

namespace Scm.Data{
    public class EmpleadoRepository : BaseRepository<Empleado>
    {
        public EmpleadoRepository(ScmContext context) : base(context)
        {
        }

        internal object GetByID()
        {
            throw new NotImplementedException();
        }
    }
}