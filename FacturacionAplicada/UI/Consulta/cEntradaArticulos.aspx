<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Registros/Master Page/Diseño.Master" AutoEventWireup="true" CodeBehind="cEntradaArticulos.aspx.cs" Inherits="FacturacionAplicada.UI.Consulta.cEntradaArticulos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <br />
        <br />
        <br />
        <div class="page-header text-center">
            <h1 style="font-size: x-large; font-family: 'Times New Roman', Times, serif; font: bold;"><ins>Consulta de Entrada Articulo</ins></h1>
        </div>

        <%--Filtro y Criterio--%>
        <div class="form-group">
            <div class="row">
                <div class="col-md-4 col-sm-5 col-lg-2">
                    <asp:DropDownList ID="FiltroComboBox" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Todo"></asp:ListItem>
                        <asp:ListItem Text="EntradaArticuloID"></asp:ListItem>
                        <asp:ListItem Text="Cantidad"></asp:ListItem>
                        <asp:ListItem Text="ArticuloID"></asp:ListItem>
                    </asp:DropDownList>

                </div>

                <div class="col-md-4 col-sm-4 offset-sm-1 offset-md-1 col-lg-4 ">
                    <asp:TextBox ID="CriterioTextBox" placeholder="Criterio" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="CriterioTextBox" runat="server" ErrorMessage="Verifique la cadena ingresada y el filtro" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-md-3 col-sm-2">
                    <asp:Button ID="BuscarButton" OnClick="BuscarButton_Click" runat="server" Text="Buscar" CssClass="form-control btn btn-primary" />
                    <asp:Button ID="ImprimirButton" OnClick="ImprimirButton_Click" runat="server" Text="Imprimir" CssClass="form-control btn btn-primary" />
                </div>

            </div>
        </div>

        <%--DatetimePickers--%>
        <div class="form-group">
            <div class="row">
                <div class=" col-sm-5 col-md-4 col-lg-2">
                    <asp:TextBox ID="AHoradateTimePicker1" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                </div>
                <div class=" col-sm-1  col-md-1">
                    <label>TO:</label>
                </div>
                <div class=" col-sm-4 col-md-4 col-lg-2  ">
                    <asp:TextBox ID="FInaldateTimePicker2" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>

        <%--FechaCheckbox--%>
        <div class="form-group">
            <div class="row">
                <div class="col-md-4 col-sm-4 col-lg-2">
                    <asp:CheckBox ID="FechacheckBox" CssClass="form-control" Text="Fecha" runat="server" />
                </div>
            </div>
        </div>

        <%--dataGrid--%>
        <div class="form-group">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <asp:GridView ID="DatosGridView" AllowPaging="true" PageSize="8" OnPageIndexChanging="DatosGridView_PageIndexChanging" runat="server" Width="100%" class="table table-responsive text-center" AutoGenerateColumns="False"
                        CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />

                        <Columns>



                            <asp:BoundField DataField="EntradaArticuloID" HeaderText="EntradaArticuloID" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:MM-dd-yyyy}" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="ArticuloID" HeaderText="ArticuloID" />
                            


                            <asp:TemplateField>
                                <ItemTemplate>
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
    </div>

    <!--Report Modal-->
    <div class="modal fade" id="ModalReporte" role="dialog" >
        <div class="modal-dialog modal-lg" >
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
