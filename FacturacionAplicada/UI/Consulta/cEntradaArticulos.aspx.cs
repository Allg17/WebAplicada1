using FacturacionAplicada.Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacturacionAplicada.UI.Consulta
{
    public partial class cEntradaArticulos : System.Web.UI.Page
    {
        bool paso = false;
        Expression<Func<EntradaArticulo, bool>> filtrar = x => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AHoradateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FInaldateTimePicker2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                DatosReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                DatosReportViewer.Reset();
                DatosReportViewer.LocalReport.DataSources.Clear();
                DatosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\EntradaArticuloReporte.rdlc");
            }

        }

        protected void DatosGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DatosGridView.DataSource = BLL.EntradaArticuloBLL.GetList(filtrar);
            DatosGridView.PageIndex = e.NewPageIndex;
            DatosGridView.DataBind();
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int ejem = 0;
            if (FiltroComboBox.SelectedIndex.Equals(1) && int.TryParse(CriterioTextBox.Text, out ejem) == false)
            {
                paso = true;
                args.IsValid = false;
                CustomValidator1.ErrorMessage = "Debe introducir un numero en el criterio";
            }
            else
                args.IsValid = true;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (paso)
                return;

            Switch();
            DatosGridView.DataSource = BLL.EntradaArticuloBLL.GetList(filtrar);
            DatosGridView.DataBind();
        }

        private void Switch()
        {
            int id;
            var DesdeDateTime = Convert.ToDateTime(AHoradateTimePicker1.Text);
            var HastaDateTime = Convert.ToDateTime(FInaldateTimePicker2.Text);

            if (FiltroComboBox.Text == string.Empty && FechacheckBox.Checked == true)
            {
                filtrar = t => true && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
            }
            else
            {
                filtrar = t => true;
            }
            switch (FiltroComboBox.SelectedIndex)
            {

                //Lista todo
                case 0:

                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => true && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => true;
                    }
                    //filtrar = t => (t.Fecha.Day >= DesdeDateTime.Day) && (t.Fecha.Month >=  DesdeDateTime.Month) && (t.Fecha.Year >=  DesdeDateTime.Year) &&(t.Fecha.Day <= HastaDateTime.Day) && (t.Fecha.Month <= HastaDateTime.Month) && (t.Fecha.Year <= HastaDateTime.Year);
                    break;

                //EntradaArticuloID
                case 1:

                    id = int.Parse(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.EntradaArticuloID == id && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.EntradaArticuloID == id;
                    }

                    break;

                //Cantidad
                case 2:
                    int Cantidad = Convert.ToInt32(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Cantidad.Equals(Cantidad) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.Cantidad.Equals(Cantidad);
                    }

                    break;
                //ArticuloID
                case 3:
                    int ArticuloID = Convert.ToInt32(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.ArticuloID.Equals(ArticuloID) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    {
                        filtrar = t => t.ArticuloID.Equals(ArticuloID);
                    }

                    break;

            }
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Switch();
            DatosReportViewer.LocalReport.DataSources.Clear();
            DatosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("EntradaArticuloReporte", BLL.EntradaArticuloBLL.GetList(filtrar)));
            DatosReportViewer.LocalReport.Refresh();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalReporte", "$('#ModalReporte').modal();", true);
        }
    }
}