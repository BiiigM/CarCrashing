using System.ComponentModel;

namespace CarCrashing2
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.containerControl1 = new System.Windows.Forms.ContainerControl();
            this.SuspendLayout();
            // 
            // containerControl1
            // 
            this.containerControl1.Enabled = false;
            this.containerControl1.Location = new System.Drawing.Point(240, 125);
            this.containerControl1.Name = "containerControl1";
            this.containerControl1.Size = new System.Drawing.Size(177, 156);
            this.containerControl1.TabIndex = 0;
            this.containerControl1.Text = "containerControl1";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.containerControl1);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ContainerControl containerControl1;

        #endregion
    }
}