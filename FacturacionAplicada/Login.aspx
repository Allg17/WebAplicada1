<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FacturacionAplicada.UI.Registros.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="Content/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Content/js/jquery-3.3.1.min.js"></script>
    <script src="../../Content/js/bootstrap.bundle.min.js"></script>
    <script src="../../Content/js/bootstrap.js"></script>
    <link href="Content/css/toastr.css" rel="stylesheet" />
    <script src="Content/js/toastr.js"></script>
    <title>Inicio de sesion</title>
    <link href="../../Content/css/bootstrap.css" rel="stylesheet" />
    <style>
        h1 {
            font-size: 400%;
            font-family: 'Times New Roman', Times, serif;
            font: bold;
            color: red;
            text-align: center
        }

        img {
            display: block;
            margin: auto;
        }
    </style>
</head>
<body>
    <form id="Login" runat="server">
        <div class="container">

            <br />
            <br />
            <br />
            <div class="page-header text-center">
                <h1><ins>Iniciar Sesion</ins></h1>
            </div>
            <br />
            <div class="row">
                <div class="offset-md-4 col-sm-8 col-md-4">
                    <img src="../../icons/contact-center-ventas.jpg" alt="Logo oficial de el sistema, no pudo cargar." title="Logo +Ventas" width="250" height="200" class="form-control" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class=" offset-md-4 col-sm-8 col-md-4">
                    <span><ins>Nombre de Usuario: </ins></span>
                </div>

            </div>
            <div class="row">
                <div class=" offset-md-4 col-sm-8 col-md-4">
                    <asp:TextBox ID="UsuarioTextBox" runat="server" class="form-control" placeholder="Nombre de Usuario" aria-label="Nombre de Usuario"></asp:TextBox>
                </div>

            </div>
            <br />
            <div class="row">
                <div class=" offset-md-4 col-sm-8 col-md-4">
                    <span><ins>Contraseña:</ins></span>
                </div>
            </div>
            <div class="row">

                <div class="offset-md-4 col-sm-8 col-md-4">
                    <div class="input-group mb-3">
                        <asp:TextBox ID="ClaveTextBox" type="password" runat="server" class="form-control" placeholder="Contraseña" aria-label="Contraseña" aria-describedby="IniciarButton" MaxLength="10"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:Button ID="IniciarButton" CssClass="btn btn-danger" runat="server" Text="Iniciar" OnClick="IniciarButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
