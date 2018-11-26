<%@ Page Title="Registro de Clientes" Language="C#" MasterPageFile="~/UI/Registros/Master Page/Diseño.Master" AutoEventWireup="true" CodeBehind="Rclientes.aspx.cs" Inherits="FacturacionAplicada.UI.Registros.Rclientes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <br />
        <br />

        <div class="page-header text-center">
            <h1 style="font-size: x-large; font-family: 'Times New Roman', Times, serif; font: bold;"><ins>Registro de Clientes</ins></h1>
        </div>

        <%--Id y Fecha--%>
        <div class="form-group">
            <%--Span ID y Span Fecha--%>
            <div class="row">
                <div class="col-sm-4 col-md-3 offset-md-2">
                    <span>ID Cliente:</span>
                </div>
                <div class="col-sm-4 col-md-3 offset-md-2">
                    <span>Fecha:</span>
                </div>

            </div>

            <%--Fecha y ClienteDropDown--%>
            <div class="row">
                <div class="col-sm-4 col-md-2 offset-md-2">
                    <asp:DropDownList ID="ClienteDropDownList" AutoPostBack="true" AppendDataBoundItems="true" OnTextChanged="ClienteDropDownList_TextChanged" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidator1" ControlToValidate="ClienteDropDownList" OnServerValidate="CustomValidator1_ServerValidate" CssClass="ErrorMessage" ValidationGroup="Eliminar" runat="server" ErrorMessage="Seleccione un ID"></asp:CustomValidator>
                </div>
                <div class=" col-sm-4 col-md-3 offset-md-3">
                    <asp:TextBox ID="Fecha" type="date" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="Fecha" ValidationGroup="Guardar" CssClass="ErrorMessage" runat="server" ErrorMessage="seleccione la fecha"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <%--Noombre--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-4 col-md-3 offset-md-2">
                    <span>Nombre:</span>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 col-md-4 offset-md-2">
                    <asp:TextBox ID="NombreTextBox" CssClass="form-control" placeholder="Nombre" aria-label="Nombre" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="NombreTextBox" CssClass="ErrorMessage" ValidationGroup="Guardar" runat="server" ErrorMessage="Digitar Nombre"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <%--Direccion--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-4 col-md-3 offset-md-2">
                    <span>Direccion:</span>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 col-md-4 offset-md-2">
                    <asp:TextBox ID="DireccionTextBox" CssClass="form-control" placeholder="Direccion" aria-label="Direccion" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Guardar" ControlToValidate="DireccionTextBox" CssClass="ErrorMessage" runat="server" ErrorMessage="Digite Direccion"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <%--Cedula--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-4 col-md-3 offset-md-2">
                    <span>Cedula:</span>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 col-md-4 offset-md-2">

                    <asp:TextBox ID="CedulaTextBox" CssClass="form-control" placeholder="Cedula" aria-label="Cedula" runat="server"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="CedulaTextBox" Mask="999-9999999-9" MaskType="Number " ClearMaskOnLostFocus="true" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="ErrorMessage" runat="server" ErrorMessage="Digitar Cedula" ControlToValidate="CedulaTextBox" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <%--Telefono--%>
        <div class="form-group">


            <div class="row">
                <div class="col-sm-4 col-md-3 offset-md-2">
                    <span>Telefono:</span>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 col-md-4 offset-md-2">

                    <asp:TextBox ID="TelefonoTextBox" CssClass=" form-control " ClientIDMode="static" placeholder="Telefono" aria-label="Telefono" runat="server"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="TelefonoTextBox" Mask="(999)-999-9999" MaskType="Number " ClearMaskOnLostFocus="true" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ErrorMessage="Digitar Telefono" ControlToValidate="TelefonoTextBox"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <%--Bottones--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-4 col-md-2 offset-md-2 ">
                    <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" CssClass="form-control btn btn-primary" OnClick="NuevoButton_Click" />
                </div>
                <div class="col-sm-4 col-md-2  ">
                    <asp:Button ID="GuardarButton" runat="server" ValidationGroup="Guardar" Text="Guardar" CssClass="form-control btn btn-success" OnClick="GuardarButton_Click" />
                </div>
                <div class="col-sm-4 col-md-2 ">
                    <asp:Button ID="EliminarButton" runat="server"  ValidationGroup="Eliminar" Text="Eliminar" CssClass="form-control btn btn-danger" OnClick="EliminarButton_Click" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
