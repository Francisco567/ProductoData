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
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }

        PedidoServicio pedidoCA = new PedidoServicio();
        private String idPedido=null;

        private void MostrarPedidos()
        {
            PedidoServicio NuevoCA = new PedidoServicio();
            dtPedidos.DataSource = NuevoCA.MostrarPedidos();
        }


        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            MostrarPedidos();
        }

        private void dtPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtPedidos.SelectedRows.Count > 0)
            {
                //asignamos elv alor de la celda y columna seleccionada
                idPedido = dtPedidos.CurrentRow.Cells["Codigo"].Value.ToString();
                pedidoCA.EliminarProdcuto(idPedido);
                MessageBox.Show("Pedido elimiando satisfactoriamente");
                MostrarPedidos();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void dtPedidos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //el nombre debe ser el nombre que tiene esa columna en la base de datos 
            if (this.dtPedidos.Columns[e.ColumnIndex].Name == "Estado")
               
            {
                //Pedido Pendiente
                if (e.Value == "Pendiente")
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }

                //Pedido En Espera
                if (e.Value=="En Espera")
                {
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.Black;
                }

                //Pedido Recibido
                if (e.Value=="Recibido")
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }
    }
}
