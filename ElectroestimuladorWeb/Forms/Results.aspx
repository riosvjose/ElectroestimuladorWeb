<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="ElectroestimuladorWeb.Forms.Results" %>
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
            <asp:Panel ID="pnDates" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lbldates" runat="server" Text="Rango de fechas del reporte"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                         <br/>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblInitDate" runat="server" Text="Fecha de inicio"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="tbInitdate" CssClass="text-danger" ErrorMessage="El campo fecha inicio es obligatorio.">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator33" runat="server" ControlToValidate="tbInitdate" CssClass="text-danger" ErrorMessage="El formato de la fecha es incorrecto (DD/MM/YYYY)" Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                                </strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbInitdate" runat="server" CssClass="form-control" MaxLength="10" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="tbInitdate_CalendarExtender" runat="server" BehaviorID="tbInitdate_CalendarExtender" TargetControlID="tbInitdate" />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-2">
                                <strong><asp:Label ID="lblEndDate" runat="server" Text="Fecha Fin:"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="tbEndDate" CssClass="text-danger" ErrorMessage="El campo fecha fin es obligatorio.">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator35" runat="server" ControlToValidate="tbEndDate" CssClass="text-danger" ErrorMessage="El formato de la fecha es incorrecto (DD/MM/YYYY)" Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator34" runat="server" ControlToCompare="tbEndDate" ControlToValidate="tbInitdate" CssClass="text-danger" ErrorMessage="La 'Fecha fin' de la búsqueda debe ser mayor o igual que la fecha de inicio." Operator="LessThanEqual" Type="Date">*</asp:CompareValidator>
                                </strong>
                            </div>
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7">
                                <asp:TextBox ID="tbEndDate" runat="server" CssClass="form-control" MaxLength="10" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="tbEndDate_CalendarExtender" runat="server" BehaviorID="tbEndDate_CalendarExtender" TargetControlID="tbEndDate" />
                            </div>
                        </div>
                       </div> 
                    <%--PIE DEL PANEL--%>	 
                     <div class="panel-footer">
                        <div class="row">
                            <div class="btn-group">
                                     <asp:Button ID="btnSearDates" runat="server" CssClass="btn btn-primary" Text="Buscar" CausesValidation="True" OnClick="btnSearDates_Click" />
                                     <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClick="btnCancel_Click" />
                                </div>
                        </div>
			        </div>
			   </div>
            </asp:Panel>
            <asp:Panel ID="pnPrincipal" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        
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
                                                    <asp:BoundField DataField="num_sec_tarea" HeaderText="No." ItemStyle-Width=10%/>
                                                    <asp:BoundField DataField="nombre" HeaderText="Actividad" />
                                                    <asp:BoundField DataField="porcentaje" HeaderText="Valor porcentual" ItemStyle-Width=10%/>
                                                    <asp:BoundField DataField="fecha_inicio" HeaderText="Inicio" ItemStyle-Width=10%/>
                                                    <asp:BoundField DataField="fecha_fin" HeaderText="Fin" ItemStyle-Width=10%/>
                                                    <asp:BoundField DataField="p_avance" HeaderText="Avance a la fecha(%)" ItemStyle-Width=10%/> 
                                                    <asp:BoundField DataField="p_avance_esperado" HeaderText="Avance esperado(%)" ItemStyle-Width=10%/> 
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
					        <h2>Avance por persona</h2>
                        </div>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-12">
                                <asp:GridView ID="gvDatos2" runat="server" CssClass="table table-striped table-bordered table-hover input-sm" AutoGenerateColumns="False" PageSize="15" OnSelectedIndexChanged="gvDatos_SelectedIndexChanged" >
                                    <Columns>
                                       <asp:BoundField DataField="secuencia" HeaderText="Nro" ItemStyle-Width=20% />
                                       <asp:BoundField DataField="resumido" HeaderText="Fecha" ItemStyle-Width=20% />
                                       <asp:BoundField DataField="detalle" HeaderText="detalle" />
                                       <asp:BoundField DataField="p_avance" HeaderText="Avance a la fecha(%)" ItemStyle-Width=10%/> 
                                       <asp:BoundField DataField="p_avance_esperado" HeaderText="Avance a esperado(%)" ItemStyle-Width=10%/> 
                                    </Columns>
                                    <PagerStyle CssClass="GridPager" Wrap="True" />
                                    <SelectedRowStyle BackColor="#008A8C" ForeColor="White" />
                                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </div>
                        </div>
			        </div>
                    <%--PIE DEL PANEL--%>
			        <div class="panel-footer">
                        <div class="row">
                            <div class="col-xs-10">
                                
                            </div>
                            <div class="col-xs-2 text-right">
                                <asp:Button ID="btnVolverMenu" runat="server" CssClass="btn btn-warning btn-default btn-block" Text="Volver" CausesValidation="False" OnClick="btnVolver_Click" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
