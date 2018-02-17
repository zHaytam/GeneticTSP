namespace GeneticTSP
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TsmiLoadProblems = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiSelectProblem = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiStartSolving = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiStopSolving = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiLoadProblems,
            this.TsmiSelectProblem,
            this.TsmiStartSolving,
            this.TsmiStopSolving,
            this.TsmiProperties});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(895, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TsmiLoadProblems
            // 
            this.TsmiLoadProblems.Image = global::GeneticTSP.Properties.Resources.folder_24;
            this.TsmiLoadProblems.Name = "TsmiLoadProblems";
            this.TsmiLoadProblems.Size = new System.Drawing.Size(150, 21);
            this.TsmiLoadProblems.Text = "Load TSP problems";
            this.TsmiLoadProblems.Click += new System.EventHandler(this.TsmiLoadProblems_Click);
            // 
            // TsmiSelectProblem
            // 
            this.TsmiSelectProblem.Enabled = false;
            this.TsmiSelectProblem.Image = global::GeneticTSP.Properties.Resources.arrow_down_01_24;
            this.TsmiSelectProblem.Name = "TsmiSelectProblem";
            this.TsmiSelectProblem.Size = new System.Drawing.Size(135, 21);
            this.TsmiSelectProblem.Text = "Select a problem";
            // 
            // TsmiStartSolving
            // 
            this.TsmiStartSolving.Enabled = false;
            this.TsmiStartSolving.Image = global::GeneticTSP.Properties.Resources.stopwatch_start16;
            this.TsmiStartSolving.Name = "TsmiStartSolving";
            this.TsmiStartSolving.Size = new System.Drawing.Size(63, 21);
            this.TsmiStartSolving.Text = "Start";
            this.TsmiStartSolving.Click += new System.EventHandler(this.TsmiStartSolving_Click);
            // 
            // TsmiStopSolving
            // 
            this.TsmiStopSolving.Enabled = false;
            this.TsmiStopSolving.Image = global::GeneticTSP.Properties.Resources.stopwatch_finish16;
            this.TsmiStopSolving.Name = "TsmiStopSolving";
            this.TsmiStopSolving.Size = new System.Drawing.Size(63, 21);
            this.TsmiStopSolving.Text = "Stop";
            this.TsmiStopSolving.Click += new System.EventHandler(this.TsmiStopSolving_Click);
            // 
            // TsmiProperties
            // 
            this.TsmiProperties.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TsmiProperties.Image = global::GeneticTSP.Properties.Resources.package_settings24;
            this.TsmiProperties.Name = "TsmiProperties";
            this.TsmiProperties.Size = new System.Drawing.Size(96, 21);
            this.TsmiProperties.Text = "Properties";
            this.TsmiProperties.Click += new System.EventHandler(this.TsmiProperties_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 627);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TSP Solver (GA)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TsmiLoadProblems;
        private System.Windows.Forms.ToolStripMenuItem TsmiSelectProblem;
        private System.Windows.Forms.ToolStripMenuItem TsmiProperties;
        private System.Windows.Forms.ToolStripMenuItem TsmiStartSolving;
        private System.Windows.Forms.ToolStripMenuItem TsmiStopSolving;
    }
}

