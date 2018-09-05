﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FacturacionAplicada.Entidades;

namespace FacturacionAplicada.UI.Registros
{
    public partial class Rfacturacion : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        Factura billes = new Factura();
        string Condicion = "Seleccione Para Buscar";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenaComboBoxCliente();
                Fecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenarComboBoxArticulo();
                LlenarComboBoxFacturaID();
                DisableALL();

                EfectivoNumeric.Text = 0.ToString();


                //dt.Columns.Add("ID");
                //dt.Columns.Add("FacturaID");
                //dt.Columns.Add("ProductoID");
                //dt.Columns.Add("Cantidad");
                //dt.Columns.Add("Precio");
                //dt.Columns.Add("Descripcion");
                //dt.Columns.Add("Importe");

                //DataRow row = dt.NewRow();
                //row["ID"] = 1;
                //row["FacturaID"] = 1;
                //row["ProductoID"] = 2;
                //row["Cantidad"] = 30;
                //row["Precio"] = 40;
                //row["Descripcion"] = "Pepsi";
                //row["Importe"] = 1400;
                //dt.Rows.Add(row);

                //DataRow row1 = dt.NewRow();
                //row1["ID"] = 2;
                //row1["FacturaID"] = 1;
                //row1["ProductoID"] = 4;
                //row1["Cantidad"] = 30;
                //row1["Precio"] = 40;
                //row1["Descripcion"] = "Coca Cola";
                //row1["Importe"] = 1200;
                //dt.Rows.Add(row1);
                //dt.Rows.Add(3, 1, 3, 30, 40, "Papitas", 1200);
                //dt.Rows.Add(3, 1, 3, 30, 40, "Papitas", 1200);
                //dt.Rows.Add(3, 1, 3, 30, 40, "Papitas", 1200);
                //dt.Rows.Add(3, 1, 3, 30, 40, "Papitas", 1200);
                //dt.Rows.Add(3, 1, 3, 30, 40, "Papitas", 1200);
                //dt.Rows.Add(3, 1, 3, 30, 40, "Papitas", 1200);
                //dt.Rows.Add(3, 1, 3, 30, 40, "Papitas", 1200);
                //dt.Rows.Add(3, 1, 3, 30, 40, "Papitas", 1200);
                //dt.Rows.Add(3, 1, 3, 30, 40, "Papitas", 1200);
                //dt.Rows.Add(3, 1, 3, 30, 40, "Papitas", 1200);
                //dt.Rows.Add(3, 1, 3, 30, 40, "Papitas", 1200);

                //List<DataRow> lista = new List<DataRow>();

                //lista.Add(row);
                //lista.Add(rows);




            }
          
        }

        protected void FacturaDetalleGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            FacturaDetalleGridView.DataSource = ViewState["Detalle"];
            FacturaDetalleGridView.PageIndex = e.NewPageIndex;
            FacturaDetalleGridView.DataBind();
        }

        private void LlenarComboBoxFacturaID()
        {
            FacturaDropDownList.Items.Clear();
            FacturaDropDownList.Items.Add(Condicion);
            FacturaDropDownList.DataSource = BLL.FacturacionBLL.GetList(x => true);
            FacturaDropDownList.DataValueField = "FacturaId";
            FacturaDropDownList.DataTextField = "FacturaId";
            FacturaDropDownList.DataBind();
        }

        private void LlenarComboBoxArticulo()
        {
            ArticuloDropDownList.Items.Clear();
            ArticuloDropDownList.Items.Add(Condicion);
            ArticuloDropDownList.DataSource = BLL.ProductoBLL.GetList(x => true);
            ArticuloDropDownList.DataValueField = "Idproducto";
            ArticuloDropDownList.DataTextField = "Descripcion";
            ArticuloDropDownList.DataBind();
        }

        private void EnableALL()
        {
            FormadePagoDropDownList.Enabled = true;
            CLienteDropDownList.Enabled = true;
            DescripcionTextBox.Enabled = true;
            Fecha.Enabled = true;
            ArticuloDropDownList.Enabled = true;
            CantidadTextBox.Enabled = true;
            EfectivoNumeric.Enabled = true;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
            NuevoButton.Enabled = false;
            FacturaDropDownList.Enabled = false;

        }

        private void DisableALL()
        {
            FormadePagoDropDownList.Enabled = false;
            CLienteDropDownList.Enabled = false;
            DescripcionTextBox.Enabled = false;
            Fecha.Enabled = false;
            ArticuloDropDownList.Enabled = false;
            CantidadTextBox.Enabled = false;
            EfectivoNumeric.Enabled = false;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;
            NuevoButton.Enabled = true;
            FacturaDropDownList.Enabled = true;
            EliminarButton.Enabled = false;
        }

        private void Limpiar()
        {
            FacturaDropDownList.Text = Condicion;
            Fecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            
            DescripcionTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            ArticuloDropDownList.Text = Condicion;
            PrecioArticuloTextBox.Text = string.Empty;
            ImporteTextBox.Text = string.Empty;
            DevueltaTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            EfectivoNumeric.Text = string.Empty;
            FacturaDetalleGridView.DataSource = null;
            ViewState["Detalle"] = null;
        }

        private void AsignarDevuelta()
        {
            DevueltaTextBox.Text = BLL.HerramientasBLL.RetornarDevuelta(Convert.ToDecimal(EfectivoNumeric.Text), Convert.ToDecimal(MontoTextBox.Text)).ToString();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
           
            EnableALL();
        }

        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
            DisableALL();

        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {


            if (FacturaDetalleGridView.Rows.Count != 0)
            {
                billes.BillDetalle = (List<FacturaDetalle>)ViewState["Detalle"];
            }

            if (FacturaDropDownList.Text != Condicion)
                billes.BillDetalle.Add(new FacturaDetalle(0, Convert.ToInt32(FacturaDropDownList.SelectedValue), Convert.ToInt32(ArticuloDropDownList.SelectedValue), Convert.ToInt32(CantidadTextBox.Text), Convert.ToDecimal(PrecioArticuloTextBox.Text), ArticuloDropDownList.SelectedItem.Text, Convert.ToDecimal(ImporteTextBox.Text)));
            else
                billes.BillDetalle.Add(new FacturaDetalle(0,0, Convert.ToInt32(ArticuloDropDownList.SelectedValue), Convert.ToInt32(CantidadTextBox.Text), Convert.ToDecimal(PrecioArticuloTextBox.Text), ArticuloDropDownList.SelectedItem.Text, Convert.ToDecimal(ImporteTextBox.Text)));

            ViewState["Detalle"] = billes.BillDetalle;

            //Monto
            CalcularMonto();
            FacturaDetalleGridView.DataSource = ViewState["Detalle"];
            FacturaDetalleGridView.DataBind();

            PrecioArticuloTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;


        }

        private void CalcularMonto()
        {
            int monto = 0;
            foreach (var item in (List<FacturaDetalle>)ViewState["Detalle"])
            {
                monto += Convert.ToInt32(item.Importe);
            }

            MontoTextBox.Text = monto.ToString();
        }

        protected void ArticuloDropDownList_TextChanged(object sender, EventArgs e)
        {
            if (ArticuloDropDownList.Text != Condicion)
            {
                int id = Convert.ToInt32(ArticuloDropDownList.SelectedValue);
                PrecioArticuloTextBox.Text = BLL.ProductoBLL.Buscar(id).Precio.ToString();
            }

        }

        protected void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            ImporteTextBox.Text = BLL.HerramientasBLL.Importedemas(Convert.ToDecimal(CantidadTextBox.Text), Convert.ToDecimal(PrecioArticuloTextBox.Text)).ToString();
        }

        protected void EfectivoNumeric_TextChanged(object sender, EventArgs e)
        {
            AsignarDevuelta();
        }

        protected void FormadePagoDropDownList_TextChanged(object sender, EventArgs e)
        {
            if (FormadePagoDropDownList.SelectedIndex == 1)
                EfectivoNumeric.Enabled = false;
            else
                EfectivoNumeric.Enabled = true;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (FacturaDropDownList.Text.Equals(Condicion))
            {
                if (!BLL.HerramientasBLL.Login)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalLogIn", "$('#ModalLogIn').modal();", true);
                    return;
                }
                if (BLL.FacturacionBLL.Guardar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Guardado');", addScriptTags: true);
                    BLL.HerramientasBLL.DescontarProductos((List<FacturaDetalle>)ViewState["Detalle"]);
                    LlenarComboBoxFacturaID();
                    Limpiar();
                    DisableALL();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo Guardar');", addScriptTags: true);
                    return;
                }
            }
            else
            {

                if (BLL.FacturacionBLL.Modificar(LlenaClase()))
                {

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Modificado');", addScriptTags: true);
                    DisableALL();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo Modificar');", addScriptTags: true);
                    return;
                }
            }


        }

        private Factura LlenaClase()
        {
            Factura bill = new Factura();
            var Efectivo = Convert.ToDecimal(EfectivoNumeric.Text);
            if (FacturaDropDownList.Text.Equals(Condicion))
            {
                bill.FacturaId = 0;
            }
            else
            {
                bill.FacturaId = Convert.ToInt32(FacturaDropDownList.SelectedValue);
            }

            if (CLienteDropDownList.Text != string.Empty)
                bill.ClienteId = Convert.ToInt32(CLienteDropDownList.SelectedValue);
            else
                bill.ClienteId = 0;

            bill.UsuarioId = BLL.HerramientasBLL.returnUsuario().IdUsuario;

            bill.Fecha = Convert.ToDateTime(Fecha.Text);

            bill.FormaDePago = FormadePagoDropDownList.SelectedItem.Text;

            bill.Descripcion = DescripcionTextBox.Text;

            if (Efectivo != 0)
                bill.EfectivoRecibido = Efectivo;
            else
                bill.EfectivoRecibido = 0;

            bill.Monto = Convert.ToDecimal(MontoTextBox.Text);

            if (DevueltaTextBox.Text != string.Empty)
                bill.Devuelta = Convert.ToDecimal(DevueltaTextBox.Text);
            else
                bill.Devuelta = 0;

            bill.BillDetalle = (List<FacturaDetalle>)ViewState["Detalle"];




            return bill;
        }

        private void LlenaComboBoxCliente()
        {
            CLienteDropDownList.Items.Clear();
            CLienteDropDownList.Items.Add(Condicion);
            CLienteDropDownList.DataSource = BLL.ClienteBLL.GetList(x => true);
            CLienteDropDownList.DataValueField = "IdCliente";
            CLienteDropDownList.DataTextField = "Nombre";
            CLienteDropDownList.DataBind();
        }

        protected void FacturaDropDownList_TextChanged(object sender, EventArgs e)
        {
           
            int id = Convert.ToInt32(FacturaDropDownList.SelectedValue);
            billes = BLL.FacturacionBLL.Buscar(id);

            FormadePagoDropDownList.Text = billes.FormaDePago;
            CLienteDropDownList.SelectedIndex = billes.ClienteId;
            DescripcionTextBox.Text = billes.Descripcion;
            MontoTextBox.Text = billes.Monto.ToString();
            EfectivoNumeric.Text = billes.EfectivoRecibido.ToString();
            DevueltaTextBox.Text = billes.Devuelta.ToString();
            Fecha.Text = billes.Fecha.ToString("yyyy-MM-dd");
            foreach (var item in billes.BillDetalle)
            {
                item.Importe = BLL.HerramientasBLL.Importedemas(item.Cantidad, item.Precio);
            }
            ViewState["Detalle"] = billes.BillDetalle;
            FacturaDetalleGridView.DataSource = ViewState["Detalle"];
            FacturaDetalleGridView.DataBind();
            EliminarButton.Enabled = true;
            EnableALL();
            if (billes.FormaDePago == "Credito")
                EfectivoNumeric.Enabled = false;
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            GridViewRow row = FacturaDetalleGridView.SelectedRow;
            int id = Convert.ToInt32(FacturaDetalleGridView.DataKeys[row.RowIndex].Value);
            List<FacturaDetalle> lista = (List<FacturaDetalle>)ViewState["Detalle"];
            lista.RemoveAll(x => x.Id == id);
            ViewState["Detalle"] = lista;
            FacturaDetalleGridView.DataSource = ViewState["Detalle"];
            FacturaDetalleGridView.DataBind();
            CalcularMonto();
        }

        protected void EnviarAlModalEliminarButton_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            //GridViewRow row = FacturaDetalleGridView.SelectedRow;
            //int index = FacturaDetalleGridView.SelectedIndex;
            // int id = Convert.ToInt32(FacturaDetalleGridView.DataKeys[row.RowIndex].Value);

            FacturaDetalleGridView.EditIndex = FacturaDetalleGridView.SelectedIndex;



            CalcularMonto();
        }

        protected void FacturaDetalleGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {


        }
    }
}