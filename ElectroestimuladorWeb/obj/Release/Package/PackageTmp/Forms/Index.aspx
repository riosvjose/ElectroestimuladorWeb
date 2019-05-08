<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ElectroestimuladorWeb.Forms.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="refresh" content="300"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
        <div class="col-lg-12">
            <h1 class="page-header">Inicio</h1>
        </div>
    </div>

    <div class="row">
        <div class="visible-xs">
            <img src="../Img/Escudo.png" class="img-responsive" width="140" alt="Logo" style="margin: 0 auto; padding-top: 15px; padding-bottom: 15px;" />
        </div>
    </div>

    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
            <div class="text-center">

                <asp:LinkButton ID="lbBodyParts" runat="server" OnClick="lbLesiones_Click">
                    <asp:Panel ID="pnBodyParts" runat="server" CssClass="panel-dashboard" role="button" style="margin:0; padding:0;">
                        <div class="hidden-xs">
                            <div class="ASR5DCB-v-l ASR5DCB-v-n">
                                    <asp:Image ID="imgLesiones" CssClass="ASR5DCB-d-Vc" ImageUrl="~/Img/Vendaje.png" Width="70px" Height="70px" runat="server" />
                            </div>
                        </div>
                        <div class="gwt-Label ASR5DCB-v-q ASR5DCB-v-s quantumMediumText">Partes del cuerpo</div>
                       <%-- <div class="gwt-Label ASR5DCB-v-d quantumFadedDescriptionText ASR5DCB-v-e" style="width:200px;">Registre su salida y retorno.</div>--%>
                    </asp:Panel>
                </asp:LinkButton>
            </div>
        </div>
        <div class="visible-xs">
            <div class="col-xs-12">
                <br />
            </div>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
            <div class="text-center">
                <asp:LinkButton ID="lbHistClinica" runat="server" OnClick="lbHistClinica_Click">
                    <asp:Panel ID="pnHistClinica" runat="server" CssClass="panel-dashboard" role="button" style="margin:0; padding:0;">
                        <div class="hidden-xs">
                            <div class="ASR5DCB-v-l ASR5DCB-v-n">
                                <asp:Image ID="imgHistClinica" CssClass="ASR5DCB-d-Vc" ImageUrl="~/Img/carpeta_paciente.png" Width="70px" Height="70px" runat="server" />
                            </div>
                        </div>
                        <div class="gwt-Label ASR5DCB-v-q ASR5DCB-v-s quantumMediumText" style="width:200px;">Historia clínica paciente</div>
                        <%--<div class="gwt-Label ASR5DCB-v-d quantumFadedDescriptionText ASR5DCB-v-e" style="width:200px;">Registre sus tareas.</div>--%>
                    </asp:Panel>
                </asp:LinkButton>
            </div>
        </div>
        <div class="visible-xs">
            <div class="col-xs-12">
                <br />
            </div>
        </div>
        <div class="visible-sm">
            <div class="col-sm-12">
                <br /><br />
            </div>
        </div>                
    </div>
    <div class="visible-lg visible-md">
        <div class="col-lg-12">
            <br /><br />
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
            <%--<div class="text-center">
                <asp:LinkButton ID="lbRepTratamientos" runat="server" OnClick="lbProyectos_Click">
                    <asp:Panel ID="pnProyectos" runat="server" CssClass="panel-dashboard" role="button" style="margin:0; padding:0;">
                        <div class="hidden-xs">
                            <div class="ASR5DCB-v-l ASR5DCB-v-n">
                                <asp:Image ID="imgRepTratamientos" CssClass="ASR5DCB-d-Vc" ImageUrl="~/Img/documentos_medicos.png" Width="70px" Height="70px" runat="server" />
                            </div>
                        </div>
                        <div class="gwt-Label ASR5DCB-v-q ASR5DCB-v-s quantumMediumText" style="width:200px;">Proyectos</div>
                        <div class="gwt-Label ASR5DCB-v-d quantumFadedDescriptionText ASR5DCB-v-e" style="width:200px;">Registre sus proyectos y actividades.</div>
                    </asp:Panel>
                </asp:LinkButton>
            </div>--%>
        </div>
        <div class="visible-xs">
            <div class="col-xs-12">
                <br />
            </div>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
            
        </div>
        <div class="visible-xs">
            <div class="col-xs-12">
                <br />
            </div>
        </div>
        <div class="visible-sm">
            <div class="col-sm-12">
                <br /><br />
            </div>
        </div>
    </div>
   
</asp:Content>
