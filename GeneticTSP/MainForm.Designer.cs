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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TsmiLoadProblems = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiSelectProblem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiLoadProblems,
            this.TsmiSelectProblem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(937, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TsmiLoadProblems
            // 
            this.TsmiLoadProblems.Name = "TsmiLoadProblems";
            this.TsmiLoadProblems.Size = new System.Drawing.Size(121, 20);
            this.TsmiLoadProblems.Text = "Load TSP problems";
            this.TsmiLoadProblems.Click += new System.EventHandler(this.TsmiLoadProblems_Click);
            // 
            // TsmiSelectProblem
            // 
            this.TsmiSelectProblem.Enabled = false;
            this.TsmiSelectProblem.Name = "TsmiSelectProblem";
            this.TsmiSelectProblem.Size = new System.Drawing.Size(107, 20);
            this.TsmiSelectProblem.Text = "Select a problem";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 656);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
    }
}

