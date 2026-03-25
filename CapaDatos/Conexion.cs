using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        public static string Conn
        {
            get
            {
                string pc = Environment.MachineName;

                if (pc == "LAPTOP-G6CATVIE")
                    return "Data Source=LAPTOP-G6CATVIE;Initial Catalog=clothes_db;Integrated Security=True";

                if (pc == "Arturo")
                    return "Data Source=Arturo;Initial Catalog=clothes_db;Integrated Security=True";

                if (pc == "DESKTOP-RANR987")
                    return "Data Source=DESKTOP-RANR987;Initial Catalog=clothes_db;Integrated Security=True";

                throw new Exception("ur not on the team lil bro");
            }
        }
    }
}
