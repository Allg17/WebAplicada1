﻿using FacturacionAplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacturacionAplicada.UI.Registros
{
    public partial class rEntradaArticulo : System.Web.UI.Page
    {
        string Condicion = "Select One";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Tooltips();
                LlenaArticuloComboBox();
                LlenarIDComboBox();
                Fecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }


        }

        private void Tooltips()
        {
            EntradaDropDownList.ToolTip = "ID de la entrada";
            ArticuloDropDownList.ToolTip = "Articulo a dar Entrada";
            CantidadTextBox.ToolTip = "Cantidad";
        }

        private void Limpiar()
        {
            EntradaDropDownList.Text = "Select One";
            Fecha.Text = DateTime.Now.ToString("yyyy-MM-dd");

            CantidadTextBox.Text = string.Empty;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            //if (!BLL.HerramientasBLL.Login)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalLogIn", "$('#ModalLogIn').modal();", true);
            //    return;
            //}

            Limpiar();
        }

        private void LlenaArticuloComboBox()
        {
            var lista = BLL.ProductoBLL.GetList(x => true);
            ArticuloDropDownList.Items.Clear();

            ArticuloDropDownList.DataSource = lista;
            ArticuloDropDownList.DataValueField = "Idproducto";
            ArticuloDropDownList.DataTextField = "Descripcion";
            ArticuloDropDownList.DataBind();

        }

        private void LlenarIDComboBox()
        {
            var lista = BLL.EntradaArticuloBLL.GetList(x => true);
            EntradaDropDownList.Items.Clear();
            EntradaDropDownList.Items.Add("Select One");
            EntradaDropDownList.DataSource = lista;
            EntradaDropDownList.DataValueField = "EntradaArticuloID";
            EntradaDropDownList.DataTextField = "EntradaArticuloID";
            EntradaDropDownList.DataBind();


        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            if (EntradaDropDownList.Text == Condicion)
            {
                if (BLL.EntradaArticuloBLL.Guardar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Guardado');", addScriptTags: true);

                    Limpiar();
                    LlenarIDComboBox();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se pudo Guardar');", addScriptTags: true);
                    return;
                }

            }
            else
            {
                if (BLL.EntradaArticuloBLL.Modificar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Modificado');", addScriptTags: true);

                    Limpiar();
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se pudo Modificar');", addScriptTags: true);
                    return;
                }
            }
        }

        private EntradaArticulo LlenaClase()
        {
            EntradaArticulo entrada = new EntradaArticulo();
            if (EntradaDropDownList.Text == Condicion)
            {
                entrada.EntradaArticuloID = 0;
            }
            else
                entrada.EntradaArticuloID = Convert.ToInt32(EntradaDropDownList.Text);

            entrada.ArticuloID = Convert.ToInt32(ArticuloDropDownList.SelectedValue);
            entrada.Fecha = Convert.ToDateTime(Fecha.Text);
            entrada.Cantidad = Convert.ToInt32(CantidadTextBox.Text);
            return entrada;
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (EntradaDropDownList.Text != Condicion)
            {
                int id = Convert.ToInt32(EntradaDropDownList.SelectedValue);
                if (BLL.EntradaArticuloBLL.Eliminar(id))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['info']('Eliminado');", addScriptTags: true);
                    LlenarIDComboBox();
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

        protected void EntradaDropDownList_TextChanged(object sender, EventArgs e)
        {

            if (EntradaDropDownList.Text != Condicion)
            {
                int id = Convert.ToInt32(EntradaDropDownList.SelectedValue);
                var item = BLL.EntradaArticuloBLL.Buscar(id);
                Fecha.Text = item.Fecha.ToString("yyyy-MM-dd");
                ArticuloDropDownList.SelectedIndex = item.ArticuloID;
                CantidadTextBox.Text = item.Cantidad.ToString();

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