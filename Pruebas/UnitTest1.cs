using Xunit;
using HistoriaClinica.Servicios;
using HistoriaClinica.Models;

namespace Pruebas
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();
            RegistroPaciente registroPaciente = new RegistroPaciente();
            registroPaciente.username = "Test-Usuario";
            registroPaciente.email = "test@mail.com";
            registroPaciente.password = "Test-password";
            registroPaciente.confirmacion = "Test-confirmar";
            registroPaciente.recordarme = "Test-Yes";

            int regitrosOld = repositorioPaciente.CantidadRegistros();
            await repositorioPaciente.RegistrarPaciente(registroPaciente);
            int registrosNew = repositorioPaciente.CantidadRegistros();

            Assert.Equal((regitrosOld+1),registrosNew);
        }
    }
}
