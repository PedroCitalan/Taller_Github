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

        public void guardar(int codigo, string nombre, string puesto, string departamento, int estado)
        {
           
            string query = this.getQuery(codigo,nombre,puesto,departamento,estado);
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
