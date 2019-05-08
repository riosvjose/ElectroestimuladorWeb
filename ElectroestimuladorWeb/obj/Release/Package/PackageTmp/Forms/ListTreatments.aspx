﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true"  CodeBehind="ListTreatments.aspx.cs" Inherits="ElectroestimuladorWeb.Forms.ListTreatments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
	            <div class="col-xs-12">
		            <h1>Administrar tratamientos</h1>
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
             <%--panel finded users--%>
            <asp:Panel ID="pnBodyParts" runat="server" Visible="true">
		        <div class="panel panel-info">
                    <%--PANEL HEADING--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblBodyTreatments" runat="server" Text="Partes del cuerpo"></asp:Label></strong></h3>
			        </div>
                    <%--PANEL BODY--%>
			        <div class="panel-body">
                         <br />
                         <div class="row">
                            <div class="col-xs-12">
                                <div class="row">
                                        <div class="col-xs-12">
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:GridView ID="gvDatos1" runat="server" CssClass="table table-striped table-bordered table-hover input-sm" AutoGenerateColumns="False" OnRowCommand="gvDatos1_RowCommand" >
                                                        <Columns>
                                                            <asp:BoundField DataField="treatment_id" HeaderText="ID"  />
                                                            <asp:BoundField DataField="name" HeaderText="Nombre" />
                                                             <asp:ButtonField HeaderText="" ButtonType="Button" CommandName="modify" Text="Modificar" >
                                                                 <ControlStyle CssClass="btn btn-sm btn-warning "/>
                                                            </asp:ButtonField>
                                                            <%--<asp:ButtonField HeaderText="" ButtonType="Button" CommandName="delete" Text="Ver" >
                                                                 <ControlStyle CssClass="btn btn-sm btn-danger "/>
                                                            </asp:ButtonField>--%>
                                                        </Columns>
                                                        <PagerStyle CssClass="GridPager" Wrap="True" />
                                                        <SelectedRowStyle BackColor="#008A8C" ForeColor="White" />
                                                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                    </asp:GridView>
                                                   </div>
                                                </div>
                                        </div>
                                   </div>
                            </div>
                        </div>
                    </div>
                    <%--PANEL FOOTER--%>
                     <div class="panel-footer">
                        <div class="btn-toolbar" role="toolbar">
                            <div class="btn-group">
                                <asp:Button ID="btnCreateNew" runat="server" CssClass="btn btn-primary" Text="Nuevo" CausesValidation="True" OnClick="btnCreateNew_Click"/>
                            </div>
                          </div>
                        </div>
		        </div>
            </asp:Panel>    

            <%--panel modify--%>
            <asp:Panel ID="pnmodify" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--PANEL HEADING--%>
			        <div class="panel-heading">                        
			        </div>
                    <%--PANEL BODY--%>
			        <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-12 col-sm-6 col-md-5 col-lg-4">
                                 <strong><asp:Label ID="lblName" runat="server" Text="Nombre: "></asp:Label></strong>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbName" CssClass="text-danger" ErrorMessage="El campo 'Nombre' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                         <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-5 col-lg-4">
                                 <asp:TextBox ID="tbName" runat="server" CssClass="form-control" MaxLength="60" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                            </div>
                         <div class="row mb-3">
                            <div class="col-xs-12 col-sm-12 col-md-7 col-lg-7">
                                 <strong><asp:Label ID="lblURL" runat="server" Text="URL imagen: "></asp:Label></strong>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbUrl" CssClass="text-danger" ErrorMessage="El campo 'URL imagen' es obligatorio.">*</asp:RequiredFieldValidator>
                                 <asp:TextBox ID="tbUrl" runat="server" CssClass="form-control" MaxLength="100" AutoCompleteType="Disabled"></asp:TextBox>
                              </div>
                            </div>
                         <div class="row">
                            <div class="col-xs-12 col-sm-6 col-md-5 col-lg-4">
                                <strong><asp:Label ID="lblTitle" runat="server" Text="Titulo de imagen: "></asp:Label></strong>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbTitle" CssClass="text-danger" ErrorMessage="El campo 'Titulo de imagen' es obligatorio.">*</asp:RequiredFieldValidator>
                                 <asp:TextBox ID="tbTitle" runat="server" CssClass="form-control" MaxLength="60" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                       </div>
                                           
			        </div>
                    <%--PANEL FOOTER--%>
			        <div class="panel-footer">
                        <div class="btn-toolbar" role="toolbar">
                            <div class="btn-group">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Guardar" CausesValidation="True" OnClick="btnSave_Click" Visible="false"/>
                                <asp:Button ID="btncreate" runat="server" CssClass="btn btn-primary" Text="Crear" CausesValidation="True" OnClick="btncreate_Click" Visible="false"/>
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-warning" Text="Cancelar" CausesValidation="false" OnClick="btnCancel_Click"/>
                            </div>
                          </div>
                        </div>
			        </div>
            </asp:Panel>
            <%--SUCCESS AND ERROR MESSAGES PANEL--%>
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
                    <asp:Panel ID="pnVacio" runat="server" Visible="false">
	                </asp:Panel>
                    <%--ERROR MESSAGE AJAXValidator--%>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="False" ShowSummary="True" CssClass="alert alert-danger" />
	            </div>
            </div>  
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
