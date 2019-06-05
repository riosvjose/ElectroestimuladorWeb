<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="SearchUsers.aspx.cs" Inherits="ElectroestimuladorWeb.Forms.SearchUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
	            <div class="col-xs-12">
		            <h1>Buscar personas</h1>
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
            <%--panel Principal--%>
            <asp:Panel ID="pnPrincipal" runat="server">
		        <div class="panel panel-info">
                    <%--PANEL HEADING--%>
			        <div class="panel-heading">                        
			        </div>
                    <%--PANEL BODY--%>
			        <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-12 col-sm-5 col-md-4 col-lg-4">
                                 <strong><asp:Label ID="lblSearchedUser" runat="server" Text="Buscar: "></asp:Label></strong>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbSearch" CssClass="text-danger" ErrorMessage="El campo 'Buscar' es obligatorio.">*</asp:RequiredFieldValidator>
                                 <asp:TextBox ID="tbSearch" runat="server" CssClass="form-control" MaxLength="60" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                       </div>
                                           
			        </div>
                    <%--PANEL footer--%>
			        <div class="panel-footer">
                        <div class="btn-toolbar" role="toolbar">
                            <div class="btn-group">
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Buscar" CausesValidation="True" OnClick="btnSearch_Click" />
                            </div>
                          </div>
                        </div>
			        </div>
            </asp:Panel>
             <%--panel finded users--%>
            <asp:Panel ID="pnFindedUsers" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--PANEL Heading--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lbltitleFindedUsers" runat="server" Text="Coincidencias"></asp:Label></strong></h3>
			        </div>
                    <%--PANEL body--%>
			        <div class="panel-body">
                         <br />
                         <div class="row">
                            <div class="col-xs-12">
                                <div class="row">
                                        <div class="col-xs-12">
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:GridView ID="gvData1" runat="server" CssClass="table table-striped table-bordered table-hover input-sm" AutoGenerateColumns="False" OnRowCommand="gvDatos1_RowCommand" >
                                                        <Columns>
                                                            <asp:BoundField DataField="user_id" HeaderText="ID"  />
                                                            <asp:BoundField DataField="last_name" HeaderText="Apellidos" />
                                                            <asp:BoundField DataField="first_name" HeaderText="Nombres" />
                                                            <asp:BoundField DataField="email" HeaderText="Correo" />
                                                            <asp:ButtonField HeaderText="" ButtonType="Button" CommandName="ver" Text="Ver" >
                                                                 <ControlStyle CssClass="btn btn-sm btn-primary "/>
                                                            </asp:ButtonField>
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
                    <%--PANEL footer--%>
		        </div>
            </asp:Panel>    
            <%--success an error messages panel--%>
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
                    <%--error message AJAXValidator--%>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="False" ShowSummary="True" CssClass="alert alert-danger" />
	            </div>
            </div>  
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
