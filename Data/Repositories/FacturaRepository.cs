using Scm.Domain;
using Scm.Data.Repositories;
using System;

namespace Scm.Data{
    public class FacturaRepository : BaseRepository<Factura>
    {
        public FacturaRepository(ScmContext context) : base(context)
        {
        }

        internal object GetByID()
        {
            throw new NotImplementedException();
        }
    }
}