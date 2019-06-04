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

namespace ElectroestimuladorWeb.Forms
{
    public partial class Results : System.Web.UI.Page
    {
        #region "variables globales"
        DataTable dtParam = new DataTable();
        DataTable dtDatos = new DataTable();
        #endregion
        #region "Librerias Externas"

        GEN_VarSession axVarSes = new GEN_VarSession();

        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_UsersTreatments UserTreatments = new BD_UsersTreatments();
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatos(DataTable dtDatos, DataTable dtParam)
        {
            lblTitulo.Text = dtParam.Rows[0]["titulo"].ToString().Trim();
            lblPie.Text = dtParam.Rows[0]["pie"].ToString().Trim();

            gvDatos1.Columns[1].Visible = true;
            gvDatos1.Columns[3].Visible = true;
            UserTreatments = new BD_UsersTreatments();
            UserTreatments.StrCon = axVarSes.Lee<string>("StrCon");
            UserTreatments.UserId = 1;//Convert.ToInt32(axVarSes.Lee<string>("strProyecto"));//******
            

            UserTreatments = new BD_UsersTreatments();
            gvDatos1.Visible = true;
            gvDatos1.DataSource = UserTreatments.SeeByUser();
            gvDatos1.Columns[1].Visible = true;
            gvDatos1.DataBind();
            gvDatos1.Columns[1].Visible = false;
            for (int i = 0; i < gvDatos1.Rows.Count; i++)
            {
                if (Convert.ToDouble(gvDatos1.Rows[i].Cells[6].Text.Trim()) < 0)
                {
                    gvDatos1.Rows[i].Cells[6].Text = "0";
                }
            }
            gvDatos2.Visible = true;
            gvDatos2.DataSource = UserTreatments.SeeByUser();
            gvDatos2.DataBind();
        }

        private void CargarGrafico(string strTipoGrafico, DataTable dtDatos, DataTable dtParam)
        {
            DataTable dt = new DataTable();
            DataRow row;
            UserTreatments = new BD_UsersTreatments();
            UserTreatments.StrCon = axVarSes.Lee<string>("StrCon");
            UserTreatments.UserId = 1;// Convert.ToInt64(axVarSes.Lee<string>("strProyecto"));************
            int i, j;
            Chart2.Visible = true;
            gvDatos2.Visible = true;
            gvDatos2.DataSource = UserTreatments.SeeByUser();
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
                    for (j = 1; j <= Convert.ToInt16(dtParam.Rows[0][5]); j++)
                    {
                        row["Valor" + j] = gvDatos2.Rows[i].Cells[j + 2].Text; // j+2
                    }
                    row["Descripcion"] = Server.HtmlDecode(gvDatos2.Rows[i].Cells[2].Text);
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

                Chart2.Titles.Add("Fecha: " + dtParam.Rows[0][2].ToString());
                Chart2.Titles[1].Alignment = ContentAlignment.BottomCenter;
                Chart2.Titles[1].Font = new Font("Arial", 10, FontStyle.Bold);

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

                for (i = 1; i <= Convert.ToInt16(dtParam.Rows[0][5]); i++)
                {
                    Chart2.Series["Series" + i].IsVisibleInLegend = true;
                    Chart2.Series["Series" + i].LegendText = gvDatos2.Columns[i + 2].HeaderText; //i+2
                }
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
            if (!string.IsNullOrEmpty(axVarSes.Lee<string>("strUserID")))
            {
        
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        private void CargarDatosGrafica()
        {

            UserTreatments.StrCon = axVarSes.Lee<string>("StrCon");
            UserTreatments.UserId = Convert.ToInt32(axVarSes.Lee<string>("strPersonId"));
            UserTreatments.BodyPartId= Convert.ToInt32(axVarSes.Lee<string>("strBodyPartId"));
            UserTreatments.InjuryId = Convert.ToInt32(axVarSes.Lee<string>("strInjuryId"));
            UserTreatments.WaveId = Convert.ToInt32(axVarSes.Lee<string>("strWaveId"));
            UserTreatments.TreatmentId = Convert.ToInt32(axVarSes.Lee<string>("strTreatmentId"));
            //UserTreatments.SeeByUser();
            DataTable dtDatos = UserTreatments.SeeByUser();
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
            rwFila["titulo"] = "titulo";// UserTreatments.Nombre.Trim();
            rwFila["subtitulo"] = "lesion";// UserTreatments..Trim();
            //rwFila["fecha"] = libOracleBD.Revisar_Fecha_Servidor();
            rwFila["subtituloy"] = "% avance";
            rwFila["subtitulox"] = "Fecha";
            rwFila["nro_columnas"] = "2";
            rwFila["pie"] = "";
            rwFila["grafico"] = "11";
            rwFila["total_fila"] = 0;
            rwFila["total_columna"] = 0;     // con col total
            dtParam.Rows.Add(rwFila);
            //webForms.Cargar_Dominio("CHART_TYPE", strCon, ref ddlTipoGrafico);
            CargarDatos(dtDatos, dtParam);
            CargarGrafico(ddlTipoGrafico.SelectedValue, UserTreatments.SeeByUser(), dtParam);
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

        #region "Events"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (axVarSes.Lee<string>("StrCon") == "" || axVarSes.Lee<string>("StrCon") == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!Page.IsPostBack)
            {
                if ((axVarSes.Lee<string>("StrCon") != "") || (axVarSes.Lee<string>("strProyecto") != ""))
                {
                    CargarDatosIniciales(axVarSes.Lee<string>("StrCon"));
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }


        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("STRS_PROY_REP_Proyectos.aspx");
        }
        protected void ddlTipoGrafico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            axVarSes.Escribe("strEvento", gvDatos1.SelectedRow.Cells[1].Text.Trim());
            Response.Redirect("STRS_PROY_REP_Personas.aspx");
        }
        #endregion

        protected void btnSearDates_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}