using System;
namespace HistoriaClinica.Models
{
    public class RegistroPaciente
    {
        public string nombre_usuario { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirmar_password { get; set; }
        public string recordarme { get; set; }
    }
}
