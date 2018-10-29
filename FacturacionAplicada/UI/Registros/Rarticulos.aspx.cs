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
                FechaDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenarDepartamento();
            }
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
            FechaDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            CostoNumeric.Text = string.Empty;

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

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            if (ArticuloDropDownList.Text.Equals(Condicion))
            {
                if (BLL.ProductoBLL.Guardar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Guardado');", addScriptTags: true);
                    ArticuloDropDownList.DataSource = null;

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
            if (!ArticuloDropDownList.Text.Equals(Condicion))
            {
                int id = Convert.ToInt32(ArticuloDropDownList.SelectedValue);
                if (BLL.ProductoBLL.Eliminar(id))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['info']('Eliminado');", addScriptTags: true);
                    ArticuloDropDownList.DataSource = null;
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
            if (!ArticuloDropDownList.Text.Equals(Condicion))
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

                EliminarButton.Enabled = true;
            }
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
    }
}