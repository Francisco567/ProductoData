using CapaAplicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmProductos : Form
    {
        PanelProductoServicios productoCA = new PanelProductoServicios();

        public FrmProductos()
        {
            InitializeComponent();
        }

        private void MostrarProductos()
        {
            PanelProductoServicios NuevoCA = new PanelProductoServicios();
            dtProductos.DataSource = NuevoCA.MostrarProductos();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void dtProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void dtProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //el nombre debe ser el nombre que tiene esa columna en la base de datos 
            if (this.dtProductos.Columns[e.ColumnIndex].Name == "Stock")
            {
                //Stock Completo
                if (Convert.ToInt32(e.Value) <= 20)
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                }

                //Stock por Agotarse
                if (Convert.ToInt32(e.Value) <= 8)
                {
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.Black;
                }

                //Stock Agotado
                if (Convert.ToInt32(e.Value) <= 0)
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmEditarProducto FrmEdit = new FrmEditarProducto();
            if (dtProductos.SelectedRows.Count > 0)
            {
               /* FrmEdit.txtMarca = dtProductos.CurrentRow.Cells["Marca"].Value.ToString();
                FrmEdit.txtNombreProducto = dtProductos.CurrentRow.Cells["Nombre"].Value.ToString();
                FrmEdit.txtDescripcion = dtProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
                FrmEdit.txtPCompra = dtProductos.CurrentRow.Cells["Precio de Compra"].Value.ToString();
                FrmEdit.txtPVenta = dtProductos.CurrentRow.Cells["Precio de Venta"].Value.ToString();
                FrmEdit.txtVenta = dtProductos.CurrentRow.Cells["Unidades Vendidas"].Value.ToString();
                FrmEdit.txtStock = dtProductos.CurrentRow.Cells["Stock"].Value.ToString();*/
                FrmEdit.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }
    }
}
