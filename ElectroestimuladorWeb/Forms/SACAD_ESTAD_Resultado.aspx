<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="SACAD_ESTAD_Resultado.aspx.cs" Inherits="SAcadAdministrativos.Forms.SACAD_ESTAD_Resultado" %>

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
                        
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-12">
                                <ul class="nav nav-tabs">
                                    <li><a data-toggle="tab" href="#datos">Datos</a></li>
                                    <li class="active"><a data-toggle="tab" href="#grafico">Gr&aacute;fico</a></li>
                                </ul>
                                <div class="tab-content">
                                    <%-- PANEL DE DATOS --%>
                                    <div id="datos" class="tab-pane fade">
                                        <div class="row mb-3">
                                            <div class="col-xs-12">
                                                <h3><asp:Label ID="lblSubTitulo" runat="server" Text=""></asp:Label></h3>
                                            </div>
                                        </div>
                                        <div class="row mb-3">
                                            <div class="col-xs-12 text-right">
                                                <asp:ImageButton ID="ibtnExportarExcel" ImageUrl="~/Img/excel.png" runat="server" OnClick="ibtnExportarExcel_Click" />
                                            </div>
                                        </div>
                                        <div class="row mb-3">
                                            <div class="col-xs-12">
                                                <asp:GridView ID="gvDatos" runat="server" CssClass="table table-striped table-bordered table-hover input-sm table-responsive" AutoGenerateColumns="False" >
                                                    <Columns>
                                                        <asp:BoundField DataField="SECUENCIA" HeaderText="SECUENCIA" />
                                                        <asp:BoundField DataField="DETALLE" HeaderText="DETALLE" >
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="resumido" HeaderText="RESUMIDO" />
                                                        <asp:BoundField DataField="COLUMNA01" HeaderText="COLUMNA01" NullDisplayText="0" Visible="False" HtmlEncode="False" HtmlEncodeFormatString="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA02" HeaderText="COLUMNA02" NullDisplayText="0" Visible="False" HtmlEncode="False" HtmlEncodeFormatString="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA03" HeaderText="COLUMNA03" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA04" HeaderText="COLUMNA04" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA05" HeaderText="COLUMNA05" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA06" HeaderText="COLUMNA06" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA07" HeaderText="COLUMNA07" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA08" HeaderText="COLUMNA08" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA09" HeaderText="COLUMNA09" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA10" HeaderText="COLUMNA10" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA11" HeaderText="COLUMNA11" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA12" HeaderText="COLUMNA12" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA13" HeaderText="COLUMNA13" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA14" HeaderText="COLUMNA14" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA15" HeaderText="COLUMNA15" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA16" HeaderText="COLUMNA16" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA17" HeaderText="COLUMNA17" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA18" HeaderText="COLUMNA18" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA19" HeaderText="COLUMNA19" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="COLUMNA20" HeaderText="COLUMNA20" NullDisplayText="0" Visible="False" HtmlEncode="False" >
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <PagerStyle CssClass="lead" Wrap="True" />
                                                    <SelectedRowStyle BackColor="#008A8C" ForeColor="White" />
                                                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                    <%-- PANEL DE GRÁFICO --%>
                                    <div id="grafico" class="tab-pane fade in active">
                                        <div class="row mt-3 mb-3">
                                            <div class="col-xs-12">
                                                <div class="form-inline">
                                                    <div class="form-group">
                                                        <asp:Label ID="Label1" runat="server" Text="Tipo de gráfico: "></asp:Label>
                                                        <asp:DropDownList ID="ddlTipoGrafico" runat="server" CssClass="form-control input-sm mr-5" Width="200px" OnSelectedIndexChanged="ddlTipoGrafico_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                        <asp:CheckBox ID="cb3D" runat="server" CssClass="checkbox mr-5" Text="Ver 3D" OnCheckedChanged="cb3D_CheckedChanged"  AutoPostBack="True"/>
                                                        <asp:CheckBox ID="cbValores" runat="server" CssClass="checkbox mr-5" Text="Mostrar valores" OnCheckedChanged="cbValores_CheckedChanged"  AutoPostBack="True"/>
                                                        <asp:Label ID="Label2" runat="server" Text="Columnas a mostrar" CssClass=""></asp:Label>
                                                        <asp:CheckBoxList ID="cblCampos" runat="server" CssClass="checkbox" RepeatDirection="Horizontal" OnSelectedIndexChanged="cblCampos_SelectedIndexChanged" AutoPostBack="True"></asp:CheckBoxList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-3">
                                            <div class="col-xs-12">
                                                <asp:Chart ID="Chart1" runat="server" Height="600px" Width="1000px">
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
                            <div class="col-xs-12 text-right">
                                <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-sm btn-warning" Text="Volver Opciones" CausesValidation="False" OnClick="btnVolver_Click" />
                            </div>
                        </div>
			        </div>
		        </div>
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
