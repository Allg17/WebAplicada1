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
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                LlenarComboBox();
                EnableFalse();
                NombreTextBox.ToolTip = "Nombre de departamento";


            }
          
        }

        private bool Validar()
        {
            bool paso = false;
           
            if (BLL.DepartamentoBLL.GetList(t => t.Nombre == NombreTextBox.Text).Exists(t => t.Nombre
            == NombreTextBox.Text) && DepartamentoDropDownList.SelectedItem.Text == Condicion)
            {
                NombreTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#F50303");
                NombreTextBox.ToolTip = "Departamento existente, ingrese otro";
                paso = true;
            }

                return paso;
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
           
           

            DepartamentoDropDownList.Enabled = false;
            EnableTrue();

        }
        private void Limpiar()
        {
            LlenarComboBox();
            NombreTextBox.Text = string.Empty;
            //NombreTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {       //Evalua si se esta logueado
          

            if(Validar())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalValidar", "$('#ModalValidar').modal();", true);
                return;
            }

            if (DepartamentoDropDownList.Text == Condicion)
            {
                if (BLL.DepartamentoBLL.Guardar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Guardado');", addScriptTags: true);
                    DepartamentoDropDownList.DataSource = null;
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
                if (BLL.DepartamentoBLL.Modificar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Modificado');", addScriptTags: true);
                    DepartamentoDropDownList.DataSource = null;
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
            
            int id = Convert.ToInt32(DepartamentoDropDownList.SelectedValue);
            if (BLL.DepartamentoBLL.Eliminar(id))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['info']('Eliminado');", addScriptTags: true);
                DepartamentoDropDownList.DataSource = null;
                Limpiar();
                EnableFalse();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo eliminar');", addScriptTags: true);
            }
        }

        protected void DepartamentoDropDownList_TextChanged(object sender, EventArgs e)
        {
            
            if (DepartamentoDropDownList.Text != Condicion)
                NombreTextBox.Text = DepartamentoDropDownList.SelectedItem.Text;

            EnableTrue();
           
            EliminarButton.Enabled = true;
        }

        protected void CancelarButton_Click(object sender, EventArgs e)
        {
           
            Limpiar();
            EnableFalse();

        }

        private void EnableFalse()
        {
            NuevoButton.Enabled = true;
            DepartamentoDropDownList.Enabled = true;
            GuardarButton.Enabled = false;
            EliminarButton.Enabled = false;
            CancelarButton.Enabled = false;
            NombreTextBox.ReadOnly = true;
        }

        private void EnableTrue()
        {
            NuevoButton.Enabled = false;

            GuardarButton.Enabled = true;
            NombreTextBox.ReadOnly = false;
            CancelarButton.Enabled = true;
        }

     

 
    }
}