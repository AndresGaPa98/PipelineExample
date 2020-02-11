using System.ComponentModel.DataAnnotations;

namespace Scm.Controllers.Dtos
{
    /// <summary>
    /// Dto for register new users
    /// </summary>
    public class EmpleadoDtos
    {
        
        
        [Required]
        [MinLength (10)]
        [MaxLength(60)]
        
        public string Nombre { get; set; }
        [Required]
        
        public int Tipo { get; set; }
        [Required]
        public string NumeroContacto { get; set; }
    }
    public class EmpleadoResponseDto {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        
        
        public int Tipo { get; set; }
        
        public string NumeroContacto { get; set; }
    }
    public class EmpleadoUpdateDto{
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        
        
        public int Tipo { get; set; }
        
        public string NumeroContacto { get; set; }
    }
}