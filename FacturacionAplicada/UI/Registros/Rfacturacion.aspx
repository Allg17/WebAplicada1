<%@ Page Title="Facturacion" Language="C#" MasterPageFile="~/UI/Registros/Master Page/Diseño.Master" AutoEventWireup="true" CodeBehind="Rfacturacion.aspx.cs" Inherits="FacturacionAplicada.UI.Registros.Rfacturacion" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <br />
        <br />
        <br />
        <div class="page-header text-center">
            <h1 style="font-size: x-large; font-family: 'Times New Roman', Times, serif; font: bold;"><ins>Facturacion</ins></h1>
        </div>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <%--id Dropdown y fecha--%>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-3 col-md-2 offset-md-3">
                            ID:
                    <asp:DropDownList ID="FacturaDropDownList" OnTextChanged="FacturaDropDownList_TextChanged" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:CustomValidator ID="CustomValidator1" ControlToValidate="FacturaDropDownList" OnServerValidate="CustomValidator1_ServerValidate" CssClass="ErrorMessage" ValidationGroup="Eliminar" runat="server" ErrorMessage="Seleccione un ID"></asp:CustomValidator>

                        </div>
                        <div class=" col-sm-3 col-md-2 offset-md-2">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <fieldset>
                                        Fecha:
                                <asp:TextBox ID="Fecha" type="date" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate-="Fecha" ValidationGroup="Guardar" CssClass="ErrorMessage" runat="server" ErrorMessage="Seleccione una Fecha"></asp:RequiredFieldValidator>
                                    </fieldset>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                </div>

                <%--Tipo Factura o forma de pago DropDown--%>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-4 col-md-2 offset-md-3">
                            <asp:DropDownList ID="FormadePagoDropDownList" OnTextChanged="FormadePagoDropDownList_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server">
                                <asp:ListItem Text="Contado" />
                                <asp:ListItem Text="Credito" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <%--Cliente DropDown--%>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-4 col-md-2 offset-md-3">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <fieldset>
                                        Cliente:
                                <asp:DropDownList ID="CLienteDropDownList" CssClass="form-control " runat="server" aria-describedby="NombreClienteTextBox">
                                </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="CLienteDropDownList" ValidationGroup="Guardar" CssClass="ErrorMessage" runat="server" ErrorMessage="Seleccione un Cliente"></asp:RequiredFieldValidator>
                                    </fieldset>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

                <%--descripcion--%>
                <div class="form-group">
                    <div class="row">
                        <div class="offset-md-3  col-sm-12 col-md-7">
                            Descripcion:
                    <asp:TextBox ID="DescripcionTextBox" runat="server" TextMode="MultiLine" CssClass="form-control " placeholder="Descripcion" aria-label="Descripcion"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <%--Articulo DropDown--%>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-4 col-md-4  offset-md-3 ">
                            Articulo:
                    <div class="input-group md-3">
                        <asp:DropDownList ID="ArticuloDropDownList" OnTextChanged="ArticuloDropDownList_TextChanged" AppendDataBoundItems="true" AutoPostBack="true" ontextAppendDataBoundItems="true" CssClass="form-control  text-center" runat="server"></asp:DropDownList>
                        <div class="input-group-append">
                            <label class="form-control">Precio:</label>
                            <asp:TextBox ID="PrecioArticuloTextBox" CssClass="form-control  text-center" runat="server" Enabled="false" placeholder="Precio Articulo" aria-label="Precios Articulo"></asp:TextBox>
                        </div>
                    </div>
                            <%--Validator--%>
                            <asp:CustomValidator ID="CustomValidator2" ControlToValidate="ArticuloDropDownList" CssClass="ErrorMessage" ValidationGroup="Agregar" OnServerValidate="CustomValidator2_ServerValidate" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
                        </div>
                    </div>
                </div>

                <%--Cantidad, AgregarButton, Importe--%>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-4 col-md-2 offset-md-3">
                            Cantidad:
                    <div class="input-group mb-3">
                        <asp:TextBox ID="CantidadTextBox" OnTextChanged="CantidadTextBox_TextChanged" AutoPostBack="true" CssClass="form-control  text-center" type="number" runat="server" placeholder="Cantidad" aria-label="Cantidad" aria-describedby="AgregarButton"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:Button ID="AgregarButton" OnClick="AgregarButton_Click" ValidationGroup="Agregar" CssClass="form-control btn btn-warning" runat="server" Text="Agregar" />
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="CantidadTextBox" ValidationGroup="Agregar" CssClass="ErrorMessage" runat="server" ErrorMessage="Ingrese una cantidad"></asp:RequiredFieldValidator>
                    </div>
                        </div>
                        <div class="col-sm-4 col-md-2 offset-md-0">
                            Importe:
                    <asp:TextBox ID="ImporteTextBox" CssClass="form-control  text-center" runat="server" Enabled="false" placeholder="Importe" aria-label="Importe"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <%--DataGrid--%>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-4 col-md-8 offset-md-3">

                            <asp:GridView ID="FacturaDetalleGridView" AllowPaging="true" PageSize="5" OnPageIndexChanging="FacturaDetalleGridView_PageIndexChanging" runat="server" Width="100%" class="table table-striped table-hover table-responsive-lg" AutoGenerateColumns="False"
                                CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID">
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


                                            <asp:Button ID="EnviarAlModalModificar" CommandName="Select" CssClass="btn btn-secondary form-control" runat="server"
                                                Text="Modificar" OnClick="EnviarAlModalModificar_Click" />
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
                </div>

                <%--Efectivo, Devuelta, Monto--%>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-4 col-md-7  offset-md-3">
                            <%--Efectivo--%>
                    Efectivo:
                    <div class="input-group mb-3">
                        <asp:TextBox ID="EfectivoNumeric" Text="0" OnTextChanged="EfectivoNumeric_TextChanged" AutoPostBack="true" type="number" CssClass="form-control col-md-1 " Style="font-size: 90%" runat="server" aria-label="Efectivo" placeholder="Efectivo"></asp:TextBox>
                        <div class="input-group-append">
                            <%--Devuelta--%>
                            <div class="input-group mb-3">
                                <label class="form-control col-md-2">Devuelta:</label>
                                <asp:TextBox ID="DevueltaTextBox" CssClass="form-control text-center" runat="server" Enabled="false" aria-describedby="MontoTextBox" placeholder="Devuelta" aria-label="Devuelta"></asp:TextBox>
                                <label class="form-control col-md-2">Monto:</label>
                                <%--Monto--%>
                                <div class="input-group-append">
                                    <asp:TextBox ID="MontoTextBox" CssClass="form-control text-center " runat="server" Enabled="false" placeholder="Monto" aria-label="Monto"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                    </div>
                            <%--validator--%>
                            <asp:CustomValidator ID="EfectivoCustomValidator" ValidationGroup="Guardar" OnServerValidate="EfectivoCustomValidator_ServerValidate" ControlToValidate="EfectivoNumeric" CssClass="ErrorMessage" runat="server" ErrorMessage="Ingrese el Efectivo"></asp:CustomValidator>
                            <asp:CustomValidator ID="DevueltaCustomValidator" ValidationGroup="Guardar" OnServerValidate="DevueltaCustomValidator_ServerValidate" ControlToValidate="DevueltaTextBox" CssClass="ErrorMessage" runat="server" ErrorMessage="Arreglar el efectivo ingresado y Verificque con el total"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Guardar" runat="server" ControlToValidate="MontoTextBox" CssClass="ErrorMessage" ErrorMessage="No se ha hecho ninguna seleccion de Articulos"></asp:RequiredFieldValidator>

                        </div>

                    </div>
                </div>
                <%--Botones--%>
                <div class="form-group">
                    <div class="row">
                        <div class="offset-md-3 col-sm-4 col-md-2">
                            <asp:Button ID="NuevoButton" runat="server" OnClick="NuevoButton_Click" Text="Nuevo" CssClass="form-control btn btn-primary" />
                        </div>
                        <div class=" col-sm-4 col-md-2 ">
                            <asp:Button ID="GuardarButton" ValidationGroup="Guardar" OnClick="GuardarButton_Click" runat="server" Text="Guardar" CssClass="form-control btn btn-success" />
                        </div>
                        <div class=" col-sm-4 col-md-2  ">
                            <asp:Button ID="EliminarButton" OnClick="EliminarButton_Click" ValidationGroup="Eliminar" runat="server" Text="Eliminar" CssClass="form-control btn btn-danger" />
                        </div>
                        <div class=" col-sm-4 col-md-2  ">
                            <asp:Button ID="ImprimirButton" OnClick="ImprimirButton_Click" CausesValidation="false" runat="server" Text="Imprimir" CssClass="form-control btn btn-info" />
                        </div>
                    </div>

                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="NuevoButton" />
                <asp:AsyncPostBackTrigger ControlID="GuardarButton" />
                <asp:AsyncPostBackTrigger ControlID="EliminarButton" />
                <asp:AsyncPostBackTrigger ControlID="FacturaDropDownList" />
                <asp:AsyncPostBackTrigger ControlID="FormadePagoDropDownList" />
                <asp:AsyncPostBackTrigger ControlID="ArticuloDropDownList" />
                <asp:AsyncPostBackTrigger ControlID="CantidadTextBox" />
                <asp:AsyncPostBackTrigger ControlID="AgregarButton" />
                <asp:AsyncPostBackTrigger ControlID="FacturaDetalleGridView" />
                <asp:AsyncPostBackTrigger ControlID="EfectivoNumeric" />
            </Triggers>
        </asp:UpdatePanel>

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

        <!--Modal de confirmacion de Modificar-->
        <div class="modal" id="ModalModificar">
            <div class="modal-dialog" role="document">
                <div class="modal-content ">
                    <div class="modal-header bg-danger">
                        <h5 class="modal-title">¡Atencion!</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>Estas seguro de Modificar este Articulo?</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="ModificarArticuloButton" runat="server" CssClass="btn btn-danger" Text="Si" OnClick="ModificarArticuloButton_Click" />
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Report Modal-->
    <div class="modal fade" id="ModalReporte" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content ">
                <div class="modal-header bg-danger">
                    <h5 class="modal-title">Imprimir</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div id="div1">

                        <rsweb:ReportViewer ID="DatosReportViewer" runat="server" Width="100%">
                            <ServerReport ReportPath="" ReportServerUrl="" />
                        </rsweb:ReportViewer>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
