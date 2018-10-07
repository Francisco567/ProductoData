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
    public class PedidoDAO
    {
        private Conexion cn = new Conexion();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader leer;
        DataTable tabla = new DataTable();


        //Listar Productos
        public DataTable Mostrar()
        {
            
            cmd.Connection = cn.AbrirConexion();
           
            cmd.CommandText = "Externos.spListaPedido";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            cn.CerrarConexion();
            return tabla;
        }

        //Eliminar Pedido
        public void Eliminar(int id)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "Externos.spEliminarPedido";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodigoPedido", id);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}
