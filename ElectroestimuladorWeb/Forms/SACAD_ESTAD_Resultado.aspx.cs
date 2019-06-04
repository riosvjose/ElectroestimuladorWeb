using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.IO;
using System.Web.UI.DataVisualization.Charting;
using System.Text;


using System.Web.UI.HtmlControls;

namespace SAcadAdministrativos.Forms
{
    public partial class SACAD_ESTAD_Resultado : System.Web.UI.Page
    {
/*
        #region "Librerias Externas"

        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();

        #endregion

        #region "Clase de tablas de la Base de Datos"

        #endregion

        #region "Funciones y procedimientos"

        private void ExportarExcel(GridView gvMatriz )
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw1 = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw1);
            Page page = new Page();
            HtmlForm form = new HtmlForm();

            gvMatriz.EnableViewState = false;
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(gvMatriz);
            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment; filename=Exportar.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

        private void CargarListadoCampos(DataTable dtParam, DataTable dtDatos)
        {
            for (int i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
            {
                cblCampos.Items.Add(dtDatos.Rows[0][i + 2].ToString());
            }
            for (int i = 0; i < cblCampos.Items.Count; i++)
            {
                cblCampos.Items[i].Selected = true;
            }
        }

        private void ActualizarCabecerasGrid(ref DataTable dtDatos)
        {
            if (dtDatos.Rows.Count > 0)
            {
                for (int i = 0; i < dtDatos.Columns.Count; i++)
                {
                    gvDatos.Columns[i].HeaderText = dtDatos.Rows[0][i].ToString();
                }
            }
        }

        private void CargarDatos(DataTable dtDatos, DataTable dtParam)
        {
            int i;

            lblTitulo.Text = dtParam.Rows[0]["titulo"].ToString().Trim();
            lblSubTitulo.Text = dtParam.Rows[0]["subtitulo"].ToString().Trim();
            lblPie.Text = dtParam.Rows[0]["pie"].ToString().Trim();


            // Numero de columnas
            for (i = 3; i <= Convert.ToInt16(dtParam.Rows[0][5]) + 2; i++)
            {
                gvDatos.Columns[i].Visible = true;
            }

            ActualizarCabecerasGrid(ref dtDatos);
            dtDatos.Rows[0].Delete();
            dtDatos.AcceptChanges();

            gvDatos.Columns[0].Visible = true;
            gvDatos.Columns[2].Visible = true;
            gvDatos.DataSource = dtDatos;
            gvDatos.DataBind();
            
            if (gvDatos.Rows.Count > 0)
            {
                gvDatos.Rows[0].Visible = true;
            }
            
            gvDatos.DataBind();

            gvDatos.Columns[0].Visible = false;
            gvDatos.Columns[2].Visible = false;
        }

        private void CargarGrafico(string strTipoGrafico, DataTable dtDatos, DataTable dtParam)
        {
            DataTable dt = new DataTable();
            DataRow row;
            int i, j;
            Chart1.Visible = true;

            try
            {
                for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                {
                    dt.Columns.Add("Valor" + i);
                }
                dt.Columns.Add("Descripcion");
                for (i = 0; i < gvDatos.Rows.Count - 2; i++)
                {
                    row = dt.NewRow();
                    for (j = 1; j <= Convert.ToInt16(dtParam.Rows[0][5]); j++)
                    {
                        row["Valor" + j] = gvDatos.Rows[i].Cells[j + 2].Text;
                    }
                    row["Descripcion"] = Server.HtmlDecode(gvDatos.Rows[i].Cells[2].Text);
                    dt.Rows.Add(row);
                }
                Chart1.DataSource = dt;
                
                // Adicionar las series
                Chart1.Series.Clear();
                for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                {
                    Chart1.Series.Add("Series" + i);
                }
                for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                {
                    Chart1.Series["Series" + i].YValueMembers = "Valor" + i;
                    Chart1.Series["Series" + i].XValueMember = "Descripcion";
                    Chart1.Series["Series" + i].IsValueShownAsLabel = cbValores.Checked;
                }

                // Definir intervalo del eje X
                Chart1.ChartAreas[0].AxisX.Interval = 1;
                Chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

                // Definir título y pie
                Chart1.Titles.Clear();
                Chart1.Titles.Add(dtParam.Rows[0][0].ToString());
                Chart1.Titles[0].Font = new Font("Arial", 18, FontStyle.Bold);
                Chart1.Titles[0].ShadowOffset = 0; // true
                Chart1.Titles[0].ShadowColor = Color.Black;

                Chart1.Titles.Add("Fecha: " + dtParam.Rows[0][2].ToString());
                Chart1.Titles[1].Alignment = ContentAlignment.BottomCenter;
                Chart1.Titles[1].Font = new Font("Arial", 10, FontStyle.Bold);

                switch (strTipoGrafico)
                {
                    case "1":
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart1.Series["Series" + i].ChartType = SeriesChartType.Column;
                            Chart1.Series["Series" + i]["DrawingStyle"] = "Cylinder";
                        }
                        break;
                    case "2":
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart1.Series["Series" + i].ChartType = SeriesChartType.Bar;
                            Chart1.Series["Series" + i]["DrawingStyle"] = "Cylinder";
                        }
                        break;
                    case "3":
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart1.Series["Series" + i].ChartType = SeriesChartType.Line;
                        }
                        break;
                    case "4":
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart1.Series["Series" + i].ChartType = SeriesChartType.Area;
                        }
                        break;
                    case "5":
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart1.Series["Series" + i].ChartType = SeriesChartType.FastLine;
                        }
                        break;
                    case "6":
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart1.Series["Series" + i].ChartType = SeriesChartType.Point;
                        }
                        break;
                    case "7":
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart1.Series["Series" + i].ChartType = SeriesChartType.Doughnut;
                            Chart1.Series[0]["PieLabelStyle"] = "Outside";
                        }
                        break;
                    default:
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart1.Series["Series" + i].ChartType = SeriesChartType.Column;
                        }
                        break;
                }

                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = cb3D.Checked;
                Chart1.ChartAreas["ChartArea1"].AxisX.Title = dtParam.Rows[0][4].ToString();
                Chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);

                if (!cb3D.Checked)
                {
                    Chart1.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = false;
                    Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                    Chart1.ChartAreas["ChartArea1"].AxisX.MinorTickMark.Enabled = false;
                    Chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Enabled = false;
                }

                Chart1.ChartAreas["ChartArea1"].BackColor = Color.AliceBlue;
                Chart1.ChartAreas["ChartArea1"].BackSecondaryColor = Color.White;
                Chart1.ChartAreas["ChartArea1"].BackGradientStyle = GradientStyle.TopBottom;

                Chart1.ChartAreas["ChartArea1"].AxisY.Title = dtParam.Rows[0][3].ToString();
                Chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

                Chart1.Legends["ChartLegends1"].Docking = Docking.Bottom;
                Chart1.Legends["ChartLegends1"].Alignment = StringAlignment.Center;
                Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

                for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                {
                    Chart1.Series["Series" + i].IsVisibleInLegend = true;
                    Chart1.Series["Series" + i].LegendText = gvDatos.Columns[i+2].HeaderText;
                }

                if (cb3D.Checked)
                {
                    Chart1.Legends["ChartLegends1"].LegendItemOrder = LegendItemOrder.SameAsSeriesOrder;
                    // Copiar las series en un vector
                    Series[] series = new Series[cblCampos.Items.Count];
                    for (i = 0; i < cblCampos.Items.Count; i++)
                    {
                        series[i] = Chart1.Series[i];
                    }
                    // Remover todas las series
                    Chart1.Series.Clear();
                    // Adicionar nuevamente las series en el ´rden que uno desee
                    for (i = 0; i < cblCampos.Items.Count; i++)
                    {
                        Chart1.Series.Add(series[i]);
                    }
                    // Habilitar y deshabilitar series según la selección del usuario
                    for (i = 0; i < cblCampos.Items.Count; i++)
                    {
                        if (cblCampos.Items[i].Selected)
                            Chart1.Series[(cblCampos.Items.Count - 1) - i].Enabled = true;
                        else
                            Chart1.Series[(cblCampos.Items.Count - 1) - i].Enabled = false;
                    }
                }
                else
                {
                    Chart1.Legends["ChartLegends1"].LegendItemOrder = LegendItemOrder.ReversedSeriesOrder;
                    // Habilitar y deshabilitar series según la selección del usuario
                    for (i = 0; i < cblCampos.Items.Count; i++)
                    {
                        if (cblCampos.Items[i].Selected)
                            Chart1.Series[(cblCampos.Items.Count - 1) - i].Enabled = true;
                        else
                            Chart1.Series[(cblCampos.Items.Count - 1) - i].Enabled = false;
                    }
                }
                Chart1.DataBind();
            }
            catch (Exception)
            {
                Chart1.Visible = false;
                throw;
            }
        }

        private void CargarDatosIniciales(string strCon, DataTable dtDatos, DataTable dtParam)
        {
            webForms.Cargar_Dominio("CHART_TYPE", strCon, ref ddlTipoGrafico);
            CargarListadoCampos(dtParam, dtDatos);
            CargarDatos(dtDatos, dtParam);
            CargarGrafico(ddlTipoGrafico.SelectedValue, dtDatos, dtParam);
        }      

        #endregion

        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToInt16(axVarSes.Lee<DataSet>("DSEstadisticas").Tables["parametros"].Rows[0]["nro_columnas"]) <= 20)
                {
                    CargarDatosIniciales(axVarSes.Lee<string>("strConexion"), axVarSes.Lee<DataSet>("DSEstadisticas").Tables["datos"], axVarSes.Lee<DataSet>("DSEstadisticas").Tables["parametros"]);
                }
                else
                {
                    lblTitulo.Text = "¡Columnas excede el máximo permitido!";
                }
                
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(axVarSes.Lee<string>("Forma_Padre"));
        }

        protected void ibtnExportarExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportarExcel(gvDatos);
        }

        protected void ddlTipoGrafico_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrafico(ddlTipoGrafico.SelectedValue, axVarSes.Lee<DataSet>("DSEstadisticas").Tables["datos"], axVarSes.Lee<DataSet>("DSEstadisticas").Tables["parametros"]);
            
        }

        protected void cb3D_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrafico(ddlTipoGrafico.SelectedValue, axVarSes.Lee<DataSet>("DSEstadisticas").Tables["datos"], axVarSes.Lee<DataSet>("DSEstadisticas").Tables["parametros"]);
        }

        protected void cbValores_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrafico(ddlTipoGrafico.SelectedValue, axVarSes.Lee<DataSet>("DSEstadisticas").Tables["datos"], axVarSes.Lee<DataSet>("DSEstadisticas").Tables["parametros"]);
        }

        protected void cblCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrafico(ddlTipoGrafico.SelectedValue, axVarSes.Lee<DataSet>("DSEstadisticas").Tables["datos"], axVarSes.Lee<DataSet>("DSEstadisticas").Tables["parametros"]);
            
        }

        #endregion*/

    }
}