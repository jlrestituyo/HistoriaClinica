using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using HistoriaClinica.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HistoriaClinica.Servicios
{
    public interface IRepositorioPaciente {
        Task RegistrarPaciente(RegistroPaciente registroPaciente);
        Task<IEnumerable<RegistroPaciente>> Obtener();
    }

    public class RepositorioPaciente: IRepositorioPaciente
    {

        private readonly string connectionString;

        public RepositorioPaciente(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            connectionString = "Server=historiaclinica.cuwafqgzccx1.us-east-1.rds.amazonaws.com;database=historiaclinica;User Id=admin; password=12345678;TrustServerCertificate=true";

        }

        public RepositorioPaciente()
        {
            connectionString = "Server=historiaclinica.cuwafqgzccx1.us-east-1.rds.amazonaws.com;database=historiaclinica;User Id=admin; password=12345678;TrustServerCertificate=true";

        }

        public async Task RegistrarPaciente(RegistroPaciente registroPaciente)
        {


            using (var conexion = new SqlConnection(connectionString))
            {

                try {
                   await conexion.QueryAsync($@"insert into RegistroPaciente " +
                                        "(username, email, password, confirmacion)" +
                                        "values" +
                                        "(@username, @email, @password, @confirmacion) ", registroPaciente);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Test");
                }

                
            }

                               
        }

        public int CantidadRegistros()
        {
            int cantidadRegistros = 0;
            using (var conexion = new SqlConnection(connectionString))
            {
                cantidadRegistros = conexion.QuerySingle<int>($@"select count(*) from RegistroPaciente");
            }

            return cantidadRegistros;
        }

        public async Task<IEnumerable<RegistroPaciente>> Obtener()
        {
            using var conexion = new SqlConnection(connectionString);
            return await conexion.QueryAsync<RegistroPaciente>(@"Select * from RegistroPaciente");
        }


    }
}
