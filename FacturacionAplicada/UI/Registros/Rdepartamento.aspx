<%@ Page Title="Registro de Departamentos" Language="C#" MasterPageFile="~/UI/Registros/Master Page/Diseño.Master" AutoEventWireup="true" CodeBehind="Rdepartamento.aspx.cs" Inherits="FacturacionAplicada.UI.Registros.Rdepartamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header text-center">
            <h1 style="font-size: x-large; font-family: 'Times New Roman', Times, serif; font: bold;"><ins>Registro de departamentos</ins></h1>

        </div>
        <br />
        <div class="row">
                <div class="col-sm-4 offset-md-3 col-md-3">
                    <p>ID Departamento</p>
                </div>
            <div class="col-sm-4 offset-md-0 col-md-3">
                    <p>Nombre Departamento</p>
                </div>
            </div>
        <div class="row">
            <div class="col-sm-4 col-md-3 offset-md-3">
                <asp:DropDownList ID="DepartamentoDropDownList" runat="server" AppendDataBoundItems="true" placeholder="ID Departamento" aria-label="ID Departamento" CssClass="form-control" AutoPostBack="true" OnTextChanged="DepartamentoDropDownList_TextChanged">
                </asp:DropDownList>
            </div>
           
            <div class="col-sm-4 col-md-3">
                <asp:TextBox ID="NombreTextBox" runat="server" CssClass="form-control" placeholder="Nombre Departamento" aria-label="Nombre Departamento"></asp:TextBox>
            </div  >
            <div class="col-sm-4 col-md-2">
                <asp:RequiredFieldValidator ID="NombreValidator" runat="server" ErrorMessage="Nombre del Departamento"  CssClass=" form-control ErrorMessage" ControlToValidate="NombreTextBox"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">


            <div class="col-sm-4 col-md-2 offset-md-3 ">
                <asp:Button ID="NuevoButton" CausesValidation="false" runat="server" Text="Nuevo" CssClass="form-control btn btn-primary" OnClick="NuevoButton_Click" />
            </div>
            <div class=" col-sm-4 col-md-2  ">
                <asp:Button ID="GuardarButton" runat="server" Text="Guardar" CssClass="form-control btn btn-success" OnClick="GuardarButton_Click" />
            </div>
            <div class=" col-sm-4 col-md-2 ">
                <asp:Button ID="EliminarButton" CausesValidation="false" runat="server" Text="Eliminar" CssClass="form-control btn btn-danger" OnClick="EliminarButton_Click" />
            </div>
            <div class=" col-sm-4 col-md-2 ">
                <asp:Button ID="CancelarButton" CausesValidation="false" runat="server" Text="Cancelar" CssClass="form-control btn btn-info" OnClick="CancelarButton_Click" />
            </div>


        </div>



    </div>


</asp:Content>
