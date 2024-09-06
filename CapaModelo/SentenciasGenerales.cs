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


        public string getQuery(int codigo, string nombre, string puesto, string departamento, int estado)
        {
        string sql = "insert into empleados(codigo_empleado, nombre_completo, puesto, departamento, estado)values('" + codigo + "', '" + nombre + "', '" + puesto + "', '" + departamento + "', '" + estado + "')";
        Console.WriteLine(sql);
        return sql;
        }

        public void insertarSQL(string query)
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand(query, this.conn.conexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
