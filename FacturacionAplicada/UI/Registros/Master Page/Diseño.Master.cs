using FacturacionAplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacturacionAplicada.UI.Registros.Master_Page
{
    public partial class Diseño : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!BLL.HerramientasBLL.Login)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalLogIn", "$('#ModalLogIn').modal();", true);
            //}

            if (!Page.IsPostBack)
            {
                UsuarioTextBox.Text = BLL.HerramientasBLL.returnUsuario().Nombre;
                //if (!BLL.MenuBLL.RetornarLogin())
                //{
                //    FormsAuthentication.RedirectToLoginPage();
                //}

            }
        }

        protected void CerrarSesionButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            BLL.HerramientasBLL.Login = false;


        }

        protected void UsuariosButton_Click(object sender, EventArgs e)
        {
            //if(BLL.MenuBLL.RetornarLogin())
            //{
            Server.Transfer("/UI/Registros/Rusuarios.aspx");
            //}
            //else
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
        }

        protected void ClientesButton_Click(object sender, EventArgs e)
        {
            //if (BLL.MenuBLL.RetornarLogin())
            //{
            Server.Transfer("/UI/Registros/Rclientes.aspx");
            //}
            //else
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
        }

        protected void ArticulosButton_Click(object sender, EventArgs e)
        {
            //if (BLL.MenuBLL.RetornarLogin())
            //{
            Server.Transfer("/UI/Registros/Rarticulos.aspx");
            //}
            //else
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
        }

        protected void EntradaArticulosButton_Click(object sender, EventArgs e)
        {
            //if (BLL.MenuBLL.RetornarLogin())
            //{
            Server.Transfer("/UI/Registros/RentradaArticulo.aspx");
            //}
            //else
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
        }

        protected void DepartamentoButton_Click(object sender, EventArgs e)
        {
            //if (BLL.MenuBLL.RetornarLogin())
            //{
            Server.Transfer("/UI/Registros/Rdepartamento.aspx");
            //}
            //else
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
        }

        protected void FarturacionButton_Click(object sender, EventArgs e)
        {
            //if (BLL.MenuBLL.RetornarLogin())
            //{
            Server.Transfer("/UI/Registros/Rfacturacion.aspx");
            //}
            //else
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
        }

        protected void IniciarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuario, bool>> filtrar = x => true;
            Usuario user = new Usuario();
            Validar();
            filtrar = t => t.NombreUsuario.Equals(NombreUsuarioTextBox.Text) && t.Clave.Equals(ClaveTextBox.Text);
            if (BLL.UsuarioBLL.GetList(filtrar).Count() != 0)
            {
                user = BLL.UsuarioBLL.GetList(filtrar).ElementAt(0);
                BLL.HerramientasBLL.NombreLogin(user.Nombre, user.IdUsuario);
                BLL.HerramientasBLL.Login = true;
                Server.Transfer("/UI/Registros/Menu.aspx");
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

        protected void DepartamentoConsultaButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("/UI/Consulta/ConsultaDepartamento.aspx");
        }
    }
}