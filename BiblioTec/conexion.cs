using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BiblioTec
{
    class conexion
    {
        public MySqlConnection conMySql;
        public void ConectaSQL()
        {
            conMySql = new MySqlConnection("server=localhost; database=bibliotec;user = bibliotec;password = BiblioTec19; Port=3306");
            conMySql.Open();
        }
        public void DesconectaSQL()
        {
            conMySql.Close();
        }

        public String ConsultaSQL(String consulta)
        {
            String resultado;
            MySqlCommand com = new MySqlCommand(consulta, conMySql);
            resultado = Convert.ToString(com.ExecuteScalar());
            return resultado;
        }

        public MySqlDataReader reader(String consulta)
        {
             MySqlCommand Comando = new MySqlCommand(consulta, conMySql);
             MySqlDataReader read = Comando.ExecuteReader();
             return read; 
            
        }
    }
}