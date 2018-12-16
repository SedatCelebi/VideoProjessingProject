namespace aforge2_deneme
{
    partial class AnaForm
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
            this.projelerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x3LedProjesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepMotorKontrolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servoMotorKontrolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projelerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(154, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // projelerToolStripMenuItem
            // 
            this.projelerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x3LedProjesiToolStripMenuItem,
            this.stepMotorKontrolToolStripMenuItem,
            this.servoMotorKontrolToolStripMenuItem});
            this.projelerToolStripMenuItem.Name = "projelerToolStripMenuItem";
            this.projelerToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.projelerToolStripMenuItem.Text = "Projeler";
            // 
            // x3LedProjesiToolStripMenuItem
            // 
            this.x3LedProjesiToolStripMenuItem.Name = "x3LedProjesiToolStripMenuItem";
            this.x3LedProjesiToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.x3LedProjesiToolStripMenuItem.Text = "3x3 Led Projesi";
            this.x3LedProjesiToolStripMenuItem.Click += new System.EventHandler(this.x3LedProjesiToolStripMenuItem_Click);
            // 
            // stepMotorKontrolToolStripMenuItem
            // 
            this.stepMotorKontrolToolStripMenuItem.Name = "stepMotorKontrolToolStripMenuItem";
            this.stepMotorKontrolToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.stepMotorKontrolToolStripMenuItem.Text = "Servo Motor Kontrol";
            this.stepMotorKontrolToolStripMenuItem.Click += new System.EventHandler(this.stepMotorKontrolToolStripMenuItem_Click);
            // 
            // servoMotorKontrolToolStripMenuItem
            // 
            this.servoMotorKontrolToolStripMenuItem.Name = "servoMotorKontrolToolStripMenuItem";
            this.servoMotorKontrolToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.servoMotorKontrolToolStripMenuItem.Text = "Step Motor Kontrol";
            this.servoMotorKontrolToolStripMenuItem.Click += new System.EventHandler(this.servoMotorKontrolToolStripMenuItem_Click);
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(154, 51);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnaForm";
            this.Text = "Ana Sayfa";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projelerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x3LedProjesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepMotorKontrolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servoMotorKontrolToolStripMenuItem;
    }
}