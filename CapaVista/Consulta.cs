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

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrEmpty(txt_codigo.Text) ||
                    string.IsNullOrEmpty(txt_nombre.Text) ||
                    string.IsNullOrEmpty(txt_apellido.Text) ||
                    string.IsNullOrEmpty(txt_puesto.Text) ||
                    string.IsNullOrEmpty(txt_edad.Text) ||
                    string.IsNullOrEmpty(txt_sexo.Text) ||
                    string.IsNullOrEmpty(txt_estado.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.");
                    return;
                }

                // Captura de datos
                int id_empleado = Convert.ToInt32(txt_codigo.Text);
                string nombre = txt_nombre.Text;
                string apellido = txt_apellido.Text;
                string puesto = txt_puesto.Text;
                int edad = Convert.ToInt32(txt_edad.Text);
                string sexo = txt_sexo.Text;
                int estado = Convert.ToInt32(txt_estado.Text);

                cn.saveEmpleado(id_empleado, nombre, apellido, edad, puesto, sexo, estado);

                // Mensaje de confirmación
                MessageBox.Show("Empleado ingresado correctamente.");

                // Actualizar el DataGridView
                actualizardatagridview();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en el formato de los datos. Verifica que el ID, edad y estado sean números.");
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otra excepción
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }


        //BOTON ELIMINAR
        private void button2_Click(object sender, EventArgs e)
        {
            // Mostramos un mensaje de confirmación al usuario para verificar si realmente desea eliminar el registro.  
            if (MessageBox.Show("¿Está seguro que desea eliminar este registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Verifica si se ha seleccionado al menos una fila en el DataGridView.  
                if (Dgv_consulta.SelectedRows.Count > 0)
                {
                    // Obtener la primera fila seleccionada del DataGridView.  
                    DataGridViewRow selectedRow = Dgv_consulta.SelectedRows[0];

                    // Compramos si la primera celda de la fila seleccionada no es nula.  
                    if (selectedRow.Cells[0].Value != null)
                    {
                        try
                        {
                            // Convertimos el valor de la primera celda a un entero, que se usará como llave para eliminar el registro. 
                            int llave = Convert.ToInt32(selectedRow.Cells[0].Value);
                            // Llamamos al método 'eliminar' del controlador, pasando la llave del registro a eliminar.  
                            cn.eliminar(llave);
                            MessageBox.Show("Eliminado exitosamente");
                            actualizardatagridview();
                        }
                        catch (FormatException ex)
                        {
                            MessageBox.Show("Error al convertir el valor: " + ex.Message);
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show("Error en la cadena de conexión: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrió un error: " + ex.Message);
                        }
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
            txt_codigo.Text = Dgv_consulta.CurrentRow.Cells[0].Value.ToString();
            txt_nombre.Text = Dgv_consulta.CurrentRow.Cells[1].Value.ToString();
            txt_puesto.Text = Dgv_consulta.CurrentRow.Cells[2].Value.ToString();
            txt_sexo.Text = Dgv_consulta.CurrentRow.Cells[3].Value.ToString();
            txt_estado.Text = Dgv_consulta.CurrentRow.Cells[4].Value.ToString();
       
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrEmpty(txt_codigo.Text) ||
                    string.IsNullOrEmpty(txt_nombre.Text) ||
                    string.IsNullOrEmpty(txt_apellido.Text) ||
                    string.IsNullOrEmpty(txt_puesto.Text) ||
                    string.IsNullOrEmpty(txt_edad.Text) ||
                    string.IsNullOrEmpty(txt_sexo.Text) ||
                    string.IsNullOrEmpty(txt_estado.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.");
                    return;
                }

                // Captura de datos
                int id_empleado = Convert.ToInt32(txt_codigo.Text);
                string nombre = txt_nombre.Text;
                string apellido = txt_apellido.Text;
                string puesto = txt_puesto.Text;
                int edad = Convert.ToInt32(txt_edad.Text);
                string sexo = txt_sexo.Text;
                int estado = Convert.ToInt32(txt_estado.Text);

                // Llama al método modificar en el controlador
                cn.modificar(id_empleado, nombre, apellido, edad, puesto, sexo, estado);

                // Mensaje de confirmación
                MessageBox.Show("Empleado modificado correctamente.");

                // Actualizar el DataGridView
                actualizardatagridview();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en el formato de los datos. Verifica que el ID, edad y estado sean números.");
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otra excepción
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void Consulta_Load(object sender, EventArgs e)
        {

        }
    }
}
