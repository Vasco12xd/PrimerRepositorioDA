using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DAL.Entities
{
    public class AuditBase
    {
        [Key]//PK
        [Required]//Obligatorio
        public virtual Guid Id { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
