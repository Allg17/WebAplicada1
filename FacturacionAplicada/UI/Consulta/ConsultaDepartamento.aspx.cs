using FacturacionAplicada.Entidades;
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

        }

        protected void FacturaDetalleGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DatosGridView.DataSource = BLL.DepartamentoBLL.GetList(filtrar);
            DatosGridView.PageIndex = e.NewPageIndex;
            DatosGridView.DataBind();
        }
        Expression<Func<Departamento, bool>> filtrar = x => true;
        protected void BuscarButton_Click(object sender, EventArgs e)
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
            DatosGridView.DataSource = BLL.DepartamentoBLL.GetList(filtrar);

            DatosGridView.DataBind();

        }
    }
}