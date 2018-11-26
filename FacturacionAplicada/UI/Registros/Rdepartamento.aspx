<%@ Page Title="Registro de Departamentos" Language="C#" MasterPageFile="~/UI/Registros/Master Page/Diseño.Master" AutoEventWireup="true" CodeBehind="Rdepartamento.aspx.cs" Inherits="FacturacionAplicada.UI.Registros.Rdepartamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <br />
        <br />
        <div class="page-header text-center">
            <h1 style="font-size: x-large; font-family: 'Times New Roman', Times, serif; font: bold;"><ins>Registro de departamentos</ins></h1>

        </div>

        <%--ID Dropdown y NombreTExtBox--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-4 offset-md-3 col-md-3">
                    <p>ID Departamento</p>
                </div>
                <div class="col-sm-4 offset-md-0 col-md-3">
                    <p>Nombre Departamento</p>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6 col-md-4 offset-md-3">
                    <asp:DropDownList ID="DepartamentoDropDownList" runat="server" AppendDataBoundItems="true" placeholder="ID Departamento" aria-label="ID Departamento" CssClass="form-control" AutoPostBack="true" OnTextChanged="DepartamentoDropDownList_TextChanged">
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ValidationGroup="Eliminar" ControlToValidate="DepartamentoDropDownList" CssClass="ErrorMessage" OnServerValidate="CustomValidator1_ServerValidate" ErrorMessage="Seleccione un ID"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator12" runat="server" ValidationGroup="Guardar" ControlToValidate="DepartamentoDropDownList" CssClass="ErrorMessage" OnServerValidate="CustomValidator1_ServerValidate1" ErrorMessage="Departamento Existente"></asp:CustomValidator>
                </div>

                <div class="col-sm-6 col-md-4">
                    <asp:TextBox ID="NombreTextBox" runat="server" CssClass="form-control" placeholder="Nombre Departamento" aria-label="Nombre Departamento"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="NombreValidator" ValidationGroup="Guardar" runat="server" ErrorMessage="Nombre del Departamento" CssClass="ErrorMessage" ControlToValidate="NombreTextBox"></asp:RequiredFieldValidator>
                </div>
               
            </div>
        </div>

        <%--Botones--%>
        <div class="form-group">
            <div class="row">


                <div class="col-sm-4 col-md-2 offset-md-3 ">
                    <asp:Button ID="NuevoButton" CausesValidation="false" runat="server" Text="Nuevo" CssClass="form-control btn btn-primary" OnClick="NuevoButton_Click" />
                </div>
                <div class=" col-sm-4 col-md-2  ">
                    <asp:Button ID="GuardarButton" runat="server" Text="Guardar" ValidationGroup="Guardar" CssClass="form-control btn btn-success" OnClick="GuardarButton_Click" />
                </div>
                <div class=" col-sm-4 col-md-2 ">
                    <asp:Button ID="EliminarButton" ValidationGroup="Eliminar" runat="server" Text="Eliminar" CssClass="form-control btn btn-danger" OnClick="EliminarButton_Click" />
                </div>
            </div>

        </div>

    </div>


</asp:Content>
