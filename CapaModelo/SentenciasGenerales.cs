using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class SentenciasGenerales
    {
        protected Conexion conn;

        public SentenciasGenerales()
        {
            this.conn = new Conexion();
        }



        public string getQuery(int codigo, int codempleado, string nombre, string apellido, int edad, string sexo, int estado)
        {
            string sql = "INSERT INTO empleados(id_empleado, puesto, nombre_empleado, apellido_empleado, edad, sexo, estado) " +
                         "VALUES('" + codigo + "', '" + codempleado + "', '" + nombre + "', '" + apellido + "', '" + edad + "', '" + sexo + "', '" + estado + "')";
            Console.WriteLine(sql); // Para depuración
            return sql;
        }

        // Método para ejecutar una consulta SQL
        public void insertarSQL(string query)
        {
            using (OdbcCommand cmd = new OdbcCommand(query, conn.conexion()))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Datos guardados correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al guardar los datos: " + ex.Message);
                }
                finally
                {
                    conn.conexion().Close();
                }
            }
        }
    


    public string eliminarQuery(int llave)
        {
            string sql = "DELETE FROM empleados WHERE codigo_empleado = " + llave + ";";
            Console.WriteLine(sql);
            return sql;
        }

        public string getModificarQuery(int id, string n, string p, string d, int es)
        {
            string sql = "UPDATE empleados SET nombre_completo='" + n + "', puesto='" + p + "',  departamento='" + d + "',  estado=" + es + " WHERE codigo_empleado=" + id + " ";
            Console.WriteLine(sql);
            return sql;
        }
    }
}
