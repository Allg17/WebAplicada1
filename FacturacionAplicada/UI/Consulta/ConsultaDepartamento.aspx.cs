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
    public partial class ConsultaDepartamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AHoradateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FInaldateTimePicker2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                DatosReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                DatosReportViewer.Reset();
                DatosReportViewer.LocalReport.DataSources.Clear();
                DatosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\DepartamentoReporte.rdlc");
            }
        }

      
        Expression<Func<Departamento, bool>> filtrar = x => true;
        bool paso = false;
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (paso)
                return;
            Switch();
            DatosGridView.DataSource = BLL.DepartamentoBLL.GetList(filtrar);

            DatosGridView.DataBind();

        }

        private void Switch()
        {
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {


                case 0:


                    filtrar = t => true;
                    break;

                //ID
                case 1:

                    id = int.Parse(CriterioTextBox.Text);
                    filtrar = t => t.DepartamentoId == id;
                    break;
                //Descripcion
                case 2:

                    filtrar = t => t.Nombre.Contains(CriterioTextBox.Text);
                    break;

            }
        }

        protected void DatosGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DatosGridView.DataSource = BLL.DepartamentoBLL.GetList(filtrar);
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

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Switch();
            DatosReportViewer.LocalReport.DataSources.Clear();
            DatosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DepartamentoReporte", BLL.DepartamentoBLL.GetList(filtrar)));
            DatosReportViewer.LocalReport.Refresh();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalReporte", "$('#ModalReporte').modal();", true);
        }
    }
}