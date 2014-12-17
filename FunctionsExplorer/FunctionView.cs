using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FunctionsExplorer.Functions;

namespace FunctionsExplorer
{
    public class FunctionView : Panel
    {
        private Chart chart;
        public FunctionView()
        {
            Width = 600;
            Height = 300;
            BorderStyle = BorderStyle.Fixed3D;

            chart = new Chart
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
                Size = new Size(Width, Height)
            };
            Controls.Add(chart);
        }

        public void Draw(BaseFunction func)
        {
            try
            {
                chart.ChartAreas.Clear();
            }
            catch (NullReferenceException)
            {
                chart = new Chart();
            }
            chart.Series.Clear();

            chart.ChartAreas.Add("Default");
            chart.Series.Add("f").Color = Color.Firebrick;
            chart.Series["f"].BorderWidth = 3;
            chart.Series["f"].ChartType = SeriesChartType.Line;

            foreach (var point in func.ResultPoints)
            {
                chart.Series["f"].Points.AddXY(point.X, point.Y);
            }

            chart.ChartAreas[0].AxisX.IsStartedFromZero = true;
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.Crossing = 0;
            chart.ChartAreas[0].AxisX.Minimum = -30;
            chart.ChartAreas[0].AxisX.Maximum = 30;
            chart.ChartAreas[0].AxisX.Interval = 4;

            chart.ChartAreas[0].AxisY.IsStartedFromZero = true;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.Crossing = 0;
        }
    }
}
