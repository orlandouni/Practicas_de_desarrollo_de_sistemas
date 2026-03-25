using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNBitacora
    {
        public static DataTable Listar()
        {
            CDBitacora Datos = new CDBitacora();
            return Datos.Listar();
        }

        public static DataTable BuscarUsuario(string textobuscar)
        {
            CDBitacora Datos = new CDBitacora();
            Datos.Buscar = textobuscar;
            return Datos.BuscarUsuario(Datos);
        }

        public static DataTable BuscarRegistro(string textobuscar)
        {
            CDBitacora Datos = new CDBitacora();
            Datos.Buscar = textobuscar;
            return Datos.BuscarRegistro(Datos);
        }

        public static DataTable Filtrar(string tabla, string operacion)
        {
            CDBitacora datos = new CDBitacora();
            return datos.Filtrar(tabla, operacion);
        }

        public static DataTable FiltrarPorFecha(DateTime fecha)
        {
            CDBitacora datos = new CDBitacora();
            return datos.FiltrarPorFecha(fecha);
        }


    }
}
