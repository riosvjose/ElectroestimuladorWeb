<%@ Page Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="InjuryProgress.aspx.cs" Inherits="ElectroestimuladorWeb.Forms.InjuryProgress" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="row">
	            <div class="col-xs-12">
		            <h1>
                        <asp:Label ID="lblTitulo" runat="server" Text="" CssClass="h1"></asp:Label>
		            </h1>
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

            <asp:Panel ID="pnPrincipal" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h2><asp:Label ID="lblActividad" runat="server" Text=""></asp:Label></h2>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-12">
                                <ul class="nav nav-tabs">
                                    <li class="active"><a data-toggle="tab" href="#datos">Datos</a></li>
                                    <li ><a data-toggle="tab" href="#grafico">Gr&aacute;fico</a></li>
                                </ul>
                                <div class="tab-content">
                                    <%-- PANEL DE DATOS --%>
                                    <div id="datos" class="tab-pane fade in active ">
                                        <br/>
                                        <div class="row">
                                        <div class="col-xs-12">
                                            <asp:GridView ID="gvDatos1" runat="server" CssClass="table table-striped table-bordered table-hover input-sm" AutoGenerateColumns="False" PageSize="15" OnSelectedIndexChanged="gvDatos_SelectedIndexChanged" >
                                                <Columns>
                                                           <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Ver" >
                                                            <ItemStyle Width=10%/>
                                                            </asp:CommandField>
                                                            <asp:BoundField DataField="injury" HeaderText="Padecimiento"/>
                                                            <asp:BoundField DataField="treatment" HeaderText="Tratamiento" />
                                                            <asp:BoundField DataField="wave" HeaderText="Onda"/>
                                                            <asp:BoundField DataField="intensity" HeaderText="Intensidad"/>
                                                            <asp:BoundField DataField="date" HeaderText="Fecha"/>
                                                        </Columns>
                                                <PagerStyle CssClass="GridPager" Wrap="True" />
                                                <SelectedRowStyle BackColor="#008A8C" ForeColor="White" />
                                                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </div>
                                       </div>
                                    </div>
                                    <%-- PANEL DE GRÁFICO --%>
                                    <div id="grafico" class="tab-pane fade">
                                        <div class="row mt-3 mb-3">
                                            <div class="col-xs-12">
                                                <div class="form-inline">
                                                    <div class="form-group">
                                                        <asp:Label ID="Label1" runat="server" Text="Tipo de gráfico: " Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="ddlTipoGrafico" runat="server" CssClass="form-control input-sm mr-5" Width="200px" OnSelectedIndexChanged="ddlTipoGrafico_SelectedIndexChanged" AutoPostBack="True" Visible="false"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-3">
                                            <div class="col-xs-12">
                                                <asp:Chart ID="Chart2" runat="server" Height="600px" Width="1000px">
                                                    <Series>
                                                        <asp:Series Name="Series1" ChartArea="ChartArea1" Legend="ChartLegends1"></asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                    </ChartAreas>
                                                    <Legends>
                                                        <asp:Legend Name="ChartLegends1"></asp:Legend>
                                                    </Legends>
                                                </asp:Chart>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="col-xs-12 text-left">
                                <asp:Label ID="lblPie" runat="server" Text="" CssClass="text-primary"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-left">
                                <asp:Button ID="btnRechazar" runat="server" CssClass="btn btn-sm btn-danger" Text="Rechazar" CausesValidation="False" OnClick="btnRechazar_Click" Visible="false"/>
                            </div>
                            <div class="col-xs-12 text-right">
                                <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-sm btn-warning" Text="Volver" CausesValidation="False" OnClick="btnVolver_Click" />
                            </div>
                        </div>
			        </div>
		        </div>
            </asp:Panel>
            
             <%--Tabla de reporte --%>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <div class="row mb-3">
					        <h2></h2>
                        </div>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-12">
                                <asp:GridView ID="gvDatos2" runat="server" CssClass="table table-striped table-bordered table-hover input-sm" AutoGenerateColumns="False" PageSize="15" OnSelectedIndexChanged="gvDatos_SelectedIndexChanged" >
                                    <Columns>
                                                           <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Ver" >
                                                            <ItemStyle Width=10%/>
                                                            </asp:CommandField>
                                                            <asp:BoundField DataField="injury" HeaderText="Padecimiento"/>
                                                            <asp:BoundField DataField="treatment" HeaderText="Tratamiento" />
                                                            <asp:BoundField DataField="wave" HeaderText="Onda"/>
                                                            <asp:BoundField DataField="intensity" HeaderText="Intensidad"/>
                                                            <asp:BoundField DataField="date" HeaderText="Fecha"/>
                                                        </Columns>
                                    <PagerStyle CssClass="GridPager" Wrap="True" />
                                    <SelectedRowStyle BackColor="#008A8C" ForeColor="White" />
                                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
		        </div>
            </asp:Panel>
            <div class="row">
	            <asp:Panel ID="pnMensajeError" runat="server" Visible="false">
		            <div class="alert alert-danger alert-dismissable">
			            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label><a href="#" class="alert-link"></a>.
		            </div>
	            </asp:Panel>

	            <asp:Panel ID="pnMensajeOK" runat="server" Visible="false">
		            <div class="alert alert-success alert-dismissable">
			            <asp:Label ID="lblMensajeOK" runat="server" Text=""></asp:Label><a href="#" class="alert-link"></a>.
		            </div>
	            </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
