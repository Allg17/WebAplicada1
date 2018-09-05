<%@ Page Title="Registro de Clientes" Language="C#" MasterPageFile="~/UI/Registros/Master Page/Diseño.Master" AutoEventWireup="true" CodeBehind="Rclientes.aspx.cs" Inherits="FacturacionAplicada.UI.Registros.Rclientes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="page-header text-center">
            <h1 style="font-size: x-large; font-family: 'Times New Roman', Times, serif; font: bold;"><ins>Registro de Clientes</ins></h1>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4 col-md-3 offset-md-2">
                <span>ID Cliente:</span>
            </div>
            <div class="col-sm-4 col-md-3 offset-md-2">
                <span>Fecha:</span>
            </div>

        </div>
        <div class="row">
            <div class="col-sm-4 col-md-2 offset-md-2">
                <asp:DropDownList ID="ClienteDropDownList" AutoPostBack="true" AppendDataBoundItems="true" OnTextChanged="ClienteDropDownList_TextChanged" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class=" col-sm-4 col-md-3 offset-md-3">
                <asp:TextBox ID="Fecha" type="date" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4 col-md-3 offset-md-2">
                <span>Nombre:</span>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4 col-md-4 offset-md-2">
                <asp:TextBox ID="NombreTextBox" CssClass="form-control" placeholder="Nombre" aria-label="Nombre" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4 col-md-3 offset-md-2">
                <span>Direccion:</span>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4 col-md-4 offset-md-2">
                <asp:TextBox ID="DireccionTextBox" CssClass="form-control" placeholder="Direccion" aria-label="Direccion" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4 col-md-3 offset-md-2">
                <span>Cedula:</span>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4 col-md-4 offset-md-2">
                
                <asp:TextBox ID="CedulaTextBox" CssClass="form-control" placeholder="Cedula" aria-label="Cedula" runat="server"></asp:TextBox>
                 <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2"  runat="server" TargetControlID="CedulaTextBox" Mask="999-9999999-9" MaskType="Number " ClearMaskOnLostFocus="true"  />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4 col-md-3 offset-md-2">
                <span>Telefono:</span>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4 col-md-4 offset-md-2">
                
                <asp:TextBox ID="TelefonoTextBox" CssClass=" form-control " ClientIDMode="static" placeholder="Telefono" aria-label="Telefono" runat="server"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1"  runat="server" TargetControlID="TelefonoTextBox" Mask="(999)-999-9999" MaskType="Number " ClearMaskOnLostFocus="true"  />
                </div>
        </div>
        <br />
       

        <div class="row">
            <div class="col-sm-4 col-md-2 offset-md-2 ">
                <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" CssClass="form-control btn btn-primary" OnClick="NuevoButton_Click" />
            </div>
            <div class="col-sm-4 col-md-2  ">
                <asp:Button ID="GuardarButton" runat="server" Text="Guardar" CssClass="form-control btn btn-success" OnClick="GuardarButton_Click" />
            </div>
            <div class="col-sm-4 col-md-2 ">
                <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" CssClass="form-control btn btn-danger" OnClick="EliminarButton_Click" />
            </div>
            <div class=" col-sm-3 col-md-2 ">
                <asp:Button ID="CancelarButton" runat="server" Text="Cancelar" CssClass="form-control btn btn-info" OnClick="CancelarButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
