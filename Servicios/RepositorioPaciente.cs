using System;
using Dapper;
using HistoriaClinica.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HistoriaClinica.Servicios
{
    public interface IRepositorioPaciente {
        void RegistrarPaciente(RegistroPaciente registroPaciente);
    }

    public class RepositorioPaciente: IRepositorioPaciente
    {

        private readonly string connectionString;

        public RepositorioPaciente(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnectio");
        }

        public void RegistrarPaciente(RegistroPaciente registroPaciente)
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Query($@"insert into RegistroPaciente " +
                    "(username, email, password, confirmacion)" +
                    "values" +
                    "(@nombre_usuario, @email, @password, @confirmacion) ", registroPaciente);
            }
        }
    }
}
