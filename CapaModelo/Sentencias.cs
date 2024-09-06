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

        public OdbcDataAdapter llenarTbl(string tabla)
        {
            string sql = "SELECT * FROM " + tabla + ";";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.conexion());
            return dataTable;
        }

        public void guardar(int codigo, int codempleado, string nombre, string apellido, int edad, string sexo, int estado)
        {
            // Se llama al método getQuery con los parámetros correspondientes
            string query = getQuery(codigo, codempleado, nombre, apellido, edad, sexo, estado);

            // Se ejecuta la consulta SQL de inserción
            this.insertarSQL(query);
        }

        public void eliminar(int llave)
        {
            string query = this.eliminarQuery(llave);
            this.insertarSQL(query);
        }

        public void modificar(int id, string n, string p, string d, int es)
        {
            string query = this.getModificarQuery(id, n, p, d, es);
            this.insertarSQL(query);
        }
    }
}
