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
            
          

            if(!Page.IsPostBack)
            {
                Fecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenarComboBox();
            }
        }

        private void EnableAll()
        {
            ClienteDropDownList.Enabled = false;
            EliminarButton.Enabled = false;
            NombreTextBox.Enabled = true;
            DireccionTextBox.Enabled = true;
            CedulaTextBox.Enabled = true;
            TelefonoTextBox.Enabled = true;
            Fecha.Enabled = true;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
        }

        private void DisableAll()
        {
            ClienteDropDownList.Enabled = true;
            EliminarButton.Enabled = false;
            NombreTextBox.Enabled = false;
            DireccionTextBox.Enabled = false;
            CedulaTextBox.Enabled = false;
            TelefonoTextBox.Enabled = false;
            Fecha.Enabled = false;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;
        }

        private void Limpiar()
        {
            LlenarComboBox();
            ClienteDropDownList.Text = Condicion;
            NombreTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            CedulaTextBox.Text =  string.Empty;
            TelefonoTextBox.Text = string.Empty;
            Fecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            LimpiarErrores();
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
           
            EnableAll();
            Limpiar();
        }

        protected void CancelarButton_Click(object sender, EventArgs e)
        {
           
            DisableAll();
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
           
            if(Validar())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalValidar", "$('#ModalValidar').modal();", true);
                return;
            }
            if(ClienteDropDownList.Text.Equals(Condicion))
            {
                if(BLL.ClienteBLL.Guardar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Guardado');", addScriptTags: true);
                    ClienteDropDownList.DataSource = null;
                    Limpiar();
                    DisableAll();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo Guardar');", addScriptTags: true);
                    return;
                }

            }
            else
            {
                if(BLL.ClienteBLL.Modificar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Modificado');", addScriptTags: true);
                    ClienteDropDownList.DataSource = null;
                    Limpiar();
                    DisableAll();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo Modificar');", addScriptTags: true);
                    return;
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
           
            int id = Convert.ToInt32(ClienteDropDownList.SelectedValue);
            if(BLL.ClienteBLL.Eliminar(id))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['info']('Eliminado');", addScriptTags: true);
                ClienteDropDownList.DataSource = null;
                Limpiar();
                DisableAll();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo eliminar');", addScriptTags: true);
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
            
            int id = Convert.ToInt32(ClienteDropDownList.SelectedValue);
            var cliente = BLL.ClienteBLL.Buscar(id);

            NombreTextBox.Text = cliente.Nombre;
            DireccionTextBox.Text = cliente.Direccion;
            CedulaTextBox.Text = cliente.Cedula;
            TelefonoTextBox.Text = cliente.Telefono;
            Fecha.Text = cliente.Fecha.ToString("yyyy-MM-dd");
            EnableAll();
            EliminarButton.Enabled = true;
            ClienteDropDownList.Enabled = true;

        }

        private bool Validar()
        {
            bool paso = false;
           
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                NombreTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#F50303");
                NombreTextBox.ToolTip = "No puede estar vacio, Ingrese un nombre";
                paso = true;
            }
            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                DireccionTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#F50303");
                DireccionTextBox.ToolTip = "No puede estar vacio, Ingrese la direcion";
                paso = true;
            }
            
            if (CedulaTextBox.MaxLength<13)
            {
                CedulaTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#F50303");
                CedulaTextBox.ToolTip = "No esta completamente lleno, termine de ingresar la numeracion de la cedula";
                paso = true;
            }
            if (TelefonoTextBox.MaxLength<12)
            {
                TelefonoTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#F50303");
                TelefonoTextBox.ToolTip = "No esta completamente lleno, termine de ingresar la numeracion dl telefono";
                paso = true;
            }
            if (string.IsNullOrWhiteSpace(Fecha.Text))
            {
                Fecha.BackColor = System.Drawing.ColorTranslator.FromHtml("#F50303");
                Fecha.ToolTip = "No puede estar Vacio, Seleccione una fecha";
                paso = true;
            }
            return paso;
        }

        private void LimpiarErrores()
        {
            NombreTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            DireccionTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            CedulaTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

            TelefonoTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            Fecha.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
        }
    }
}