using System.ComponentModel.DataAnnotations;

namespace Scm.Controllers.Dtos
{
    public class EmpresaDtos
    {
        [Required]
        public string  NombreEmpresa { get; set; }
    }

    public class EmpresaResponseDto
    {
        public int IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
    }
}