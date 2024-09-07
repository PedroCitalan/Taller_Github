using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;


namespace CapaModelo
{
    public class Sentencias : SentenciasGenerales
    {
        Conexion con = new Conexion();

        public Sentencias()
        {
            this.conn = new Conexion();
        }

        public OdbcDataAdapter llenarTbl(string tabla)
        {
            string sql = "SELECT * FROM " + tabla + ";";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.conexion());
            return dataTable;
        }

        public void guardar(int id_empleado, string nombre, string puesto, string apellido, int edad, string sexo, int estado)
        {
           
            string query = "insert into empleados values ('" + id_empleado + "', '" + puesto + "', '" + nombre + "', '" + apellido + "', '" + edad + "', '" + sexo + "', '" + estado + "')";
            using (OdbcCommand command = new OdbcCommand(query, conn.conexion()))
            {
                command.ExecuteNonQuery();
            }
        }

        public void eliminar(int llave)
        {
            string query = this.eliminarQuery(llave);
            this.insertarSQL(query);
        }
        public void modificar(int id_empleado, string nombre, string puesto, string apellido, int edad, string sexo, int estado)
        {
            try
            {
                // Modificar la consulta para usar id_empleado
                string query = $"UPDATE empleados SET nombre_empleado = '{nombre}', id_puesto = '{puesto}', apellido_empleado = '{apellido}', edad = {edad}, sexo = '{sexo}', estado = {estado} " +
                               $"WHERE id_empleado = {id_empleado};";

                // Verificación para comprobar la consulta
                Console.WriteLine($"Query: {query}");

                using (OdbcCommand command = new OdbcCommand(query, conn.conexion()))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar datos: {ex.Message}");
            }
        }





    }
}
