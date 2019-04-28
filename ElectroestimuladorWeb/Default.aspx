<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ElectroestimuladorWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no" />
    <meta name="author" content="Ignacio Rios" />
    <link rel="icon" type="image/png" href="Img/escudo.png" />
    <title>Electroestimulador Web</title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/font-awesome.min.css" rel="stylesheet" />
    <link href="Styles/electro.css" rel="stylesheet" />
</head>
<body>
    <br/>
    <br/>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-10">
                <br /><br />        
                <div id="authBody" class="loginPageBody">

                    <%--CABECERA--%>
                    <div id="authHeader">
                        <div class="row">
                            <br />
                            <div class="form-horizontal">
                                <div class="col-xs-12 text-center">
                                   <%--<h1>Bienvenido</h1>--%>
                                    <div class="text-right">
                                        <h3><a style="color:#0e0e38;" href="#">Registrarse</a></h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%--CUERPO--%>
                    <div id="authContent" class="pageContent">
                        <div id="signupBody">
                            <div class="row">
                                <div class="col-xs-12 col-md-6 col-lg-6">
                                    <div class="hidden-xs text-center">
                                        <asp:Image ID="imgSalidas" CssClass="ASR5DCB-d-Vc" ImageUrl="~/Img/Maletin.png" Height="300px" runat="server" />
                                    </div>
                                </div>
                                <div class="col-xs-12 col-md-6 col-lg-6">
                                    <div class="text-left">
                                        <div class="hidden-xs">
                                            <h3>Ingreso al  sistema</h3>
                                        </div>
                                        <div class="visible-xs">
                                            <h4>Ingreso al  sistema</h4>
                                        </div>
                                        <br />
                                          <form id="form1" class="form-horizontal" runat="server">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <fieldset>
                                                        <div class="col-sm-12">
                                                        <div class="form-group">
                                                            <label>Usuario</label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon"><i class="fa fa-user fa-fw"></i></span>
                                                                <asp:TextBox ID="tbUser" CssClass="form-control" placeholder="Ingrese su usuario ..." runat="server" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
                                                            </div>
                                                            <asp:RequiredFieldValidator ID="tbUsuario_RequiredFieldValidator" ControlToValidate="tbUser" runat="server" ErrorMessage="Debe ingresar su usuario." Text="*" CssClass="text-warning"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>Contraseña</label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon"><i class="fa fa-key fa-fw"></i></span>
                                                                <asp:TextBox ID="tbPassword" CssClass="form-control" placeholder="Ingrese su contraseña ..." runat="server" TextMode="Password" MaxLength="32" AutoCompleteType="Disabled"></asp:TextBox>
                                                            </div>
                                                            <asp:RequiredFieldValidator ID="tbPassword_RequiredFieldValidator" ControlToValidate="tbPassword" runat="server" ErrorMessage="Debe ingresar su contraseña." Text="*" CssClass="text-warning"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="text-right">
                                                            <asp:Button ID="btnIngresar" CssClass="btn btn-success" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                                                        </div>
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="imgProcesando" runat="server" ImageUrl="data:image/gif;base64,R0lGODlhEAAQAPIAAP///wAAAMLCwkJCQgAAAGJiYoKCgpKSkiH/C05FVFNDQVBFMi4wAwEAAAAh/hpDcmVhdGVkIHdpdGggYWpheGxvYWQuaW5mbwAh+QQJCgAAACwAAAAAEAAQAAADMwi63P4wyklrE2MIOggZnAdOmGYJRbExwroUmcG2LmDEwnHQLVsYOd2mBzkYDAdKa+dIAAAh+QQJCgAAACwAAAAAEAAQAAADNAi63P5OjCEgG4QMu7DmikRxQlFUYDEZIGBMRVsaqHwctXXf7WEYB4Ag1xjihkMZsiUkKhIAIfkECQoAAAAsAAAAABAAEAAAAzYIujIjK8pByJDMlFYvBoVjHA70GU7xSUJhmKtwHPAKzLO9HMaoKwJZ7Rf8AYPDDzKpZBqfvwQAIfkECQoAAAAsAAAAABAAEAAAAzMIumIlK8oyhpHsnFZfhYumCYUhDAQxRIdhHBGqRoKw0R8DYlJd8z0fMDgsGo/IpHI5TAAAIfkECQoAAAAsAAAAABAAEAAAAzIIunInK0rnZBTwGPNMgQwmdsNgXGJUlIWEuR5oWUIpz8pAEAMe6TwfwyYsGo/IpFKSAAAh+QQJCgAAACwAAAAAEAAQAAADMwi6IMKQORfjdOe82p4wGccc4CEuQradylesojEMBgsUc2G7sDX3lQGBMLAJibufbSlKAAAh+QQJCgAAACwAAAAAEAAQAAADMgi63P7wCRHZnFVdmgHu2nFwlWCI3WGc3TSWhUFGxTAUkGCbtgENBMJAEJsxgMLWzpEAACH5BAkKAAAALAAAAAAQABAAAAMyCLrc/jDKSatlQtScKdceCAjDII7HcQ4EMTCpyrCuUBjCYRgHVtqlAiB1YhiCnlsRkAAAOwAAAAAAAAAAAA==" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                      </div>
                                                    </fieldset>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-xs-12">
                                                            </div>
                                                        <div class="col-xs-12">
                                                         <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="False" ShowSummary="True" CssClass="alert alert-danger" />
                                                        </div>
                                                    </div>
                                                    <div class="col-xs-12 text-center">
                                                        <asp:Label ID="lblMensaje" runat="server" Text="" Visible="FALSE" CssClass="alert alert-danger" Height="70px"></asp:Label>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                     
                                        </form>
                                    </div>   
                                
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--PIE--%>
                    <div id="authFooter">

                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="Scripts/jquery-3.3.1.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
