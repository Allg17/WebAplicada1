<%@ Page Title="Registro Usuarios" Language="C#" MasterPageFile="~/UI/Registros/Master Page/Diseño.Master" AutoEventWireup="true" CodeBehind="Rusuarios.aspx.cs" Inherits="FacturacionAplicada.UI.Registros.Rusuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header text-center">
            <h1 style="font-size: x-large; font-family: 'Times New Roman', Times, serif; font: bold;"><ins>Registro de Usuarios </ins></h1>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-sm-4 offset-md-3 col-md-3">
                <span>ID Usuario:</span>
            </div>
            <div class="col-sm-4 offset-md-2 col-md-4">
                <span>Fecha:</span>
            </div>
        </div>
        <div class="row">
            <div class="offset-md-3 col-sm-4 col-md-2 ">
                <asp:DropDownList ID="UsuarioDropDownList" AppendDataBoundItems="true" runat="server" CssClass="form-control" class="form-control " OnTextChanged="UsuarioDropDownList_TextChanged" AutoPostBack="true">
                </asp:DropDownList>

            </div>

            <div class=" offset-md-2 offset-sm-4 col-sm-4 col-md-3  ">
                <asp:TextBox ID="FechaDate" runat="server" type="date" CssClass="form-control"></asp:TextBox>
            </div>
            <div class=" col-sm-4 col-md-2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="ErrorMessage" ControlToValidate="FechaDate" runat="server" ErrorMessage="Ingresar Fecha"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
                <div class="col-sm-4 offset-md-3 col-md-3">
                    <span>Nombre:</span>
                </div>
            </div>
        <div class="row">
            <div class="offset-md-3 col-sm-8 col-md-4">
                <asp:TextBox ID="NombreTextBox" runat="server" CssClass="form-control" placeholder="Nombre" aria-label="Nombre"></asp:TextBox>
            </div>
            <div class=" col-sm-4 col-md-4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="ErrorMessage" ControlToValidate="NombreTextBox" runat="server" ErrorMessage="Ingresar un nombre"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
                <div class="col-sm-4 offset-md-3 col-md-3">
                    <span>Nombre Usuario:</span>
                </div>
            </div>
        <div class="row">
            <div class="offset-md-3 col-sm-8 col-md-4">
                <asp:TextBox ID="NombreUsuarioTextBox" runat="server" CssClass="form-control" placeholder="Nombre de usuario" aria-label="Nombre de usuario"></asp:TextBox>
            </div>
        </div>

        <div class="row">
                <div class="col-sm-4 offset-md-3 col-md-3">
                    <span>Contraseña</span>
                </div>
            </div>
        <div class="row">
            <div class="offset-md-3 col-sm-8 col-md-4">
                <asp:TextBox ID="ContraseñaTextBox" type="password" runat="server" CssClass="form-control" placeholder="Contraseña (con 8 caracteres)" aria-label="Contraseña (con 8 caracteres)" MaxLength="8"></asp:TextBox>
            </div>
        </div>

        <div class="row">
                <div class="col-sm-4 offset-md-3 col-md-3">
                    <span>Repetir Contraseña:</span>
                </div>
            </div>
        <div class="row">
            <div class="offset-md-3 col-sm-8 col-md-4">
                <asp:TextBox ID="RepetirContraseñaTextBox" type="password" runat="server" CssClass="form-control" placeholder="Repetir Contraseña (con 8 caracteres)" aria-label="Repetir Contraseña (con 8 caracteres)" MaxLength="8"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-7  offset-md-3 col-sm-4 col-md-2 ">
                <asp:CheckBox ID="ContraseñaCheckBox" runat="server" Text=" ver Contraseña" CssClass="form-control" OnCheckedChanged="ContraseñaCheckBox_CheckedChanged" AutoPostBack="true" />
            </div>
        </div>
   
        <div class="row">
                <div class="col-sm-4 offset-md-3 col-md-3">
                    <span>Comentario:</span>
                </div>
            </div>
        <div class="row">
            <div class="offset-md-3 col-sm-8 col-md-4">
                <asp:TextBox ID="ComentarioTextBox" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Comentario" aria-label="Comentario" MaxLength="10"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class=" offset-md-3 col-sm-3 col-md-2">
                <asp:Button ID="NuevoButton" CausesValidation="false"  runat="server" Text="Nuevo" CssClass="form-control btn btn-primary" OnClick="NuevoButton_Click" />
            </div>
            <div class="col-sm-3 col-md-2">
                <asp:Button ID="GuardarButton" runat="server" Text="Guardar" CssClass="form-control btn btn-success" OnClick="GuardarButton_Click" />
            </div>
            <div class=" col-sm-3 col-md-2">
                <asp:Button ID="EliminarButton" CausesValidation="false"  runat="server" Text="Eliminar" CssClass="form-control btn btn-danger" OnClick="EliminarButton_Click" />
            </div>
            <div class=" col-sm-3 col-md-2 ">
                <asp:Button ID="CancelarButton" CausesValidation="false"  runat="server" Text="Cancelar" CssClass="form-control btn btn-info" OnClick="CancelarButton_Click" />
            </div>



        </div>
    </div>
</asp:Content>
