using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;
using System.Data.Odbc;
using System.Data;
//using System.Data.SqlClient; // Asegúrate de importar esto si usas SqlConnection  

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


        public void saveEmpleado(int codigo, string nombre, string puesto, string departamento,int estado)
        {

            sn.guardar(codigo, nombre, puesto, departamento, estado);
        }

        public void eliminar(int llave)
        {
            // Establece la conexión a la base de datos usando ODBC  
            using (OdbcConnection connection = new OdbcConnection("Dsn=ventasemp"))
            {
                connection.Open();
                string query = "DELETE FROM empleados WHERE id_empleado = ?"; // Usa '?' como marcador de posición para parámetros  

                using (OdbcCommand command = new OdbcCommand(query, connection))
                {
                    // Usamos un parámetro para evitar inyección SQL  
                    command.Parameters.AddWithValue("?", llave); // Agrega el parámetro  
                    command.ExecuteNonQuery();
                }
            }
        }

        public void modificar(int id_empleado, string nombre, string apellido, string puesto, int estado)
        {
            // Llamar al método modificar de la capa de datos con id_empleado
            sn.modificar(id_empleado, nombre, puesto, apellido, estado);
        }

    }
}
