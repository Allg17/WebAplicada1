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
    public partial class ConsultaDeUsuarios : System.Web.UI.Page
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
                DatosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\UsuarioReporte.rdlc");
            }
        }
        bool paso = false;
        Expression<Func<Usuario, bool>> filtrar = x => true;
        protected void DatosGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DatosGridView.DataSource = BLL.UsuarioBLL.GetList(filtrar);
            DatosGridView.PageIndex = e.NewPageIndex;
            DatosGridView.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (paso)
                return;

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
                //ID
                case 1:

                    id = int.Parse(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.IdUsuario == id && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date); 
                    }
                    else
                    {
                        filtrar = t => t.IdUsuario == id;
                    }

                    break;
                //Nombre
                case 2:


                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Nombre.Equals(CriterioTextBox.Text) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date); 
                    }
                    else
                    {
                        filtrar = t => t.Nombre.Equals(CriterioTextBox.Text);
                    }

                    break;
                //Clave
                case 3:

                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Clave.Equals(CriterioTextBox.Text) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.Clave.Equals(CriterioTextBox.Text);
                    }

                    break;
                //Usuario
                case 4:

                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.NombreUsuario.Equals(CriterioTextBox.Text) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date); 
                    }
                    else
                    {
                        filtrar = t => t.NombreUsuario.Equals(CriterioTextBox.Text);
                    }

                    break;
                //Comentario
                case 5:

                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Comentario.Contains(CriterioTextBox.Text) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    {
                        filtrar = t => t.Comentario.Contains(CriterioTextBox.Text);
                    }

                    break;

            }
            DatosGridView.DataSource = BLL.UsuarioBLL.GetList(filtrar);
            DatosGridView.DataBind();
        }

        private bool SetError(int error)
        {
            bool paso = false;
            int ejem = 0;
            if (error == 1 && int.TryParse(CriterioTextBox.Text, out ejem) == false)
            {

                paso = true;
            }
            if (error == 2 && int.TryParse(CriterioTextBox.Text, out ejem) == true)
            {

                paso = true;
            }

            return paso;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int ejem = 0;
            if (FiltroComboBox.SelectedIndex.Equals(1)&& int.TryParse(CriterioTextBox.Text, out ejem) == false)
            {
                paso = true;
                args.IsValid = false;
                CustomValidator1.ErrorMessage = "Debe introducir un numero en el criterio";
            }
            else
                args.IsValid = true;

        }

        protected void imprimirButton_Click(object sender, EventArgs e)
        {
            DatosReportViewer.LocalReport.DataSources.Clear();
            DatosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("UsuarioReporte", BLL.UsuarioBLL.GetList(filtrar)));
            DatosReportViewer.LocalReport.Refresh();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalReporte", "$('#ModalReporte').modal();", true);
        }
    }
}