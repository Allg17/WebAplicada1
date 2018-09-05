<%@ Page Title="Facturacion" Language="C#" MasterPageFile="~/UI/Registros/Master Page/Diseño.Master" AutoEventWireup="true" CodeBehind="Rfacturacion.aspx.cs" Inherits="FacturacionAplicada.UI.Registros.Rfacturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header text-center">
            <h1 style="font-size: x-large; font-family: 'Times New Roman', Times, serif; font: bold;"><ins>Facturacion</ins></h1>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-3 col-md-2 offset-md-3">
                <asp:DropDownList ID="FacturaDropDownList" OnTextChanged="FacturaDropDownList_TextChanged" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class=" col-sm-3 col-md-2 offset-md-3">
                <asp:TextBox ID="Fecha" type="date" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4 col-md-2 offset-md-3">
                <asp:DropDownList ID="FormadePagoDropDownList" OnTextChanged="FormadePagoDropDownList_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server">
                    <asp:ListItem Text="Contado" />
                    <asp:ListItem Text="Credito" />
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4 col-md-2 offset-md-3">

                <asp:DropDownList ID="CLienteDropDownList" CssClass="form-control " runat="server" aria-describedby="NombreClienteTextBox">
                </asp:DropDownList>

            </div>
        </div>
        <br />
        <div class="row">
            <div class="offset-md-3  col-sm-12 col-md-7">
                <asp:TextBox ID="DescripcionTextBox" runat="server" TextMode="MultiLine" CssClass="form-control " placeholder="Descripcion" aria-label="Descripcion"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">


            <div class="col-sm-4 col-md-4  offset-md-3 ">
                <div class="input-group md-3">
                    <asp:DropDownList ID="ArticuloDropDownList" OnTextChanged="ArticuloDropDownList_TextChanged" AppendDataBoundItems="true" AutoPostBack="true" ontextAppendDataBoundItems="true" CssClass="form-control  text-center" runat="server"></asp:DropDownList>
                    <div class="input-group-append">
                        <asp:TextBox ID="PrecioArticuloTextBox" CssClass="form-control  text-center" runat="server" Enabled="false" placeholder="Precio Articulo" aria-label="Precios Articulo"></asp:TextBox>
                    </div>
                </div>
            </div>

        </div>
        <br />
        <div class="row">
            <div class="col-sm-4 col-md-2 offset-md-3">
                <div class="input-group mb-3">
                    <asp:TextBox ID="CantidadTextBox" OnTextChanged="CantidadTextBox_TextChanged" AutoPostBack="true" CssClass="form-control  text-center" type="number" runat="server" placeholder="Cantidad" aria-label="Cantidad" aria-describedby="AgregarButton"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button ID="AgregarButton" OnClick="AgregarButton_Click" CssClass="form-control btn btn-warning" runat="server" Text="Agregar" />
                    </div>
                </div>
            </div>
            <div class="col-sm-4 col-md-2 offset-md-0">
                <asp:TextBox ID="ImporteTextBox" CssClass="form-control  text-center" runat="server" Enabled="false" placeholder="Importe" aria-label="Importe"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4 col-md-8 offset-md-3">

                <asp:GridView ID="FacturaDetalleGridView" AllowPaging="true" AutoGenerateEditButton="true" OnRowEditing="FacturaDetalleGridView_RowEditing" PageSize="5" OnPageIndexChanging="FacturaDetalleGridView_PageIndexChanging" runat="server" Width="100%" class="table table-responsive text-center" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID,FacturaId">
                    <AlternatingRowStyle BackColor="White" />

                    <Columns>

                        <asp:BoundField DataField="ID" HeaderText="ID" />

                        <asp:BoundField DataField="FacturaID" HeaderText="FacturaID" />
                        <asp:BoundField DataField="ProductoID" HeaderText="ProductoID" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="Importe" HeaderText="Importe" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="EnviarAlModalEliminarButton" CommandName="Select" CssClass="btn btn-dark form-control" runat="server"
                                    Text="Eliminar" OnClick="EnviarAlModalEliminarButton_Click" />
                            
                          
                                <asp:Button ID="Modificar" CommandName="Select" CssClass="btn btn-secondary form-control" runat="server"
                                    Text="Modificar" OnClick="Modificar_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="red" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="red" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="red" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="darksalmon" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>

            </div>
        </div>

        <br />
        <div class="row">
            <div class="col-sm-4 col-md-5  offset-md-3">
                <div class="input-group mb-3">
                    <asp:TextBox ID="EfectivoNumeric" OnTextChanged="EfectivoNumeric_TextChanged" AutoPostBack="true" type="number" CssClass="form-control " Style="font-size: 90%" runat="server" aria-label="Efectivo" placeholder="Efectivo"></asp:TextBox>
                    <div class="input-group-append">
                        <div class="input-group mb-3">
                            <asp:TextBox ID="DevueltaTextBox" CssClass="form-control text-center" runat="server" Enabled="false" aria-describedby="MontoTextBox" placeholder="Devuelta" aria-label="Devuelta"></asp:TextBox>
                            <div class="input-group-append">
                                <asp:TextBox ID="MontoTextBox" CssClass="form-control text-center " runat="server" Enabled="false" placeholder="Monto" aria-label="Monto"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="offset-md-3 col-sm-4 col-md-2">
                <asp:Button ID="NuevoButton" runat="server" OnClick="NuevoButton_Click" Text="Nuevo" CssClass="form-control btn btn-primary" />
            </div>
            <div class=" col-sm-4 col-md-2 ">
                <asp:Button ID="GuardarButton" OnClick="GuardarButton_Click" runat="server" Text="Guardar" CssClass="form-control btn btn-success" />
            </div>
            <div class=" col-sm-4 col-md-2  ">
                <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" CssClass="form-control btn btn-danger" />
            </div>
            <div class=" col-sm-3 col-md-2 ">
                <asp:Button ID="CancelarButton" OnClick="CancelarButton_Click" runat="server" Text="Cancelar" CssClass="form-control btn btn-info" />
            </div>

        </div>

        <!--Modal de confirmacion de eliminar-->
        <div class="modal" id="ModalEliminar">
            <div class="modal-dialog" role="document">
                <div class="modal-content ">
                    <div class="modal-header bg-danger">
                        <h5 class="modal-title">¡Atencion!</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>Estas seguro de eliminar este Articulo?</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Eliminar" runat="server" CssClass="btn btn-danger" Text="Si" OnClick="Eliminar_Click" />
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
