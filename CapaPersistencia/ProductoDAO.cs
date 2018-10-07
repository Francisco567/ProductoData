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
    public class ProductoDAO
    {
        private Conexion cn = new Conexion();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader leer;
        DataTable tabla = new DataTable();


        //Listar Productos
        public DataTable Mostrar()
        {
            //transac sql
            cmd.Connection = cn.AbrirConexion();
            //cmd.CommandText = "select * from Productos";
            //procedimiento alamacenado
            cmd.CommandText = "Almacen.spListaProductos";
            cmd.CommandType = CommandType.StoredProcedure;//espcificamos q es un procedimiento
            leer = cmd.ExecuteReader();//devuelve filas
            tabla.Load(leer);
            cn.CerrarConexion();
            return tabla;


        }

        //Editar Productos
        public void Editar(Producto producto)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "Almacen.spEditarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NombreProducto", producto.ProductoNombre);
            cmd.Parameters.AddWithValue("@DescripcionProducto", producto.ProductoDescripcion);
            cmd.Parameters.AddWithValue("@PrecioCompraProducto", producto.ProductoPrecioCompra);
            cmd.Parameters.AddWithValue("@PrecioVentaProducto", producto.ProductoPrecioVenta);
            cmd.Parameters.AddWithValue("@UnidadesVendidasProducto", producto.ProductoUnidadesVendidas);
            cmd.Parameters.AddWithValue("@MarcaProducto", producto.ProductoMarca);
            cmd.Parameters.AddWithValue("@StockProducto", producto.ProductoStock);
            cmd.Parameters.AddWithValue("@RegistroFecha", producto.FechaDeRegistro);
            cmd.Parameters.AddWithValue("@CodigoCategoria", producto.CategoriaCodigo);
            cmd.Parameters.AddWithValue("@CodigoPedido", producto.PedidoCodigo);
            cmd.Parameters.AddWithValue("@CodigoGerente", producto.GerenteCodigo);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }


        public DataTable ListaCategorias()
        {
            DataTable table = new DataTable();
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "spListaCategorias";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            table.Load(leer);//cargamos loas archivos
            leer.Close();
            cn.CerrarConexion();
            return table;

        }

        public DataTable ListaMarcas()
        {
            DataTable table = new DataTable();
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "ListarMarcas";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            table.Load(leer);//cargamos loas archivos
            leer.Close();
            cn.CerrarConexion();
            return table;

        }

    }
}
