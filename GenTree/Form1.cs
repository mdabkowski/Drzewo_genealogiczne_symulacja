using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace GenTree
{
    public partial class GenTree : Form
    {
        readonly int promien = 5;
        Bitmap Obraz;
        Graphics grf;
        Zbior zbior;
        public GenTree()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PlotButton.Enabled = false;
            label8.Text = ScrollChance.Value + "%";
            Label_ilgen.Text = "";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double przodkowie = 0;
            int counter = 0;
            while(counter < numericUpDown1.Value)
            {
                przodkowie = Math.Pow(2, decimal.ToDouble(numericUpDown1.Value+1))-2;
                counter++;
            }
            label2.Text = "" + przodkowie;
            label5.Text = "" + Math.Pow(2, decimal.ToDouble(numericUpDown1.Value));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.zbior = new Zbior(numericUpDown1.Value, (int)ScrollChance.Value);
            Obraz = new Bitmap(445, 425);
            PictureBox1.Image = Obraz;
            grf = Graphics.FromImage(Obraz);
            grf.Clear(Color.Black);
            Wizualizuj(zbior);
            PictureBox1.Refresh();
            PlotButton.Enabled = true;
            Label_ilgen.Text = "" + zbior.Liczgen();
        }
        void Wizualizuj(Zbior zbior)
        {
            if (numericUpDown1.Value < 17)
            {
                for (int i = 0; i <= numericUpDown1.Value; i++)
                {
                    for (int j = 0; j < zbior.pokolenie[i].lista_pok.Count; j++)
                    {
                        grf.DrawLine(Pens.Red, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_x() + promien / 2, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_y() + promien / 2, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_m_x() + promien / 2, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_m_y() + promien / 2);
                        grf.DrawLine(Pens.Blue, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_x() + promien / 2, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_y() + promien / 2, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_o_x() + promien / 2, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_o_y() + promien / 2);
                        grf.FillEllipse(Brushes.Cyan, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_x(), (float)zbior.pokolenie[i].lista_pok[j].Zwroc_y(), promien, promien);
                        grf.DrawEllipse(Pens.AliceBlue, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_x(), (float)zbior.pokolenie[i].lista_pok[j].Zwroc_y(), promien, promien);
                    }

                }
            }
            else
            {
                for (int i = 0; i <= 17; i++)
                {
                    for (int j = 0; j < zbior.pokolenie[i].lista_pok.Count; j++)
                    {
                        grf.DrawLine(Pens.Red, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_x() + promien / 2, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_y() + promien / 2, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_m_x() + promien / 2, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_m_y() + promien / 2);
                        grf.DrawLine(Pens.Blue, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_x() + promien / 2, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_y() + promien / 2, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_o_x() + promien / 2, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_o_y() + promien / 2);
                        grf.FillEllipse(Brushes.Cyan, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_x(), (float)zbior.pokolenie[i].lista_pok[j].Zwroc_y(), promien, promien);
                        grf.DrawEllipse(Pens.AliceBlue, (float)zbior.pokolenie[i].lista_pok[j].Zwroc_x(), (float)zbior.pokolenie[i].lista_pok[j].Zwroc_y(), promien, promien);
                    }
                }
            }
        }

        private void PlotButton_Click(object sender, EventArgs e)
        {
            long[] liczba_wyg = new long[this.zbior.pokolenie.Count];
            for (int i = 0; i < this.zbior.pokolenie.Count; i++)
            {
                liczba_wyg[i] = this.zbior.pokolenie[i].lista_pok.Count;
            }
            var form2 = new Form2();
            form2.PobierzDane(this.zbior.max_populacja, liczba_wyg);
            form2.FormClosed += form2_FormClosed;
            form2.Show();
            PlotButton.Enabled = false; 
        }
        private void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            PlotButton.Enabled = true;
        }

        private void ScrollChance_Scroll(object sender, ScrollEventArgs e)
        {
            label8.Text = ScrollChance.Value + "%";
        }
    }
}
