using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaAplicacion
{
    public class LoginUsuarioServicio
    {
        GerenteDAO GerenteCP = new GerenteDAO();

        //Inisiar Sesion
        public SqlDataReader InisiarSesion(Gerente gerente)//llammamos al bjeto del dominio
        {
            SqlDataReader Login;

            Login = GerenteCP.InisiarSesion(gerente);//solo se coloca el objeto
            return Login;
        }

    }
}
