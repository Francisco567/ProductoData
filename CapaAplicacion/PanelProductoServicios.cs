using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion
{
    public class PanelProductoServicios
    {
        ProductoDAO productoCP = new ProductoDAO();
        
        //Mostrar productos
        public DataTable MostrarProductos()
        {
            DataTable tabla = new DataTable();
            tabla = productoCP.Mostrar();
            return tabla;
        }
    }
}
