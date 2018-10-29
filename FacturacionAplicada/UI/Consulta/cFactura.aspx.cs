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
    public partial class cFactura : System.Web.UI.Page
    {
        bool paso = false;
        Expression<Func<Factura, bool>> filtrar = x => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            AHoradateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            FInaldateTimePicker2.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void DatosGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DatosGridView.DataSource = BLL.FacturacionBLL.GetList(filtrar);
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
                //Idproducto
                case 1:

                    id = int.Parse(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.FacturaId == id && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.FacturaId == id;
                    }

                    break;
                //monto
                case 2:

                    decimal monto = Convert.ToDecimal(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Monto.Equals(monto) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.Monto.Equals(monto);
                    }

                    break;
                //UsuarioId
                case 3:
                    int UsuarioId = Convert.ToInt32(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.UsuarioId.Equals(UsuarioId) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.UsuarioId.Equals(UsuarioId);
                    }

                    break;
                //ClienteId
                case 4:
                    int ClienteId = Convert.ToInt32(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.ClienteId.Equals(ClienteId) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.ClienteId.Equals(ClienteId);
                    }

                    break;
                //Descripcion
                case 5:
              
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Descripcion.Contains(CriterioTextBox.Text) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    {
                        filtrar = t => t.Descripcion.Contains(CriterioTextBox.Text);
                    }

                    break;

                //FormaDePago
                case 6:
                 
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.FormaDePago.Contains(CriterioTextBox.Text) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    {
                        filtrar = t => t.FormaDePago.Contains(CriterioTextBox.Text);
                    }

                    break;

                //Devuelta
                case 7:
                    int Devuelta = Convert.ToInt32(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Devuelta.Equals(Devuelta) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    {
                        filtrar = t => t.Devuelta.Equals(Devuelta);
                    }

                    break;
                //EfectivoRecibido
                case 8:
                    int EfectivoRecibido = Convert.ToInt32(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.EfectivoRecibido.Equals(EfectivoRecibido) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    {
                        filtrar = t => t.EfectivoRecibido.Equals(EfectivoRecibido);
                    }

                    break;

            }
            DatosGridView.DataSource = BLL.FacturacionBLL.GetList(filtrar);
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
    }
}