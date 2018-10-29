using FacturacionAplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacturacionAplicada.UI.Registros
{
    public partial class Rdepartamento : System.Web.UI.Page
    {
        string Condicion = "Seleccione Para Buscar";
        bool paso = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LlenarComboBox();
                NombreTextBox.ToolTip = "Nombre de departamento";
            }

        }

        private void LlenarComboBox()
        {
            DepartamentoDropDownList.Items.Clear();
            DepartamentoDropDownList.Items.Add("Seleccione Para Buscar");
            DepartamentoDropDownList.DataSource = BLL.DepartamentoBLL.GetList(x => true);
            DepartamentoDropDownList.DataValueField = "DepartamentoId";
            DepartamentoDropDownList.DataTextField = "Nombre";
            DepartamentoDropDownList.DataBind();

            //  DepartamentoDropDownList.Items.Add(item.Nombre);
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            LlenarComboBox();
            NombreTextBox.Text = string.Empty;
            //NombreTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            if (paso)
            {
                paso = false;
                return;
            }
            if (DepartamentoDropDownList.Text == Condicion)
            {
                if (BLL.DepartamentoBLL.Guardar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Guardado');", addScriptTags: true);
                    DepartamentoDropDownList.DataSource = null;
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
                if (BLL.DepartamentoBLL.Modificar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Modificado');", addScriptTags: true);
                    DepartamentoDropDownList.DataSource = null;
                    Limpiar();

                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se pudo Modificar');", addScriptTags: true);
                    return;
                }
            }
        }

        private Departamento LlenaClase()
        {
            Departamento depo = new Departamento();
            if (DepartamentoDropDownList.Text == Condicion)
            {
                depo.DepartamentoId = 0;
            }
            else
            {
                depo.DepartamentoId = Convert.ToInt32(DepartamentoDropDownList.SelectedValue);
            }


            depo.Nombre = NombreTextBox.Text;
            return depo;
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (DepartamentoDropDownList.Text != Condicion)
            {
                int id = Convert.ToInt32(DepartamentoDropDownList.SelectedValue);
                if (BLL.DepartamentoBLL.Eliminar(id))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['info']('Eliminado');", addScriptTags: true);
                    DepartamentoDropDownList.DataSource = null;
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

        protected void DepartamentoDropDownList_TextChanged(object sender, EventArgs e)
        {

            if (DepartamentoDropDownList.Text != Condicion)
                NombreTextBox.Text = DepartamentoDropDownList.SelectedItem.Text;
            else
                NuevoButton_Click(sender, e);
         
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

        protected void CustomValidator1_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            if (BLL.DepartamentoBLL.GetList(t => t.Nombre == NombreTextBox.Text).Exists(t => t.Nombre
            == NombreTextBox.Text) && DepartamentoDropDownList.SelectedItem.Text == Condicion)
            {
                args.IsValid = false;
                paso = true;
            }
            else
            {
                paso = false;
                args.IsValid = true;
            }
        }
    }
}