using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/Departamento")] // Identifica el nombre mas facil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")] // Longitud max
        [Required(ErrorMessage = "Es campo {0} es obligatorio")] // Campo obligatorio
        public string Name { get; set; }

        // Asi relaciono dos tablas con EF core
        [Display(Name = "Pais")] // Correct display attribute for CountryId
        public Guid CountryId { get; set; } // Foreign Key
    }
}