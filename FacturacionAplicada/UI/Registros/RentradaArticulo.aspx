<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Registros/Master Page/Diseño.Master" AutoEventWireup="true" CodeBehind="RentradaArticulo.aspx.cs" Inherits="FacturacionAplicada.UI.Registros.rEntradaArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header text-center">
            <h1 style="font-size: x-large; font-family: 'Times New Roman', Times, serif; font: bold;"><ins>Entrada de Articulos</ins></h1>
            <br />
        </div>

        <%--ID--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-4 col-md-3  offset-md-5">
                    <span>ID:</span>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 col-md-3  offset-md-4">
                    <asp:DropDownList ID="EntradaDropDownList" OnTextChanged="EntradaDropDownList_TextChanged" AppendDataBoundItems="true" placeholder="Entrada Id" AutoPostBack="true" runat="server" CssClass=" form-control">
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidator1" ValidationGroup="Eliminar" ControlToValidate="EntradaDropDownList" CssClass="ErrorMessage" OnServerValidate="CustomValidator1_ServerValidate" runat="server" ErrorMessage="Seleccione un ID"></asp:CustomValidator>
                </div>

            </div>
        </div>

        <%--Fecha--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-4 col-md-3  offset-md-5">
                    <span>Fecha:</span>
                </div>

            </div>
            <div class="row">
                <div class=" col-sm-4 col-md-3 offset-md-4  ">
                    <asp:TextBox ID="Fecha" type="date" AutoPostBack="true" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-4 col-md-4  ">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Guardar" ControlToValidate="Fecha" CssClass="ErrorMessage" runat="server" ErrorMessage="Seleccione una fecha"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <%--Articulo Dropdown--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-4 col-md-3  offset-md-5">
                    <span>Articulo:</span>
                </div>

            </div>
            <div class="row">
                <div class="col-sm-4 col-md-3 offset-md-4 ">
                    <asp:DropDownList ID="ArticuloDropDownList" placeholder="Articulo" AppendDataBoundItems="true" AutoPostBack="true" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-sm-4 col-md-4  ">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Guardar" ControlToValidate="ArticuloDropDownList" CssClass="ErrorMessage" runat="server" ErrorMessage="No hay ningun articulo seleccionado"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <%--Cantidad--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-4 col-md-3  offset-md-5">
                    <span>Cantidad:</span>
                </div>

            </div>
            <div class="row">
                <div class="col-sm-4 col-md-3 offset-md-4">
                    <asp:TextBox ID="CantidadTextBox" CausesValidation="false" type="number" placeholder="Cantidad" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-4 col-md-5">
                    <asp:RangeValidator ID="RangeValidator1" CssClass="ErrorMessage" ValidationGroup="Guardar" ControlToValidate="CantidadTextBox" runat="server" ErrorMessage="Arreglar la cantidad" MinimumValue="0" MaximumValue="9"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="ErrorMessage" ValidationGroup="Guardar" ControlToValidate="CantidadTextBox" runat="server" ErrorMessage="Ingresar una Cantidad"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <%--Botones--%>
        <div class="form-group">
            <div class="row">
                <div class="offset-md-3 col-sm-4 col-md-2">
                    <asp:Button ID="NuevoButton" CausesValidation="false" runat="server" OnClick="NuevoButton_Click" Text="Nuevo" CssClass="form-control btn btn-primary" />
                </div>
                <div class="col-sm-4 col-md-2 ">
                    <asp:Button ID="GuardarButton" ValidationGroup="Guardar" runat="server" Text="Guardar" OnClick="GuardarButton_Click" CssClass="form-control btn btn-success" />
                </div>
                <div class="col-sm-4 col-md-2 ">
                    <asp:Button ID="EliminarButton" ValidationGroup="Eliminar" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" CssClass="form-control btn btn-danger" />
                </div>
            </div>

        </div>
    </div>
</asp:Content>



