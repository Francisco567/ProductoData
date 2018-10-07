using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion
{
    public class PedidoServicio
    {
        PedidoDAO PedidoCP = new PedidoDAO();

        //Mostrar Pedidos
        public DataTable MostrarPedidos()
        {
            DataTable tabla = new DataTable();
            tabla = PedidoCP.Mostrar();
            return tabla;
        }

        //Eliminar Pedido
        public void EliminarProdcuto(String id)
        {
            PedidoCP.Eliminar(Convert.ToInt32(id));
        }
    }
}
