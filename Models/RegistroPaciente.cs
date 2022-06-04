using System;
using System.ComponentModel.DataAnnotations;

namespace HistoriaClinica.Models
{
    public class RegistroPaciente
    {
        [Required(ErrorMessage ="El campo nombre de usuario es requerido")]
        public string nombre_usuario { get; set; }
        public string email { get; set; }

        [StringLength(maximumLength:15, MinimumLength =8, ErrorMessage ="Contraseña debe tener mínimo 8 caracteres, máximo 15")]
        public string password { get; set; }
        public string confirmar_password { get; set; }
        public string recordarme { get; set; }
    }
}
