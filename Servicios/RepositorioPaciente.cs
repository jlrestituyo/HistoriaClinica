﻿using System;
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
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void RegistrarPaciente(RegistroPaciente registroPaciente)
        {


            using (var conexion = new SqlConnection(connectionString))
            {

                try {
                    conexion.Query($@"insert into RegistroPaciente " +
                                        "(username, email, password, confirmacion)" +
                                        "values" +
                                        "(@nombre_usuario, @email, @password, @confirmar_password) ", registroPaciente);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ttest");
                }

                
            }

                               
        }


    }
}
