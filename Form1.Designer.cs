namespace Prog
{
    partial class Form1
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
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPeptideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.getInfoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(586, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.directTaskToolStripMenuItem,
            this.reverseTaskToolStripMenuItem,
            this.editPeptideToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // directTaskToolStripMenuItem
            // 
            this.directTaskToolStripMenuItem.Name = "directTaskToolStripMenuItem";
            this.directTaskToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.directTaskToolStripMenuItem.Text = "Open";
            this.directTaskToolStripMenuItem.Click += new System.EventHandler(this.directTaskToolStripMenuItem_Click);
            // 
            // reverseTaskToolStripMenuItem
            // 
            this.reverseTaskToolStripMenuItem.Name = "reverseTaskToolStripMenuItem";
            this.reverseTaskToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.reverseTaskToolStripMenuItem.Text = "Save";
            // 
            // editPeptideToolStripMenuItem
            // 
            this.editPeptideToolStripMenuItem.Name = "editPeptideToolStripMenuItem";
            this.editPeptideToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.editPeptideToolStripMenuItem.Text = "Edit peptide";
            this.editPeptideToolStripMenuItem.Click += new System.EventHandler(this.editPeptideToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // getInfoToolStripMenuItem
            // 
            this.getInfoToolStripMenuItem.Name = "getInfoToolStripMenuItem";
            this.getInfoToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.getInfoToolStripMenuItem.Text = "GetInfo";
            this.getInfoToolStripMenuItem.Click += new System.EventHandler(this.getInfoToolStripMenuItem_Click);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(12, 27);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(572, 394);
            this.cartesianChart1.TabIndex = 4;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 422);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "NCP Areal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reverseTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getInfoToolStripMenuItem;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.ToolStripMenuItem editPeptideToolStripMenuItem;
    }
}

