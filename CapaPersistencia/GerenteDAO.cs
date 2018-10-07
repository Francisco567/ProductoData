using CapaDominio;
using CapaPersitencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia
{
    public class GerenteDAO
    {
        private Conexion conexion = new Conexion();
        private SqlDataReader leer;

        public SqlDataReader InisiarSesion(Gerente gerente)//instanaciamos al objeto de la capa Dominio
        {

            SqlCommand cn = new SqlCommand("Administracion.spLoginGerente", conexion.AbrirConexion());//abrir conexion
            cn.CommandType = CommandType.StoredProcedure;
            cn.Parameters.AddWithValue("@UserGerente", gerente.GerenteUser);//los de arriba
            cn.Parameters.AddWithValue("@PasswordGerente", gerente.GerentePassword);

            leer = cn.ExecuteReader();
            return leer;
        }



    }
}
