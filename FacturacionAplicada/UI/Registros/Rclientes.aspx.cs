using FacturacionAplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacturacionAplicada.UI.Registros
{
    public partial class Rclientes : System.Web.UI.Page
    {
        private string Condicion = "Select one";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Fecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenarComboBox();
            }
        }

        private void Limpiar()
        {
            LlenarComboBox();
            ClienteDropDownList.Text = Condicion;
            NombreTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            Fecha.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }

        private void LlenarComboBox()
        {

            ClienteDropDownList.Items.Clear();
            ClienteDropDownList.Items.Add(Condicion);
            ClienteDropDownList.DataSource = BLL.ClienteBLL.GetList(x => true);
            ClienteDropDownList.DataValueField = "IdCliente";
            ClienteDropDownList.DataTextField = "Nombre";
            ClienteDropDownList.DataBind();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            //if (Validar())
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalValidar", "$('#ModalValidar').modal();", true);
            //    return;
            //}


            if (ClienteDropDownList.Text.Equals(Condicion))
            {
                if (BLL.ClienteBLL.Guardar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Guardado');", addScriptTags: true);
                    ClienteDropDownList.DataSource = null;
                    Limpiar();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se pudo Guardar');", addScriptTags: true);
                    return;
                }

            }
            else
            {
                if (BLL.ClienteBLL.Modificar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Modificado');", addScriptTags: true);
                    ClienteDropDownList.DataSource = null;
                    Limpiar();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se pudo Modificar');", addScriptTags: true);
                    return;
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (!ClienteDropDownList.Text.Equals(Condicion))
            {
                int id = Convert.ToInt32(ClienteDropDownList.SelectedValue);
                if (BLL.ClienteBLL.Eliminar(id))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['info']('Eliminado');", addScriptTags: true);
                    ClienteDropDownList.DataSource = null;
                    Limpiar();


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se pudo eliminar');", addScriptTags: true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se pudo eliminar');", addScriptTags: true);
                NuevoButton_Click(sender, e);
             
            }
        }

        private Cliente LlenaClase()
        {
            Cliente customer = new Cliente();
            if (ClienteDropDownList.Text.Equals(Condicion))
                customer.IdCliente = 0;
            else
                customer.IdCliente = Convert.ToInt32(ClienteDropDownList.Text);

            customer.Nombre = NombreTextBox.Text;
            customer.Direccion = DireccionTextBox.Text;
            customer.Cedula = CedulaTextBox.Text;
            customer.Telefono = TelefonoTextBox.Text;
            customer.Fecha = Convert.ToDateTime(Fecha.Text);
            return customer;
        }

        protected void ClienteDropDownList_TextChanged(object sender, EventArgs e)
        {
            if (!ClienteDropDownList.Text.Equals(Condicion))
            {
                int id = Convert.ToInt32(ClienteDropDownList.SelectedValue);
                var cliente = BLL.ClienteBLL.Buscar(id);

                NombreTextBox.Text = cliente.Nombre;
                DireccionTextBox.Text = cliente.Direccion;
                CedulaTextBox.Text = cliente.Cedula;
                TelefonoTextBox.Text = cliente.Telefono;
                Fecha.Text = cliente.Fecha.ToString("yyyy-MM-dd");
                EliminarButton.Enabled = true;
                ClienteDropDownList.Enabled = true;
            }
            else
            {
                NuevoButton_Click(sender, e);
              
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (args.Value.Equals(Condicion))
            {
                args.IsValid = false;
            }
            else
                args.IsValid = true;
        }
    }
}