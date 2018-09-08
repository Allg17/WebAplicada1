using FacturacionAplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacturacionAplicada.UI.Registros
{
    public partial class Rusuarios : System.Web.UI.Page
    {
        string Condicion = "Seleccione Para Buscar";
        bool paso = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LlenarComboBox();
                EnableFalse();
                FechaDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                NombreToolTip();
            }

          

        }

        private void LlenarComboBox()
        {
            
            UsuarioDropDownList.Items.Clear();
            UsuarioDropDownList.Items.Add("Seleccione Para Buscar");
            UsuarioDropDownList.DataSource = BLL.UsuarioBLL.GetList(x => true);
            UsuarioDropDownList.DataValueField = "IdUsuario";
            UsuarioDropDownList.DataTextField = "NombreUsuario";
            UsuarioDropDownList.DataBind();

        }

        private void EnableTrue()
        {
            NuevoButton.Enabled = false;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
            NombreTextBox.Enabled = true;
            NombreUsuarioTextBox.Enabled = true;
            ContraseñaTextBox.Enabled = true;
            RepetirContraseñaTextBox.Enabled = true;
            ComentarioTextBox.Enabled = true;
            FechaDate.Enabled = true;
        }

        private void EnableFalse()
        {
            NuevoButton.Enabled = true;
            UsuarioDropDownList.Enabled = true;
            GuardarButton.Enabled = false;
            EliminarButton.Enabled = false;
            CancelarButton.Enabled = false;
            NombreTextBox.Enabled = false;
            NombreUsuarioTextBox.Enabled = false;
            ContraseñaTextBox.Enabled = false;
            RepetirContraseñaTextBox.Enabled = false;
            ComentarioTextBox.Enabled = false;
            FechaDate.Enabled = false;
        }

        private void NombreToolTip()
        {
            NombreTextBox.ToolTip = "Nombre";
            NombreUsuarioTextBox.ToolTip = "Nombre Usuario";
            ContraseñaTextBox.ToolTip = "Contraseña";
            RepetirContraseñaTextBox.ToolTip = "Repetir Contraseña";
            ComentarioTextBox.ToolTip = "Comentario";
            FechaDate.ToolTip = "Fecha";
        }

        protected void ContraseñaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ContraseñaCheckBox.Checked)
            {
                ContraseñaTextBox.Attributes["type"] = "singel-line";
                RepetirContraseñaTextBox.Attributes["type"] = "singel-line";
            }
            else
            {
                ContraseñaTextBox.Attributes["type"] = "password";
                RepetirContraseñaTextBox.Attributes["type"] = "password";
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
           

            UsuarioDropDownList.Enabled = false;
            EnableTrue();


        }

        private void Limpiar()
        {
            LlenarComboBox();
            NombreTextBox.Text = string.Empty;
            NombreUsuarioTextBox.Text = string.Empty;
            ContraseñaTextBox.Text = string.Empty;
            RepetirContraseñaTextBox.Text = string.Empty;
            ComentarioTextBox.Text = string.Empty;
            FechaDate.Text = string.Empty;
            //Volviendo los textbox a su color normal

        }

        private void LimpiarErrores()
        {
            NombreTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            NombreUsuarioTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            ContraseñaTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            RepetirContraseñaTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            ComentarioTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            FechaDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
        }

        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            
            Limpiar();
            EnableFalse();
        }

        protected void UsuarioDropDownList_TextChanged(object sender, EventArgs e)
        {
           

            int id = Convert.ToInt32(UsuarioDropDownList.SelectedValue);
            var item = BLL.UsuarioBLL.Buscar(id);
            NombreTextBox.Text = item.Nombre;
            NombreUsuarioTextBox.Text = item.NombreUsuario;
            ContraseñaTextBox.Text = item.Clave;
            RepetirContraseñaTextBox.Text = item.Clave;
            ComentarioTextBox.Text = item.Comentario;
            FechaDate.Text = item.Fecha.ToString("yyyy-MM-dd");

            EnableTrue();
            EliminarButton.Enabled = true;
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
           

            int id = Convert.ToInt32(UsuarioDropDownList.SelectedValue);
            if (BLL.UsuarioBLL.Eliminar(id))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['info']('Eliminado');", addScriptTags: true);
                UsuarioDropDownList.DataSource = null;
                Limpiar();
                EnableFalse();


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo eliminar');", addScriptTags: true);
            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            if (paso)
                return;

            if (UsuarioDropDownList.Text == Condicion)
            {
                if (BLL.UsuarioBLL.Guardar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Guardado');", addScriptTags: true);
                    UsuarioDropDownList.DataSource = null;
                    Limpiar();
                    EnableFalse();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo Guardar');", addScriptTags: true);
                    return;
                }

            }
            else
            {
                if (BLL.UsuarioBLL.Modificar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Modificado');", addScriptTags: true);
                    UsuarioDropDownList.DataSource = null;
                    Limpiar();
                    EnableFalse();
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo Modificar');", addScriptTags: true);
                    return;
                }
            }
        }

        private Usuario LlenaClase()
        {
            Usuario user = new Usuario();
            if (UsuarioDropDownList.Text == Condicion)
            {

                user.IdUsuario = 0;
            }
            else
            {
                user.IdUsuario = Convert.ToInt32(UsuarioDropDownList.SelectedValue);
            }

            user.NombreUsuario = NombreUsuarioTextBox.Text;
            user.Nombre = NombreTextBox.Text;
            user.Clave = ContraseñaTextBox.Text; 
            user.Fecha = Convert.ToDateTime(FechaDate.Text);
            user.Comentario = ComentarioTextBox.Text;

            return user;
        }

        protected void CustomValidator1_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            var nombre = (BLL.UsuarioBLL.GetList(x => x.NombreUsuario == NombreUsuarioTextBox.Text)).ElementAt(0).NombreUsuario;
            if (args.Value.Equals(nombre))
            {
                args.IsValid = false;
                paso = true;
            }
            else
                args.IsValid = true;
        }
    }
}