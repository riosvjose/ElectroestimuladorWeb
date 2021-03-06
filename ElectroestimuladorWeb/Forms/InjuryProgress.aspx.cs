﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Text;
using System.Web.UI.HtmlControls;


namespace ElectroestimuladorWeb.Forms
{
    public partial class InjuryProgress : System.Web.UI.Page
    {
        #region "variables"
        DataTable dtParam = new DataTable();
        DataTable dtDatos = new DataTable();
        #endregion

        #region "Libs"

        GEN_VarSession axVarSes = new GEN_VarSession();
        BD_UsersTreatments UsersTreatments = new BD_UsersTreatments();
        #endregion

        #region Procedures

        private void ExportarExcel(GridView gvMatriz)
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
        private void CargarDatos(DataTable dtDatos, DataTable dtParam)
        {
            lblTitulo.Text = dtParam.Rows[0]["titulo"].ToString().Trim();
            
            lblPie.Text = dtParam.Rows[0]["pie"].ToString().Trim();
            UsersTreatments.StrCon= axVarSes.Lee<string>("strCon");
            UsersTreatments.UserId = Convert.ToInt32(axVarSes.Lee<string>("strPersonId"));
            UsersTreatments.BodyPartId = Convert.ToInt32(axVarSes.Lee<string>("strBodyPartId"));
            UsersTreatments.InjuryId = Convert.ToInt32(axVarSes.Lee<string>("strInjuryId"));
            UsersTreatments.WaveId = Convert.ToInt32(axVarSes.Lee<string>("strWaveId"));
            UsersTreatments.TreatmentId = Convert.ToInt32(axVarSes.Lee<string>("strTreatmentId"));
            gvDatos1.Columns[0].Visible = true;
            gvDatos2.Columns[0].Visible = true;
            gvDatos1.Visible = true;
            gvDatos1.DataSource = UsersTreatments.SeeInjuryProgress();
            gvDatos1.DataBind();
            gvDatos2.Visible = true;
            gvDatos2.DataSource = UsersTreatments.SeeInjuryProgress();
            gvDatos2.DataBind();
            gvDatos1.Columns[0].Visible = false;
            gvDatos2.Columns[0].Visible = false;
        }

        private void CargarGrafico(string strTipoGrafico, DataTable dtDatos, DataTable dtParam)
        {
            DataTable dt = new DataTable();
            DataRow row;
            UsersTreatments.StrCon = axVarSes.Lee<string>("strCon");
            UsersTreatments.UserId = Convert.ToInt32(axVarSes.Lee<string>("strPersonId"));
            UsersTreatments.BodyPartId = Convert.ToInt32(axVarSes.Lee<string>("strBodyPartId"));
            UsersTreatments.InjuryId = Convert.ToInt32(axVarSes.Lee<string>("strInjuryId"));
            UsersTreatments.WaveId = Convert.ToInt32(axVarSes.Lee<string>("strWaveId"));
            UsersTreatments.TreatmentId = Convert.ToInt32(axVarSes.Lee<string>("strTreatmentId"));
            int i, j;
            Chart2.Visible = true;
            gvDatos2.Visible = true;
            gvDatos2.DataSource = UsersTreatments.SeeInjuryProgress();
            gvDatos2.DataBind();
            try
            {
                for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                {
                    dt.Columns.Add("Valor" + i);
                }
                dt.Columns.Add("Descripcion");
                for (i = 0; i < gvDatos2.Rows.Count; i++)
                {
                    row = dt.NewRow();
                    //for (j = 1; j <= Convert.ToInt16(dtParam.Rows[0][5]); j++)
                    //{
                        row["Valor" + 1] = gvDatos2.Rows[i].Cells[4].Text; // j+3
                    //}
                    row["Descripcion"] = Server.HtmlDecode(gvDatos2.Rows[i].Cells[5].Text);
                    dt.Rows.Add(row);
                }
                Chart2.DataSource = dt;

                // Adicionar las series
                Chart2.Series.Clear();
                for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                {
                    Chart2.Series.Add("Series" + i);
                }
                for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                {
                    Chart2.Series["Series" + i].YValueMembers = "Valor" + i;
                    Chart2.Series["Series" + i].XValueMember = "Descripcion";
                }

                // Definir intervalo del eje X
                Chart2.ChartAreas[0].AxisX.Interval = 1;
                Chart2.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

                // Definir título y pie
                Chart2.Titles.Clear();
                Chart2.Titles.Add(dtParam.Rows[0][0].ToString());
                Chart2.Titles[0].Font = new Font("Arial", 18, FontStyle.Bold);
                Chart2.Titles[0].ShadowOffset = 0; // true
                Chart2.Titles[0].ShadowColor = Color.Black;

                Chart2.Titles.Add(axVarSes.Lee<string>("StrInjury"));
                Chart2.Titles[1].Alignment = ContentAlignment.BottomCenter;
                Chart2.Titles[1].Font = new Font("Arial", 10, FontStyle.Bold);
                Chart2.Titles.Add(dtParam.Rows[0]["fecha"].ToString());
                Chart2.Titles[2].Alignment = ContentAlignment.BottomCenter;
                Chart2.Titles[2].Font = new Font("Arial", 10, FontStyle.Bold);

                switch (strTipoGrafico)
                {
                    case "1":
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart2.Series["Series" + i].ChartType = SeriesChartType.Line;
                            Chart2.Series["Series" + i].BorderWidth = 3;
                            Chart2.Series["Series" + i].IsValueShownAsLabel = true;
                            Chart2.Series["Series" + i].IsVisibleInLegend = true;
                            Chart2.Series["Series" + i]["DrawingStyle"] = "Cylinder";
                        }
                        break;
                    case "2":
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart2.Series["Series" + i].ChartType = SeriesChartType.Bar;
                            Chart2.Series["Series" + i]["DrawingStyle"] = "Cylinder";
                        }
                        break;
                    case "3":
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart2.Series["Series" + i].ChartType = SeriesChartType.Line;
                        }
                        break;
                    case "4":
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart2.Series["Series" + i].ChartType = SeriesChartType.Area;
                        }
                        break;
                    case "5":
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart2.Series["Series" + i].ChartType = SeriesChartType.FastLine;
                        }
                        break;
                    case "6":
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart2.Series["Series" + i].ChartType = SeriesChartType.Point;
                        }
                        break;
                    case "7":
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart2.Series["Series" + i].ChartType = SeriesChartType.Doughnut;
                            Chart2.Series[0]["PieLabelStyle"] = "Outside";
                        }
                        break;
                    default:
                        for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                        {
                            Chart2.Series["Series" + i].ChartType = SeriesChartType.Point;
                        }
                        break;
                }

                Chart2.ChartAreas["ChartArea1"].AxisX.Title = dtParam.Rows[0][4].ToString();
                Chart2.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);


                Chart2.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = false;
                Chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                Chart2.ChartAreas["ChartArea1"].AxisX.MinorTickMark.Enabled = false;
                Chart2.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Enabled = false;

                Chart2.ChartAreas["ChartArea1"].BackColor = Color.AliceBlue;
                Chart2.ChartAreas["ChartArea1"].BackSecondaryColor = Color.White;
                Chart2.ChartAreas["ChartArea1"].BackGradientStyle = GradientStyle.TopBottom;

                Chart2.ChartAreas["ChartArea1"].AxisY.Title = dtParam.Rows[0][3].ToString();
                Chart2.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

                Chart2.Legends["ChartLegends1"].Docking = Docking.Bottom;
                Chart2.Legends["ChartLegends1"].Alignment = StringAlignment.Center;
                Chart2.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

                //for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                //{
                    Chart2.Series["Series" + 1].IsVisibleInLegend = true;
                    Chart2.Series["Series" + 1].LegendText = gvDatos2.Columns[4].HeaderText; //i+3
                //}
                Chart2.DataBind();
            }
            catch (Exception e)
            {
                Chart2.Visible = false;
                throw;
            }
        }

        private void CargarDatosIniciales(string strCon)
        {
            if (string.IsNullOrEmpty(axVarSes.Lee<string>("strUserID")))
            {
                Response.Redirect("~/Default.aspx");
            }
            UsersTreatments.StrCon = axVarSes.Lee<string>("strCon");
            UsersTreatments.UserId = Convert.ToInt32(axVarSes.Lee<string>("strPersonId"));
            UsersTreatments.BodyPartId = Convert.ToInt32(axVarSes.Lee<string>("strBodyPartId"));
            UsersTreatments.InjuryId = Convert.ToInt32(axVarSes.Lee<string>("strInjuryId"));
            UsersTreatments.WaveId = Convert.ToInt32(axVarSes.Lee<string>("strWaveId"));
            UsersTreatments.TreatmentId = Convert.ToInt32(axVarSes.Lee<string>("strTreatmentId"));
            
            DataTable dtDatos = UsersTreatments.SeeInjuryProgress();
            DataTable dtParam = new DataTable();
            dtParam.Columns.Add("titulo", Type.GetType("System.String"));
            dtParam.Columns.Add("subtitulo", Type.GetType("System.String"));
            dtParam.Columns.Add("fecha", Type.GetType("System.String"));
            dtParam.Columns.Add("subtituloy", Type.GetType("System.String"));
            dtParam.Columns.Add("subtitulox", Type.GetType("System.String"));
            dtParam.Columns.Add("nro_columnas", Type.GetType("System.Int32"));
            dtParam.Columns.Add("total_columna", Type.GetType("System.Int16"));
            dtParam.Columns.Add("total_fila", Type.GetType("System.Int16"));
            dtParam.Columns.Add("pie", Type.GetType("System.String"));
            dtParam.Columns.Add("grafico", Type.GetType("System.String"));
            DataRow rwFila;
            rwFila = dtParam.NewRow();
            rwFila["titulo"] = axVarSes.Lee<string>("strPerson");
            rwFila["subtitulo"] = axVarSes.Lee<string>("strInjury");
            rwFila["fecha"] = axVarSes.Lee<string>("strWave");
            rwFila["subtituloy"] = "Intensidad";
            rwFila["subtitulox"] = "Fecha";
            rwFila["nro_columnas"] = "1";
            //rwFila["pie"] = "tratamiento";
            rwFila["grafico"] = "11";
            rwFila["total_fila"] = 0;
            rwFila["total_columna"] = 0;     // con col total
            dtParam.Rows.Add(rwFila);
            //webForms.Cargar_Dominio("CHART_TYPE", strCon, ref ddlTipoGrafico);
            CargarDatos(dtDatos, dtParam);
            CargarGrafico("0", UsersTreatments.SeeInjuryProgress(), dtParam);
        }
        public void DefinirColumnas(int intNumColumnas)
        {
            dtParam.Columns.Add("titulo", Type.GetType("System.String"));
            dtParam.Columns.Add("subtitulo", Type.GetType("System.String"));
            dtParam.Columns.Add("fecha", Type.GetType("System.String"));
            dtParam.Columns.Add("subtituloy", Type.GetType("System.String"));
            dtParam.Columns.Add("subtitulox", Type.GetType("System.String"));
            dtParam.Columns.Add("nro_columnas", Type.GetType("System.Int32"));
            dtParam.Columns.Add("total_columna", Type.GetType("System.Int16"));
            dtParam.Columns.Add("total_fila", Type.GetType("System.Int16"));
            dtParam.Columns.Add("pie", Type.GetType("System.String"));
            dtParam.Columns.Add("grafico", Type.GetType("System.String"));
            dtDatos.Columns.Add("secuencia", Type.GetType("System.String"));
            dtDatos.Columns.Add("detalle", Type.GetType("System.String"));
            dtDatos.Columns.Add("resumido", Type.GetType("System.String"));
        }
        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(axVarSes.Lee<string>("strCon")))
            {
                Response.Redirect("Salir.aspx");
            }
            else
            {
                CargarDatosIniciales(axVarSes.Lee<string>("strCon"));
            }
            
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInjuries.aspx");
        }
       
        protected void ibtnExportarExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportarExcel(gvDatos1);
        }
        protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        #endregion

    }
}