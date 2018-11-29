using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FacturacionAplicada.Entidades;
using Microsoft.Reporting.WebForms;

namespace FacturacionAplicada.UI.Registros
{
    public partial class Rfacturacion : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        Factura billes = new Factura();
        bool paso = true;
        string Condicion = "Seleccione Para Buscar";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["ModificarArticuo"] = new FacturaDetalle();
                LlenaComboBoxCliente();
                Fecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenarComboBoxArticulo();
                LlenarComboBoxFacturaID();

                EfectivoNumeric.Text = 0.ToString();
                Disable();
                EfectivoNumeric.Enabled = false;
                DatosReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                DatosReportViewer.Reset();
                DatosReportViewer.LocalReport.DataSources.Clear();
                DatosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\FacturaReporte.rdlc");
            }

        }

        private void Disable()
        {
            CantidadTextBox.Enabled = false;
            AgregarButton.Enabled = false;
            ArticuloDropDownList.Text = Condicion;
            PrecioArticuloTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            ImporteTextBox.Text = string.Empty;
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
            ArticuloDropDownList.DataSource = BLL.ProductoBLL.GetList(x => x.Cantidad >0);
            ArticuloDropDownList.DataValueField = "Idproducto";
            ArticuloDropDownList.DataTextField = "Descripcion";
            ArticuloDropDownList.DataBind();
        }

        private void Limpiar()
        {
            FacturaDropDownList.Text = Condicion;
            Fecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            FacturaDetalleGridView.DataSource = null;
            FacturaDetalleGridView.DataBind();
            EfectivoNumeric.Enabled = false;
            DescripcionTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            ArticuloDropDownList.Text = Condicion;
            PrecioArticuloTextBox.Text = string.Empty;
            ImporteTextBox.Text = string.Empty;
            DevueltaTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            EfectivoNumeric.Text = string.Empty;
            ViewState["Detalle"] = null;
            CantidadTextBox.Enabled = false;
            AgregarButton.Enabled = false;
        }

        private void AsignarDevuelta()
        {
            DevueltaTextBox.Text = BLL.HerramientasBLL.RetornarDevuelta(Convert.ToDecimal(EfectivoNumeric.Text), Convert.ToDecimal(MontoTextBox.Text)).ToString();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            EfectivoNumeric.Enabled = true;
            int producto = Convert.ToInt32(ArticuloDropDownList.SelectedValue);
            var productoBuscado = BLL.ProductoBLL.Buscar(producto);
            if (Convert.ToInt32(CantidadTextBox.Text) < productoBuscado.Cantidad || Convert.ToInt32(CantidadTextBox.Text) == productoBuscado.Cantidad)
            {
                if (FacturaDetalleGridView.Rows.Count != 0)
                {
                    billes.BillDetalle = (List<FacturaDetalle>)ViewState["Detalle"];
                }

                if (FacturaDropDownList.Text != Condicion)
                {
                    if (billes.BillDetalle.Exists(x => x.ProductoId.Equals(Convert.ToInt32(ArticuloDropDownList.SelectedValue))))
                    {
                        var articulo = billes.BillDetalle.Where(x => x.ProductoId.Equals(Convert.ToInt32(ArticuloDropDownList.SelectedValue)));

                    }

                    if (((FacturaDetalle)ViewState["ModificarArticuo"]).Id != 0)
                    {
                        billes.BillDetalle.Add(new FacturaDetalle(((FacturaDetalle)ViewState["ModificarArticuo"]).Id, Convert.ToInt32(FacturaDropDownList.SelectedValue), Convert.ToInt32(ArticuloDropDownList.SelectedValue), Convert.ToInt32(CantidadTextBox.Text), Convert.ToDecimal(PrecioArticuloTextBox.Text), ArticuloDropDownList.SelectedItem.Text, Convert.ToDecimal(ImporteTextBox.Text)));
                    }
                    else
                        billes.BillDetalle.Add(new FacturaDetalle(0, Convert.ToInt32(FacturaDropDownList.SelectedValue), Convert.ToInt32(ArticuloDropDownList.SelectedValue), Convert.ToInt32(CantidadTextBox.Text), Convert.ToDecimal(PrecioArticuloTextBox.Text), ArticuloDropDownList.SelectedItem.Text, Convert.ToDecimal(ImporteTextBox.Text)));
                    ViewState["ModificarArticuo"] = new FacturaDetalle();
                }
                else
                    billes.BillDetalle.Add(new FacturaDetalle(0, 0, Convert.ToInt32(ArticuloDropDownList.SelectedValue), Convert.ToInt32(CantidadTextBox.Text), Convert.ToDecimal(PrecioArticuloTextBox.Text), ArticuloDropDownList.SelectedItem.Text, Convert.ToDecimal(ImporteTextBox.Text)));

                ViewState["Detalle"] = billes.BillDetalle;

                //Monto
                CalcularMonto();
                FacturaDetalleGridView.DataSource = ViewState["Detalle"];
                FacturaDetalleGridView.DataBind();


                Disable();
                if (FormadePagoDropDownList.Text.Equals("Contado") && ((List<FacturaDetalle>)ViewState["Detalle"]).Count > 0)
                    EfectivoNumeric.Enabled = true;
                else
                    EfectivoNumeric.Enabled = false;
            }
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se puede Agregar cantidad mayor que existencia, Existencia = "+ productoBuscado.Cantidad +"');", addScriptTags: true);
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
                CantidadTextBox.Enabled = true;
                AgregarButton.Enabled = true;
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
            if (FormadePagoDropDownList.Text.Equals("Contado") && ((List<FacturaDetalle>)ViewState["Detalle"]).Count > 0)
                EfectivoNumeric.Enabled = true;
            else
                EfectivoNumeric.Enabled = false;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (paso == false)
            {


                if (FacturaDropDownList.Text.Equals(Condicion))
                {
                    //if (!BLL.HerramientasBLL.Login)
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalLogIn", "$('#ModalLogIn').modal();", true);
                    //    return;
                    //}
                    if (BLL.FacturacionBLL.Guardar(LlenaClase()))
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Guardado');", addScriptTags: true);
                        BLL.HerramientasBLL.DescontarProductos((List<FacturaDetalle>)ViewState["Detalle"]);
                        LlenarComboBoxFacturaID();
                        Limpiar();
                        FacturaDropDownList.SelectedValue = BLL.FacturacionBLL.GetList(x => true).Last().FacturaId.ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se pudo Guardar');", addScriptTags: true);
                        return;
                    }
                }
                else
                {

                    if (BLL.FacturacionBLL.Modificar(LlenaClase()))
                    {

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Modificado');", addScriptTags: true);

                        Limpiar();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se pudo Modificar');", addScriptTags: true);
                        return;
                    }
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

            bill.UsuarioId = BLL.HerramientasBLL.user.IdUsuario;

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
            CLienteDropDownList.SelectedValue = billes.ClienteId.ToString();
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

            if (billes.FormaDePago == "Credito")
                EfectivoNumeric.Enabled = false;
            else
                EfectivoNumeric.Enabled = true;
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {

            GridViewRow row = FacturaDetalleGridView.SelectedRow;
            //int id = Convert.ToInt32(FacturaDetalleGridView.DataKeys[row.RowIndex].Value);
            ((List<FacturaDetalle>)ViewState["Detalle"]).RemoveAt(row.RowIndex);
            FacturaDetalleGridView.DataSource = ViewState["Detalle"];
            FacturaDetalleGridView.DataBind();
            CalcularMonto();
        }

        protected void EnviarAlModalEliminarButton_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
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

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(Condicion))
            {
                args.IsValid = false;
            }
            else
                args.IsValid = true;
        }

        protected void EfectivoCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (FormadePagoDropDownList.Text.Equals("Contado") && Convert.ToDecimal(EfectivoNumeric.Text) <= 0)
            {
                args.IsValid = false;
                paso = true;
            }
            else
            {
                args.IsValid = true;
                paso = false;
            }
        }

        protected void DevueltaCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Convert.ToDecimal(DevueltaTextBox.Text) < 0) //|| Convert.ToDecimal(EfectivoNumeric.Text) < Convert.ToDecimal(MontoTextBox.Text) <- Parte de la condicion quitada temporalmente
            {
                args.IsValid = false;
                paso = true;
            }
            else
            {
                args.IsValid = true;
                paso = false;
            }
        }

        protected void ModificarArticuloButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = FacturaDetalleGridView.SelectedRow;
            //  int id = Convert.ToInt32(FacturaDetalleGridView.DataKeys[row.RowIndex].Value);

            var Articulo = ((List<FacturaDetalle>)ViewState["Detalle"]).ElementAt(row.RowIndex);
            ViewState["ModificarArticuo"] = new FacturaDetalle();
            ViewState["ModificarArticuo"] = ((List<FacturaDetalle>)ViewState["Detalle"]).ElementAt(row.RowIndex);


            ArticuloDropDownList.SelectedValue = Articulo.ProductoId.ToString();
            PrecioArticuloTextBox.Text = Articulo.Precio.ToString();
            CantidadTextBox.Text = Articulo.Cantidad.ToString();
            ImporteTextBox.Text = BLL.HerramientasBLL.Importedemas(Convert.ToDecimal(CantidadTextBox.Text), Convert.ToDecimal(PrecioArticuloTextBox.Text)).ToString();
            AgregarButton.Enabled = true;
            CantidadTextBox.Enabled = true;
            ((List<FacturaDetalle>)ViewState["Detalle"]).RemoveAt(row.RowIndex);
        }

        protected void EnviarAlModalModificar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalModificar", "$('#ModalModificar').modal();", true);
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            DatosReportViewer.LocalReport.DataSources.Clear();
            if (!FacturaDropDownList.Text.Equals(Condicion))
            {
                int id = Convert.ToInt32(FacturaDropDownList.SelectedValue);
                DatosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("FacturaReporte", BLL.FacturacionBLL.GetList(x => x.FacturaId.Equals(id))));
                DatosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("FacturaDetalleReporte", BLL.FacturacionBLL.GetList(x => x.FacturaId.Equals(id)).Last().BillDetalle));
            }
            else
            {
                var Factura = BLL.FacturacionBLL.GetList(x => true);
                if (FacturaDropDownList.Text.Equals(Factura.Last().FacturaId))
                {
                    DatosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("FacturaReporte", Factura));
                    DatosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("FacturaDetalleReporte", Factura.Last().BillDetalle));
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se puede imprimir la factura');", addScriptTags: true);
                    return;
                }

            }
            DatosReportViewer.LocalReport.Refresh();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalReporte", "$('#ModalReporte').modal();", true);
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (!FacturaDropDownList.Text.Equals(Condicion))
            {
                int id = Convert.ToInt32(FacturaDropDownList.SelectedValue);
                if (BLL.FacturacionBLL.Eliminar(id))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['info']('Eliminado');", addScriptTags: true);
                    FacturaDropDownList.DataSource = null;
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
    }
}