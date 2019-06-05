<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Secondary.Master" AutoEventWireup="true" CodeBehind="RecoverAccountForm.aspx.cs" Inherits="ElectroestimuladorWeb.Forms.RecoverAccountForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
           
        </Triggers>
        <ContentTemplate>

            <div class="row">
	            <div class="col-xs-12 col-md-6 pull-left">
		            <h1>Recuperar cuenta de usuario</h1>
	            </div>
                
            </div>
            <div class="row">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="fa-lg text-danger">
                                    <i class="fa fa-spinner fa-spin"></i> Procesando, un momento por favor ...
                                    <br /><br />
                                </div>
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            <br />
            <asp:Panel ID="pnUserData" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblTitle" runat="server" Text="Datos personales"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <br/>
                        <div class="row mb-3">
                                <div class="col-xs-12 col-sm-6 col-md-3 col-lg-2">
                                    <strong><asp:Label ID="lblLastName" runat="server">Apellidos: </asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbLastName" CssClass="text-danger" ErrorMessage="El campo 'Primer apellido' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                             <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                  <asp:TextBox ID="tbLastName" runat="server" CssClass="form-control" MaxLength="100" AutoCompleteType="Disabled" ></asp:TextBox>
                                </div>
                            </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-2">
                                    <strong><asp:Label ID="lblFirstName" runat="server">Nombres: </asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbFirstName" CssClass="text-danger" ErrorMessage="El campo 'Segundo apellido' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                      <asp:TextBox ID="tbFirstName" runat="server" CssClass="form-control" MaxLength="40" AutoCompleteType="Disabled" ></asp:TextBox>
                                </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-2">
                                    <strong><asp:Label ID="lblBirthdate" runat="server">Fecha de nacimiento:</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbBirthDate" CssClass="text-danger" ErrorMessage="El campo 'N° Documento de identidad' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                      <asp:TextBox ID="tbBirthDate" runat="server" CssClass="form-control" TextMode="Date" AutoCompleteType="Disabled" ></asp:TextBox>
                                </div>
                            </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-2">
                                    <strong><asp:Label ID="lblemail" runat="server" >Correo electrónico: </asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbemail" CssClass="text-danger" ErrorMessage="El campo 'Nombre' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                      <asp:TextBox ID="tbemail" runat="server" TextMode="Email" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled" ></asp:TextBox>
                                </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-2">
                                    <strong><asp:Label ID="lblphone" runat="server">Teléfono: </asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbPhone" CssClass="text-danger" ErrorMessage="El campo 'N° Documento de identidad' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                      <asp:TextBox ID="tbPhone" runat="server" CssClass="form-control" TextMode="Phone" MaxLength="20" AutoCompleteType="Disabled" ></asp:TextBox>
                                </div>
                            </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-2">
                                    <strong><asp:Label ID="lblPassword" runat="server">Nueva contraseña: </asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbPassword" CssClass="text-danger" ErrorMessage="El campo 'N° Documento de identidad' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                      <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" TextMode="Password" MaxLength="20" AutoCompleteType="Disabled" ></asp:TextBox>
                                </div>
                            </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-2">
                                    <strong><asp:Label ID="lblpwd" runat="server">Confirmar contraseña:</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbpwd" CssClass="text-danger" ErrorMessage="El campo 'N° Documento de identidad' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                      <asp:TextBox ID="tbpwd" runat="server" CssClass="form-control" TextMode="Password" MaxLength="20" AutoCompleteType="Disabled" ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    <%--PIE DEL PANEL--%>	
                     <div class="panel-footer">
                        <div class="btn-toolbar" role="toolbar">
                            <div class="btn-group">
                                <asp:Button ID="btnRecover" runat="server" CssClass="btn btn-success" Text="Recuperar" CausesValidation="True" OnClick="btnRecover_Click"/>
                            </div>
                          </div>
                        </div>
			   </div>
            </asp:Panel>
          
           <%--Mensajes de exito y error--%>
            <div class="row">
	            <div class="col-md-6">
	                <asp:Panel ID="pnError" runat="server" Visible="false">
		                <div class="alert alert-danger alert-dismissable">
			                <asp:Label ID="lblError" runat="server" Text=""></asp:Label><a href="#" class="alert-link"></a>.
		                </div>                        
	                </asp:Panel>
	                <asp:Panel ID="pnOK" runat="server" Visible="false">
		                <div class="alert alert-success alert-dismissable">
			                <asp:Label ID="lblOK" runat="server" Text=""></asp:Label><a href="#" class="alert-link"></a>.
		                </div>
	                </asp:Panel>
                    <%--Panel Final de la pagina--%>
                    <asp:Panel ID="pnFinal" runat="server" Visible="false">
                        <div class="alert alert-light">
			                <asp:Label ID="lblFinal" runat="server" Text=""></asp:Label><a href="#" class="alert-link"></a>
		                </div>
                    </asp:Panel> 
                    <%--Mensaje de Error AJAXValidator--%>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="False" ShowSummary="True" CssClass="alert alert-danger" />                    
	            </div>                
            </div>               
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
