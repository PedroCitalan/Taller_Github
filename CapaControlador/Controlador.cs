﻿using System;
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


        public void saveEmpleado(int codigo, string nombre, string puesto, string departamento,int estado)
        {

            sn.guardar(codigo, nombre, puesto, departamento, estado);
        }

        public void eliminar(int llave)
        {
            sn.eliminar(llave);
        }

        public void modificar(int id_empleado, string nombre, string apellido, string puesto, int edad, int estado)
        {
            // Llamar al método modificar de la capa de datos con id_empleado
            sn.modificar(id_empleado, nombre, puesto, apellido, edad, estado);
        }


    }
}
