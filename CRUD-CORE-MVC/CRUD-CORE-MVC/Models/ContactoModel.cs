using System.ComponentModel.DataAnnotations;

namespace CRUD_CORE_MVC.Models
{
    public class ContactoModel
    {
        public int idContacto { get; set; }
        [Required (ErrorMessage ="El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required]
        public string? Telefono { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
