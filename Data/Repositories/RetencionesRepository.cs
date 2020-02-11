using CargaDescarga;

namespace Scm.Data.Repositories
{
    public class RetencionesRepository : BaseRepository<Retenciones>
    {
        public RetencionesRepository(ScmContext context) : base(context)
        {
        }
    }
}