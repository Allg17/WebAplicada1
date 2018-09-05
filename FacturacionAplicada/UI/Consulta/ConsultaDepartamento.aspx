<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Registros/Master Page/Diseño.Master" AutoEventWireup="true" CodeBehind="ConsultaDepartamento.aspx.cs" Inherits="FacturacionAplicada.UI.Consulta.ConsultaDepartamento" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="row">
            <div class="col-md-4">
                <asp:DropDownList ID="FiltroComboBox" runat="server">
                    <asp:ListItem Text="Todo"></asp:ListItem>
                    <asp:ListItem Text="ID"></asp:ListItem>
                    <asp:ListItem Text="Nombre"></asp:ListItem>
                </asp:DropDownList>

            </div>

            <div class="col-md-4">
                <asp:TextBox ID="CriterioTextBox" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Button ID="BuscarButton" OnClick="BuscarButton_Click" runat="server" Text="Buscar" CssClass="form-control btn btn-primary" />
            </div>

        </div>
        <div class="row">
            <div class="col-md-8">
                <asp:GridView ID="DatosGridView" AllowPaging="true" PageSize="8" OnPageIndexChanging="FacturaDetalleGridView_PageIndexChanging" runat="server" Width="100%" class="table table-responsive text-center" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="DepartamentoId,Nombre">
                    <AlternatingRowStyle BackColor="White" />

                    <Columns>

                       

                        <asp:BoundField DataField="DepartamentoId" HeaderText="FacturaID" />
                        <asp:BoundField DataField="Nombre" HeaderText="ProductoID" />


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



</asp:Content>
