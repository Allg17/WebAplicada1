using FacturacionAplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacturacionAplicada.UI.Registros
{
    public partial class Rarticulos : System.Web.UI.Page
    {
        private string Condicion = "Select One";

        protected void Page_Load(object sender, EventArgs e)
        {

            

            if (!Page.IsPostBack)
            {
                LlenarComboBox();
                DisableALL();
                FechaDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenarDepartamento();
            }
        }

        private void EnableALL()
        {
            NuevoButton.Enabled = false;
            EliminarButton.Enabled = false;
            ArticuloDropDownList.Enabled = false;
            DescripcionTextBox.Enabled = true;
            PrecioTextBox.Enabled = true;
            GananciaTextBox.Enabled = true;
            CantidadTextBox.Enabled = true;
            FechaDate.Enabled = true;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
            DepartamentoDropDownList.Enabled = true;
            CostoNumeric.Enabled = true;

        }

        private void DisableALL()
        {
            NuevoButton.Enabled = true;
            EliminarButton.Enabled = false;
            ArticuloDropDownList.Enabled = true;
            DescripcionTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
            GananciaTextBox.Enabled = false;
            CantidadTextBox.Enabled = false;
            FechaDate.Enabled = false;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;
            DepartamentoDropDownList.Enabled = false;
            CostoNumeric.Enabled = false;
        }

        private void LlenarComboBox()
        {
            var lista = BLL.ProductoBLL.GetList(x => true);
            ArticuloDropDownList.Items.Clear();
            ArticuloDropDownList.Items.Add("Select One");
            ArticuloDropDownList.DataSource = lista;
            ArticuloDropDownList.DataValueField = "Idproducto";
            ArticuloDropDownList.DataTextField = "Descripcion";
            ArticuloDropDownList.DataBind();
        }

        private void LlenarDepartamento()
        {

            DepartamentoDropDownList.Items.Clear();
            DepartamentoDropDownList.DataSource = BLL.DepartamentoBLL.GetList(x => true);
            DepartamentoDropDownList.DataValueField = "DepartamentoId";
            DepartamentoDropDownList.DataTextField = "Nombre";
            DepartamentoDropDownList.DataBind();
        }

        private void Limpiar()
        {
            LlenarComboBox();
            ArticuloDropDownList.Text = Condicion;
            DescripcionTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            GananciaTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            FechaDate.Text = string.Empty;
            CostoNumeric.Text = string.Empty;
        
            LimpiarErrores();

        }

        private Producto LlenaClase()
        {
            Producto producto = new Producto();
            if (ArticuloDropDownList.Text.Equals(Condicion))
            {
                producto.Idproducto = 0;
            }
            else
            {
                producto.Idproducto = Convert.ToInt32(ArticuloDropDownList.SelectedValue);
            }

            if (string.IsNullOrWhiteSpace(CantidadTextBox.Text))
                producto.Cantidad = 0;
            else
                producto.Cantidad = Convert.ToInt32(CantidadTextBox.Text);

            producto.Descripcion = DescripcionTextBox.Text;
            producto.Precio = Convert.ToInt32(PrecioTextBox.Text);
            producto.DepartamentoId = Convert.ToInt32(DepartamentoDropDownList.SelectedValue);
            producto.Costo = Convert.ToDecimal(CostoNumeric.Text);
            producto.Ganancia = Convert.ToDecimal(GananciaTextBox.Text);
            producto.Fecha = Convert.ToDateTime(FechaDate.Text);

            return producto;

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
           
            Limpiar();
            EnableALL();
        }

        protected void CancelarButton_Click(object sender, EventArgs e)
        {
           
            DisableALL();
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            
            LimpiarErrores();
            if(Validar())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalValidar", "$('#ModalValidar').modal();", true);
                return;
            }

            if (ArticuloDropDownList.Text.Equals(Condicion))
            {
                if (BLL.ProductoBLL.Guardar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Guardado');", addScriptTags: true);
                    ArticuloDropDownList.DataSource = null;
                    DisableALL();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo Guardar');", addScriptTags: true);
                    return;
                }
            }
            else
            {
                if (BLL.ProductoBLL.Modificar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Modificado');", addScriptTags: true);
                    ArticuloDropDownList.DataSource = null;
                    Limpiar();
                    DisableALL();

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
           

            int id = Convert.ToInt32(ArticuloDropDownList.SelectedValue);
            if (BLL.ProductoBLL.Eliminar(id))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['info']('Eliminado');", addScriptTags: true);
                ArticuloDropDownList.DataSource = null;
                Limpiar();
                DisableALL();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo eliminar');", addScriptTags: true);
            }
        }

        protected void CostoNumeric_TextChanged(object sender, EventArgs e)
        {
           
            if (!PrecioTextBox.Text.Equals(string.Empty))
            {
                GananciaTextBox.Text = BLL.HerramientasBLL.CalcularGanancia(Convert.ToDecimal(PrecioTextBox.Text), Convert.ToDecimal(CostoNumeric.Text)).ToString();
            }
        }

        protected void PrecioTextBox_TextChanged(object sender, EventArgs e)
        {
           
            if (!CostoNumeric.Text.Equals(string.Empty))
            {
                GananciaTextBox.Text = BLL.HerramientasBLL.CalcularGanancia(Convert.ToDecimal(PrecioTextBox.Text), Convert.ToDecimal(CostoNumeric.Text)).ToString();
            }
        }

        protected void ArticuloDropDownList_TextChanged(object sender, EventArgs e)
        {
           
            int id = Convert.ToInt32(ArticuloDropDownList.SelectedValue);

            var item = BLL.ProductoBLL.Buscar(id);
            DescripcionTextBox.Text = item.Descripcion;
            DepartamentoDropDownList.SelectedIndex = item.DepartamentoId;
            PrecioTextBox.Text = item.Precio.ToString();
            CostoNumeric.Text = item.Costo.ToString();
            GananciaTextBox.Text = Convert.ToInt32(item.Ganancia).ToString();
            CantidadTextBox.Text = item.Cantidad.ToString();
            FechaDate.Text = item.Fecha.ToString("yyyy-MM-dd");
            EnableALL();
            EliminarButton.Enabled = true;



        }

        private bool Validar()
        {
            bool paso = false;
            if(string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                DescripcionTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#F50303");
                DescripcionTextBox.ToolTip = "No puede estar vacio, Ingrese una Descripcion";
                paso = true;
            }
            if(string.IsNullOrWhiteSpace(PrecioTextBox.Text))
            {
                PrecioTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#F50303");
                PrecioTextBox.ToolTip = "No puede estar vacio, Ingrese un presio";
                paso = true;
            }
            if(string.IsNullOrWhiteSpace(CostoNumeric.Text))
            {
                CostoNumeric.BackColor = System.Drawing.ColorTranslator.FromHtml("#F50303");
                CostoNumeric.ToolTip = "No puede estar vacio, Ingrese el Costo del Articulo";
                paso = true;
            }
            if(string.IsNullOrWhiteSpace(FechaDate.Text))
            {
                FechaDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#F50303");
                FechaDate.ToolTip = "No puede estar vacio, Ingrese la fecha";
                paso = true;
            }
            if(DepartamentoDropDownList.Text.Equals(Condicion))
            {
                DepartamentoDropDownList.BackColor = System.Drawing.ColorTranslator.FromHtml("#F50303");
                DepartamentoDropDownList.ToolTip = "No puede estar seleccionado este Campo, Ingrese un Departamento";
                paso = true;
            }
            return paso;
        }

        private void LimpiarErrores()
        {
            DescripcionTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            PrecioTextBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            DepartamentoDropDownList.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
          
            CostoNumeric.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            FechaDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
        }

    
    }
}