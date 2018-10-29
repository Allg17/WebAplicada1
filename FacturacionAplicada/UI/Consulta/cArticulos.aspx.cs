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
    public partial class cArticulos : System.Web.UI.Page
    {
        bool paso = false;
        Expression<Func<Producto, bool>> filtrar = x => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            AHoradateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            FInaldateTimePicker2.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void DatosGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DatosGridView.DataSource = BLL.ProductoBLL.GetList(filtrar);
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
                        filtrar = t => t.Idproducto == id && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.Idproducto == id;
                    }

                    break;
                //Descripcion
                case 2:


                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Descripcion.Contains(CriterioTextBox.Text) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.Descripcion.Contains(CriterioTextBox.Text);
                    }

                    break;
                //precio
                case 3:
                    decimal precio = Convert.ToDecimal(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Precio.Equals(precio) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.Precio.Equals(precio);
                    }

                    break;
                //departamento
                case 4:
                    int departamento = Convert.ToInt32(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.DepartamentoId.Equals(departamento) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.DepartamentoId.Equals(departamento);
                    }

                    break;
                //cantidad
                case 5:
                    int cantidad = Convert.ToInt32(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Cantidad.Equals(cantidad) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    {
                        filtrar = t => t.Cantidad.Equals(cantidad);
                    }

                    break;

                //Costo
                case 6:
                    decimal Costo = Convert.ToDecimal(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Costo.Equals(Costo) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    {
                        filtrar = t => t.Costo.Equals(Costo);
                    }

                    break;

                //Ganancia
                case 7:
                    int ganancia = Convert.ToInt32(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Ganancia.Equals(ganancia) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    {
                        filtrar = t => t.Ganancia.Equals(ganancia);
                    }

                    break;

            }
            DatosGridView.DataSource = BLL.ProductoBLL.GetList(filtrar);
            DatosGridView.DataBind();
        }
    }
}