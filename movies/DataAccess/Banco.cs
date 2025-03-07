﻿using Microsoft.Data.SqlClient;
using System.Data;

namespace movies.Data
{
    public class Banco
    {
        private readonly string _connectionString;

        public Banco(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void ExecutarComando(string comando, List<SqlParameter>? parametros = null)
        {
            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(comando, connection);

                if (parametros != null)
                {
                    command.Parameters.AddRange(parametros.ToArray());
                }

                command.ExecuteNonQuery();
            }
        }

        public SqlDataReader ExecutarConsulta(string comando, List<SqlParameter>? parametros = null)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(comando, connection);

            if (parametros != null)
            {
                command.Parameters.AddRange(parametros.ToArray());
            }

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
