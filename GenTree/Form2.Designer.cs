
namespace GenTree
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.label1 = new System.Windows.Forms.Label();
            this.Wykres = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartPopulacja = new System.Windows.Forms.Button();
            this.ChartGen = new System.Windows.Forms.Button();
            this.ChartGen1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Wykres)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // Wykres
            // 
            chartArea1.AxisX.Title = "Pokolenie";
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 90F;
            chartArea1.Position.Width = 94F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 10F;
            this.Wykres.ChartAreas.Add(chartArea1);
            this.Wykres.Location = new System.Drawing.Point(177, 30);
            this.Wykres.Name = "Wykres";
            this.Wykres.Size = new System.Drawing.Size(595, 385);
            this.Wykres.TabIndex = 1;
            this.Wykres.Text = "chart1";
            // 
            // ChartPopulacja
            // 
            this.ChartPopulacja.Location = new System.Drawing.Point(13, 30);
            this.ChartPopulacja.Name = "ChartPopulacja";
            this.ChartPopulacja.Size = new System.Drawing.Size(132, 37);
            this.ChartPopulacja.TabIndex = 2;
            this.ChartPopulacja.Text = "Populacja";
            this.ChartPopulacja.UseVisualStyleBackColor = true;
            this.ChartPopulacja.Click += new System.EventHandler(this.ChartPopulacja_Click);
            // 
            // ChartGen
            // 
            this.ChartGen.Location = new System.Drawing.Point(13, 88);
            this.ChartGen.Name = "ChartGen";
            this.ChartGen.Size = new System.Drawing.Size(132, 64);
            this.ChartGen.TabIndex = 3;
            this.ChartGen.Text = "Liczba wygenerowanych osób";
            this.ChartGen.UseVisualStyleBackColor = true;
            this.ChartGen.Click += new System.EventHandler(this.ChartGen_Click);
            // 
            // ChartGen1
            // 
            this.ChartGen1.Location = new System.Drawing.Point(13, 174);
            this.ChartGen1.Name = "ChartGen1";
            this.ChartGen1.Size = new System.Drawing.Size(132, 60);
            this.ChartGen1.TabIndex = 4;
            this.ChartGen1.Text = "Liczba wygenerowanych osób + maks";
            this.ChartGen1.UseVisualStyleBackColor = true;
            this.ChartGen1.Click += new System.EventHandler(this.ChartGen1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChartGen1);
            this.Controls.Add(this.ChartGen);
            this.Controls.Add(this.ChartPopulacja);
            this.Controls.Add(this.Wykres);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Wykres";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Wykres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart Wykres;
        private System.Windows.Forms.Button ChartPopulacja;
        private System.Windows.Forms.Button ChartGen;
        private System.Windows.Forms.Button ChartGen1;
    }
}