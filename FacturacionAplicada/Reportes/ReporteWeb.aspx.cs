using FacturacionAplicada.Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacturacionAplicada.Reportes
{
    public partial class ReporteWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ReportViewer1.Reset();
                ReportViewer1.LocalReport.DataSources.Clear();
                //switch ()
                //{
                //    case 1:
                //        ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ClienteReporte.rdlc");
                //        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ClienteReporte", BLL.ClienteBLL.GetList(x => true)));
                //        break;
                //    case 2:
                //        ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\DepartamentoReporte.rdlc");
                //        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DepartamentoReporte", BLL.DepartamentoBLL.GetList(x => true)));
                //        break;
                //    case 3:
                //        ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\EntradaArticuloReporte.rdlc");
                //        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("EntradaArticuloReporte", BLL.EntradaArticuloBLL.GetList(x => true)));
                //        break;
                //    case 4:
                //        ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\FacturaReporte.rdlc");
                //        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("FacturaReporte", BLL.FacturacionBLL.GetList(x => true).Last()));
                //        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("FacturaDetalleReporte", BLL.FacturacionBLL.GetList(x => true).Last().BillDetalle));
                //        break;
                //    case 5:
                //        ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ProductoReporte.rdlc");
                //        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ProductoReporte", BLL.ProductoBLL.GetList(x => true)));
                //        break;
                //    case 6:
                //        ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\UsuarioReporte.rdlc");
                //        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("UsuarioReporte", BLL.UsuarioBLL.GetList(x => true)));
                //        break;

                //    default:
                //        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se puede cargar el reporte');", addScriptTags: true);
                //        break;
                //}
                ReportViewer1.LocalReport.Refresh();
                Session["TipoReporte"] = 0;
            }

        }
    }
}