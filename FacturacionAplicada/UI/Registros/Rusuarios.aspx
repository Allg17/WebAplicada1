<%@ Page Title="Registro Usuarios" Language="C#" MasterPageFile="~/UI/Registros/Master Page/Diseño.Master" AutoEventWireup="true" CodeBehind="Rusuarios.aspx.cs" Inherits="FacturacionAplicada.UI.Registros.Rusuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header text-center">
            <h1 style="font-size: x-large; font-family: 'Times New Roman', Times, serif; font: bold;"><ins>Registro de Usuarios </ins></h1>
        </div>

        <%--Id Usuario y Fecha--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-4 offset-md-3 col-md-3">
                    <span>ID Usuario:</span>
                </div>
                <div class="col-sm-4 offset-md-2 col-md-4">
                    <span>Fecha:</span>
                </div>
            </div>
            <%--Id DropDown--%>
            <div class="row">
                <div class="offset-md-3 col-sm-4 col-md-2 ">
                    <asp:DropDownList ID="UsuarioDropDownList" AppendDataBoundItems="true" runat="server" CssClass="form-control" class="form-control " OnTextChanged="UsuarioDropDownList_TextChanged" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ValidationGroup="Eliminar" ControlToValidate="UsuarioDropDownList" CssClass="ErrorMessage" OnServerValidate="CustomValidator2_ServerValidate" ErrorMessage="Seleccione un Id"></asp:CustomValidator>
                </div>
                <%--Fecha--%>
                <div class=" offset-md-2 offset-sm-4 col-sm-4 col-md-3  ">
                    <asp:TextBox ID="FechaDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                </div>
                <div class=" col-sm-4 col-md-2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Guardar" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="FechaDate" runat="server" ErrorMessage="Ingresar Fecha"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <%--Nombre--%>
        <div class="form-group">
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Guardar" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="NombreTextBox" runat="server" ErrorMessage="Ingresar un nombre"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <%--Nombre Usuario--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-4 offset-md-3 col-md-3">
                    <span>Nombre Usuario:</span>
                </div>
            </div>
            <div class="row">
                <div class="offset-md-3 col-sm-8 col-md-4">
                    <asp:TextBox ID="NombreUsuarioTextBox" runat="server" CssClass="form-control" placeholder="Nombre de usuario" aria-label="Nombre de usuario"></asp:TextBox>
                </div>
                <div class=" col-sm-4 col-md-4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Guardar" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="NombreUsuarioTextBox" runat="server" ErrorMessage="Ingresar un nombre de Usuario"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" Display="Dynamic" ValidationGroup="Guardar" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="NombreUsuarioTextBox" runat="server" ErrorMessage="Usuario Existente Ingrese Otro" OnServerValidate="CustomValidator1_ServerValidate1"></asp:CustomValidator>
                </div>
            </div>
        </div>

        <%--Contraseña--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-4 offset-md-3 col-md-3">
                    <span>Contraseña</span>
                </div>
            </div>
            <div class="row">
                <div class="offset-md-3 col-sm-8 col-md-4">
                    <asp:TextBox ID="ContraseñaTextBox" type="password" runat="server" CssClass="form-control" placeholder="Contraseña (con 8 caracteres)" aria-label="Contraseña (con 8 caracteres)" MaxLength="8"></asp:TextBox>
                </div>
                <div class=" col-sm-4 col-md-4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Guardar" ControlToValidate="ContraseñaTextBox" CssClass="ErrorMessage" runat="server" ErrorMessage="Digite una Contraseña"></asp:RequiredFieldValidator>
                </div>

            </div>
        </div>

        <%--Repetir Contraseña--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-4 offset-md-3 col-md-3">
                    <span>Repetir Contraseña:</span>
                </div>
            </div>
            <div class="row">
                <div class="offset-md-3 col-sm-8 col-md-4">
                    <asp:TextBox ID="RepetirContraseñaTextBox" type="password" runat="server" CssClass="form-control" placeholder="Repetir Contraseña (con 8 caracteres)" aria-label="Repetir Contraseña (con 8 caracteres)" MaxLength="8"></asp:TextBox>
                </div>
                <div class=" col-sm-4 col-md-4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Guardar" ControlToValidate="RepetirContraseñaTextBox" CssClass="ErrorMessage" runat="server" ErrorMessage="Confirmar Contraseña"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" ControlToCompare="ContraseñaTextBox" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="RepetirContraseñaTextBox" runat="server" ErrorMessage="Contraseñas Diferentes"></asp:CompareValidator>
                </div>
            </div>
        </div>

        <%--CheckBox Contraseña--%>
        <div class="form-group">
            <div class="row">
                <div class="col-7  offset-md-3 col-sm-4 col-md-2 ">
                    <asp:CheckBox ID="ContraseñaCheckBox" runat="server" Text=" ver Contraseña" CssClass="form-control" OnCheckedChanged="ContraseñaCheckBox_CheckedChanged" AutoPostBack="true" />
                </div>
            </div>
        </div>

        <%--Comentario--%>
        <div class="form-group">
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
        </div>

        <%--Botones--%>
        <div class="form-group">
            <div class="row">
                <div class=" offset-md-3 col-sm-3 col-md-2">
                    <asp:Button ID="NuevoButton" CausesValidation="false" runat="server" Text="Nuevo" CssClass="form-control btn btn-primary" OnClick="NuevoButton_Click" />
                </div>
                <div class="col-sm-3 col-md-2">
                    <asp:Button ID="GuardarButton" runat="server" ValidationGroup="Guardar" Text="Guardar" CssClass="form-control btn btn-success" OnClick="GuardarButton_Click" />
                </div>
                <div class=" col-sm-3 col-md-2">
                    <asp:Button ID="EliminarButton" ValidationGroup="Eliminar" runat="server" Text="Eliminar" CssClass="form-control btn btn-danger" OnClick="EliminarButton_Click" />
                </div>
            </div>
        </div>

    </div>
</asp:Content>
