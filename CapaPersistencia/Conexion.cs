using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersitencia
{
    class Conexion
    {
        private SqlConnection conexion = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductoData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public SqlConnection AbrirConexion ()
        {
            if (conexion.State == ConnectionState.Closed)
                    conexion.Open();
                    return conexion;
                
  
        }

        public SqlConnection CerrarConexion ()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;

        }
    }
}
