namespace CarCrashing2
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
            this.lTitle = new System.Windows.Forms.Label();
            this.nrHeight = new System.Windows.Forms.NumericUpDown();
            this.nrWidth = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.nrHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.nrWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // lTitle
            // 
            this.lTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lTitle.Location = new System.Drawing.Point(94, 29);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(177, 38);
            this.lTitle.TabIndex = 0;
            this.lTitle.Text = "Car Crashing 2";
            this.lTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nrHeight
            // 
            this.nrHeight.Location = new System.Drawing.Point(144, 115);
            this.nrHeight.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.nrHeight.Minimum = new decimal(new int[] {3, 0, 0, 0});
            this.nrHeight.Name = "nrHeight";
            this.nrHeight.Size = new System.Drawing.Size(61, 20);
            this.nrHeight.TabIndex = 1;
            this.nrHeight.Value = new decimal(new int[] {3, 0, 0, 0});
            // 
            // nrWidth
            // 
            this.nrWidth.Location = new System.Drawing.Point(144, 141);
            this.nrWidth.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.nrWidth.Minimum = new decimal(new int[] {3, 0, 0, 0});
            this.nrWidth.Name = "nrWidth";
            this.nrWidth.Size = new System.Drawing.Size(61, 20);
            this.nrWidth.TabIndex = 2;
            this.nrWidth.Value = new decimal(new int[] {3, 0, 0, 0});
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnStart.Location = new System.Drawing.Point(119, 236);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(113, 47);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(61, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Height";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(61, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Width";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 347);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.nrWidth);
            this.Controls.Add(this.nrHeight);
            this.Controls.Add(this.lTitle);
            this.Name = "Form1";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize) (this.nrHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.nrWidth)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.NumericUpDown nrHeight;
        private System.Windows.Forms.NumericUpDown nrWidth;
        private System.Windows.Forms.Button btnStart;

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label lTitle;

        #endregion
    }
}