using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;
using System.Data.Odbc;
using System.Data;

namespace CapaControlador
{
    public class Controlador
    {
        Sentencias sn = new Sentencias();

        public DataTable llenarTbl(String tabla)
        {
            OdbcDataAdapter dt = sn.llenarTbl(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        public void saveEmpleado(int codigo, int codempleado, string nombre, string apellido, int edad, string sexo, int estado)
        {
            // Se llama al método guardar del objeto sn con los parámetros correspondientes
            sn.guardar(codigo, codempleado, nombre, apellido, edad, sexo, estado);
        }

        public void ingresar(int codigo, int codempleado, string nombre, string apellido, int edad, string sexo, int estado)
        {
            // Guardar los datos del empleado
            saveEmpleado(codigo, codempleado, nombre, apellido, edad, sexo, estado);

        }


        // Método para actualizar el DataGridView después de guardar un empleado
        public DataTable actualizarTabla(string tabla)
        {
            return llenarTbl(tabla);
        }



        public void eliminar(int llave)
        {
            sn.eliminar(llave);
        }

        public void modificar(int id, string n, string p, string d, int es)
        {
            this.sn.modificar(id, n, p, d, es);
        }
    }
}