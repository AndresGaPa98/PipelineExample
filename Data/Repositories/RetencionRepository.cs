using CargaDescarga;

namespace Scm.Data.Repositories
{
    public class RetencionRepository : BaseRepository<Retenciones>
    {
        public RetencionRepository(ScmContext context) : base(context)
        {
            
        }
    }
}