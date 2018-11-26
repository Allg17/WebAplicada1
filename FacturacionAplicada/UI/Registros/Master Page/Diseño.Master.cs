using FacturacionAplicada.Entidades;
using Microsoft.Reporting.WebForms;
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

            if (!Page.IsPostBack)
            {
                //UsuarioTextBox.Text = BLL.HerramientasBLL.user.Nombre;

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
            Server.Transfer("/UI/Registros/Rusuarios.aspx");
        }

        protected void ClientesButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("/UI/Registros/Rclientes.aspx");  
        }

        protected void ArticulosButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("/UI/Registros/Rarticulos.aspx");
        }

        protected void EntradaArticulosButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("/UI/Registros/RentradaArticulo.aspx");
        }

        protected void DepartamentoButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("/UI/Registros/Rdepartamento.aspx");
        }

        protected void FarturacionButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("/UI/Registros/Rfacturacion.aspx");
        }

        protected void IniciarButton_Click(object sender, EventArgs e)
        {
            //Expression<Func<Usuario, bool>> filtrar = x => true;
            //Usuario user = new Usuario();
            //Validar();
            //filtrar = t => t.NombreUsuario.Equals(NombreUsuarioTextBox.Text) && t.Clave.Equals(ClaveTextBox.Text);
            //if (BLL.UsuarioBLL.GetList(filtrar).Count() != 0)
            //{
            //    user = BLL.UsuarioBLL.GetList(filtrar).ElementAt(0);
            //    BLL.HerramientasBLL.NombreLogin(user.Nombre, user.IdUsuario);
            //    BLL.HerramientasBLL.Login = true;
            //    Server.Transfer("/UI/Registros/Menu.aspx");
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['warning']('Usuario o contraseña Incorrecto');", addScriptTags: true);
            //}
         
        }

        //private bool Validar()
        //{
        //    bool paso = false;
        //    if (UsuarioTextBox.Text == string.Empty)
        //    {

        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['warning']('Nombre de usuario vacio');", addScriptTags: true);
        //        paso = true;
        //    }
        //    if (ClaveTextBox.Text == string.Empty)
        //    {

        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['warning']('contraseña vacio');", addScriptTags: true);
        //        paso = true;
        //    }
        //    return paso;
        //}

        protected void DepartamentoConsultaButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("/UI/Consulta/ConsultaDepartamento.aspx");
        }

        protected void UsuariosConsultaButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("/UI/Consulta/ConsultaDeUsuarios.aspx");
        }

        protected void cFacturacionButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("/UI/Consulta/cFactura.aspx");
        }

        protected void cArticulosButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("/UI/Consulta/cArticulos.aspx");
        }

        protected void cClientesButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("/UI/Consulta/cClientes.aspx");
        }

        protected void EntradaButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("/UI/Consulta/cEntradaArticulos.aspx");
        }
    }
}