using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MapleCheckSuro
{
    public partial class ChartForm : Form
    {
        private MainForm mainForm;

        public ChartForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadChart();
        }

        private void LoadChart()
        {
            // 차트 영역 생성
            ChartArea chartArea = new ChartArea();
            scoreChart.ChartAreas.Add(chartArea);

            // 팔레트 설정 (여기서는 'Bright' 팔레트를 사용)
            scoreChart.Palette = ChartColorPalette.Bright;

            // 시리즈 생성 및 데이터 추가
            Series series = new Series
            {
                Name = "SampleSeries",
                ChartType = SeriesChartType.Bar
            };
            series.Points.AddXY("Jan", 10);
            series.Points.AddXY("Feb", 20);
            series.Points.AddXY("Mar", 30);
            series.Points.AddXY("Apr", 40);
            series.Points.AddXY("May", 50);

            scoreChart.Series.Add(series);

        }
    }
}
