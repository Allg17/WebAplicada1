using FacturacionAplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacturacionAplicada
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void IniciarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuario, bool>> filtrar = x => true;
            Usuario user = new Usuario();
            Validar();


            filtrar = t => t.NombreUsuario.Equals(UsuarioTextBox.Text) && t.Clave.Equals(ClaveTextBox.Text);
            if (BLL.UsuarioBLL.GetList(filtrar).Count() != 0)
            {
                FormsAuthentication.RedirectFromLoginPage(user.Nombre, true);
                user = BLL.UsuarioBLL.GetList(filtrar).ElementAt(0);
                BLL.HerramientasBLL.user = user;
                //BLL.HerramientasBLL.NombreLogin(user.Nombre, user.IdUsuario);
                //BLL.HerramientasBLL.Login = true;

                //Server.Transfer("/UI/Registros/Menu.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['warning']('Usuario o contraseña Incorrecto');", addScriptTags: true);
            }
        }

        private bool Validar()
        {
            bool paso = false;
            if (UsuarioTextBox.Text == string.Empty)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['warning']('Nombre de usuario vacio');", addScriptTags: true);
                paso = true;
            }
            if (ClaveTextBox.Text == string.Empty)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['warning']('contraseña vacio');", addScriptTags: true);
                paso = true;
            }
            return paso;
        }
    }
}