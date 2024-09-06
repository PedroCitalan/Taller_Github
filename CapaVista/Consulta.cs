using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;

namespace CapaVista
{
    public partial class Consulta : Form
    {
        String tabla = "empleados";
        Controlador cn = new Controlador();
        public Consulta()
        {
            InitializeComponent();
        }

        public void actualizardatagridview()
        {
            DataTable dt = cn.llenarTbl(tabla);
            Dgv_consulta.DataSource = dt;
        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            actualizardatagridview();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

  
        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Esta seguro que desea eliminar este registro?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Controlador ctriv = new Controlador();
                if (Dgv_consulta.SelectedRows.Count > 0)
                {
                    // Obtener la primera fila seleccionada
                    DataGridViewRow selectedRow = Dgv_consulta.SelectedRows[0];

                    // Obtiene el valor de la primera celda de esa fila y la convierte a entero
                    if (selectedRow.Cells[0].Value != null)
                    {
                        int llave = Convert.ToInt32(selectedRow.Cells[0].Value);
                        ctriv.eliminar(llave);
                        MessageBox.Show("Eliminado Exitosamente");
                    }
                }
                else
                {
                    // Manejar el caso en el que no hay filas seleccionadas
                    MessageBox.Show("No hay filas seleccionadas en el DataGridView.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            actualizardatagridview();
        }

        private void Dgv_consulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txt_nombre.Text = Dgv_consulta.CurrentRow.Cells[1].Value.ToString();
            txt_apellido.Text = Dgv_consulta.CurrentRow.Cells[2].Value.ToString();
            txt_puesto.Text = Dgv_consulta.CurrentRow.Cells[3].Value.ToString();
            txt_codedad.Text = Dgv_consulta.CurrentRow.Cells[4].Value.ToString();
            txt_codsexo.Text = Dgv_consulta.CurrentRow.Cells[5].Value.ToString();
            txt_estado.Text = Dgv_consulta.CurrentRow.Cells[6].Value.ToString();
       
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_ingresar_Click_1(object sender, EventArgs e)
        {

                string codigotext = txt_codempleado.Text;
                int codigo = Convert.ToInt32(codigotext);
                int codempleado = Convert.ToInt32(codigotext);
                string nombre = txt_nombre.Text;
                string apellido = txt_apellido.Text;
                string codigoedad = txt_codedad.Text;
                int codedad = Convert.ToInt32(codigoedad);
                string sexo = txt_codempleado.Text;
                string estadotexto = txt_estado.Text;
                int estado = Convert.ToInt32(estadotexto);

                try
                {
                    cn.saveEmpleado(codigo, codempleado, nombre, apellido, codedad, sexo, estado);
                    MessageBox.Show("Registro Agregado correctamente :)");
                }
                catch
                {
                    MessageBox.Show("Registro No ingresado");
                }
            }
        }
    }

