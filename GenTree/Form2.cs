using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenTree
{
    public partial class Form2 : Form
    {   
        public long[] chart_pop;
        public long[] chart_wyg;
        public Form2()
        {
            InitializeComponent();
        }
        public void PobierzDane(long[] pop, long[] licz_wyg)
        {
            this.chart_pop = pop;
            this.chart_wyg = licz_wyg;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void ChartPopulacja_Click(object sender, EventArgs e)
        {
            Wykres.Series.Clear();
            Wykres.Legends.Clear();
            Wykres.Series.Add("Populacja");
            for (int i = 0; i < this.chart_pop.Length; i++)
            {
                Wykres.Series[0].Points.AddXY(i, this.chart_pop[i]);
            }
            Wykres.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Wykres.Legends.Add("");
            
        }

        private void ChartGen_Click(object sender, EventArgs e)
        {
            Wykres.Series.Clear();
            Wykres.Legends.Clear();
            Wykres.Series.Add("Wygenerowano");
            for (int i = 0; i < this.chart_wyg.Length; i++)
            {
                Wykres.Series[0].Points.AddXY(i, this.chart_wyg[i]);
            }
            Wykres.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Wykres.Legends.Add("");
        }

        private void ChartGen1_Click(object sender, EventArgs e)
        {
            Wykres.Series.Clear();
            Wykres.Legends.Clear();
            Wykres.Series.Add("Wygenerowano");
            for (int i = 0; i < this.chart_wyg.Length; i++)
            {
                Wykres.Series[0].Points.AddXY(i, this.chart_wyg[i]);
            }
            Wykres.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Wykres.Series.Add("Maksymalnie");
            for (int i = 0; i < this.chart_wyg.Length; i++)
            {
                Wykres.Series[1].Points.AddXY(i, Math.Pow(2, i));
            }
            Wykres.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Wykres.Legends.Add("");
        }
    }
}
