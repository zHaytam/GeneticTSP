namespace GeneticTSP
{
    partial class MultiSolver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiSolver));
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbStarted = new System.Windows.Forms.ProgressBar();
            this.pbFinished = new System.Windows.Forms.ProgressBar();
            this.lblStarted = new System.Windows.Forms.Label();
            this.lblFinished = new System.Windows.Forms.Label();
            this.chartDistances = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(571, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Processing {0} runs of \'{1}\'";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbStarted
            // 
            this.pbStarted.Location = new System.Drawing.Point(16, 52);
            this.pbStarted.Name = "pbStarted";
            this.pbStarted.Size = new System.Drawing.Size(452, 23);
            this.pbStarted.TabIndex = 1;
            // 
            // pbFinished
            // 
            this.pbFinished.Location = new System.Drawing.Point(16, 81);
            this.pbFinished.Name = "pbFinished";
            this.pbFinished.Size = new System.Drawing.Size(452, 23);
            this.pbFinished.TabIndex = 2;
            // 
            // lblStarted
            // 
            this.lblStarted.AutoSize = true;
            this.lblStarted.Location = new System.Drawing.Point(474, 55);
            this.lblStarted.Name = "lblStarted";
            this.lblStarted.Size = new System.Drawing.Size(96, 17);
            this.lblStarted.TabIndex = 3;
            this.lblStarted.Text = "{0} / {1} started";
            // 
            // lblFinished
            // 
            this.lblFinished.AutoSize = true;
            this.lblFinished.Location = new System.Drawing.Point(474, 82);
            this.lblFinished.Name = "lblFinished";
            this.lblFinished.Size = new System.Drawing.Size(100, 17);
            this.lblFinished.TabIndex = 4;
            this.lblFinished.Text = "{0} / {1} finished";
            // 
            // chartDistances
            // 
            this.chartDistances.Location = new System.Drawing.Point(16, 119);
            this.chartDistances.Name = "chartDistances";
            this.chartDistances.Size = new System.Drawing.Size(567, 329);
            this.chartDistances.TabIndex = 5;
            this.chartDistances.Text = "cartesianChart1";
            // 
            // MultiSolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 460);
            this.Controls.Add(this.chartDistances);
            this.Controls.Add(this.lblFinished);
            this.Controls.Add(this.lblStarted);
            this.Controls.Add(this.pbFinished);
            this.Controls.Add(this.pbStarted);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MultiSolver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TSP Solver (GA) - Multi Solver";
            this.Shown += new System.EventHandler(this.MultiSolver_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ProgressBar pbStarted;
        private System.Windows.Forms.ProgressBar pbFinished;
        private System.Windows.Forms.Label lblStarted;
        private System.Windows.Forms.Label lblFinished;
        private LiveCharts.WinForms.CartesianChart chartDistances;
    }
}