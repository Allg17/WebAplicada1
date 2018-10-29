<%@ Page Title="Registro de Articulos" Language="C#" MasterPageFile="~/UI/Registros/Master Page/Diseño.Master" AutoEventWireup="true" CodeBehind="Rarticulos.aspx.cs" Inherits="FacturacionAplicada.UI.Registros.Rarticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header text-center">
            <h1 style="font-size: x-large; font-family: 'Times New Roman', Times, serif; font: bold;"><ins>Registro de Articulos</ins></h1>
        </div>

        <%--ID y Fecha--%>
        <div class="form-group">
            <div class="row">
                <div class="offset-md-3 col-sm-4 col-md-2 ">
                    <span>ID:</span>
                </div>
                <div class="offset-md-3 col-sm-4 col-md-2 ">
                    <span>Fecha:</span>
                </div>

            </div>
            <div class="row">
                <div class="offset-md-3 col-sm-4 col-md-2  ">
                    <asp:DropDownList ID="ArticuloDropDownList" OnTextChanged="ArticuloDropDownList_TextChanged" AutoPostBack="true" CssClass="form-control" class="form-control " runat="server" AppendDataBoundItems="true" >
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Seleccione un ID" ControlToValidate="ArticuloDropDownList" CssClass="ErrorMessage" ValidationGroup="Eliminar" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-sm-4 col-md-3 offset-md-3  ">
                    <asp:TextBox ID="FechaDate" runat="server" type="date" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-ms-4 col-md-1 ">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="FechaDate" ErrorMessage="Fecha Vacia"></asp:RequiredFieldValidator>
                </div>
            </div>
       </div>

        <%--Descripcion--%>
        <div class="form-group">
            <div class="row">
                <div class="offset-md-3 col-ms-4 col-md-4  ">
                    <span>Descripcion:</span>
                </div>
            </div>
        
            <div class="row">
                <div class="offset-md-3 col-ms-4 col-md-3 ">
                    <asp:TextBox ID="DescripcionTextBox" runat="server" CssClass="form-control" placeholder="Descripcion" aria-label="Descripcion"></asp:TextBox>
                </div>
                <div class="col-ms-4 col-md-3 ">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="DescripcionTextBox" ErrorMessage="Llenar la descripcion"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <%--Departamento DropDown--%>
        <div class="form-group">
            <div class="row">
                <div class="offset-md-3 col-sm-4 col-md-4 ">
                    <span>Departamento:</span>
                </div>
            </div>
            <div class="row">
                <div class="offset-md-3 col-sm-4 col-md-3">
                     <asp:DropDownList ID="DepartamentoDropDownList" CssClass="form-control" runat="server" AppendDataBoundItems="true" class="form-control ">
                    </asp:DropDownList>
                </div>
                <div class="col-ms-4 col-md-3 ">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Guardar" CssClass="ErrorMessage" ControlToValidate="DepartamentoDropDownList" ErrorMessage="Debe Agregar un departamento"></asp:RequiredFieldValidator>
                </div>
            </div>
       </div>

        <%--Precio--%>
        <div class="form-group">
            <div class="row">
                <div class="offset-md-3 col-ms-4 col-md-4  ">
                    <span>Precio:</span>
                </div>
            </div>
            <div class="row">
                <div class="offset-md-3 col-sm-8 col-md-3">
                    <asp:TextBox ID="PrecioTextBox" OnTextChanged="PrecioTextBox_TextChanged" AutoPostBack="true" runat="server" TextMode="Number" CssClass="form-control" placeholder="Precio" aria-label="Precio"></asp:TextBox>
                </div>
                <div class="col-sm-8 col-md-3"">
                    <asp:RangeValidator ID="RangeValidator1" runat="server" CssClass="ErrorMessage" MinimumValue="0" MaximumValue="9" ControlToValidate="PrecioTextBox" ErrorMessage="Arreglar Precio"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5"  CssClass="ErrorMessage" ValidationGroup="Guardar" ControlToValidate="PrecioTextBox" runat="server" ErrorMessage="Digite un Precio"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <%--Costo--%>
        <div class="form-group">
            <div class="row">
                <div class="offset-md-3 col-sm-4 col-md-4 ">
                    <span>Costo:</span>
                </div>
            </div>
            <div class="row">
                <div class="offset-md-3 col-sm-8 col-md-3">
                    <asp:TextBox ID="CostoNumeric" OnTextChanged="CostoNumeric_TextChanged" AutoPostBack="true" placeholder="Costo" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-8 col-md-3"">
                    <asp:RangeValidator ID="RangeValidator2"  runat="server" CssClass="ErrorMessage" MinimumValue="0" MaximumValue="9" ControlToValidate="CostoNumeric" ErrorMessage="Arreglar Costo"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="ErrorMessage" ControlToValidate="CostoNumeric" ValidationGroup="Guardar" runat="server" ErrorMessage="Digite un Costo"></asp:RequiredFieldValidator>
                </div>
            </div>
       </div>

        <%--Ganancia--%>
        <div class="form-group">
            <div class="row">
                <div class="offset-md-3 col-sm-4 col-md-4 ">
                    <span>Ganancia:</span>
                </div>
            </div>

            <div class="row">
                <div class=" col-sm-4 offset-md-3 col-md-3">
                    <asp:TextBox ID="GananciaTextBox" type="text" runat="server" CssClass="form-control" placeholder="Ganancia" aria-label="Ganancia" ReadOnly="true" Enabled="false"></asp:TextBox>
                </div>
            </div>
        </div>

        <%--Cantidad--%>
        <div class="form-group">
            <div class="row">
                <div class="offset-md-3 col-sm-8 col-md-4 ">
                    <span>Cantidad:</span>
                </div>

            </div>

            <div class="row">
                <div class=" offset-md-3 col-md-3 col-sm-4">
                    <asp:TextBox ID="CantidadTextBox" type="text" runat="server" CssClass="form-control" placeholder="Cantidad" aria-label="Cantidad" ReadOnly="true" Enabled="false"></asp:TextBox>
                </div>
            </div>
        </div>

        <%--Bottones--%>
        <div class="form-group">
            <div class="row">
                <div class="offset-md-3 col-sm-4 col-md-2">
                    <asp:Button ID="NuevoButton" CausesValidation="false" runat="server" Text="Nuevo" CssClass="form-control btn btn-primary" OnClick="NuevoButton_Click" />
                </div>
                <div class=" col-sm-4 col-md-2 ">
                    <asp:Button ID="GuardarButton" ValidationGroup="Guardar"  runat="server" Text="Guardar" CssClass="form-control btn btn-success" OnClick="GuardarButton_Click" />
                </div>
                <div class=" col-sm-4 col-md-2  ">
                    <asp:Button ID="EliminarButton"  ValidationGroup="Eliminar" runat="server" Text="Eliminar" CssClass="form-control btn btn-danger" OnClick="EliminarButton_Click" />
                </div>

            </div>
      </div>
    </div>
</asp:Content>
