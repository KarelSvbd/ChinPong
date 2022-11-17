namespace BallColision
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLife = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 16;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblScore.Location = new System.Drawing.Point(659, 182);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(94, 80);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "15";
            // 
            // lblLife
            // 
            this.lblLife.AutoSize = true;
            this.lblLife.Font = new System.Drawing.Font("Impact", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblLife.Location = new System.Drawing.Point(659, 345);
            this.lblLife.Name = "lblLife";
            this.lblLife.Size = new System.Drawing.Size(69, 80);
            this.lblLife.TabIndex = 3;
            this.lblLife.Text = "3";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(659, 498);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Restart";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblHighScore
            // 
            this.lblHighScore.AutoSize = true;
            this.lblHighScore.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHighScore.Location = new System.Drawing.Point(665, 63);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(69, 80);
            this.lblHighScore.TabIndex = 5;
            this.lblHighScore.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 660);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblLife);
            this.Controls.Add(this.lblScore);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private Label lblScore;
        private Label lblLife;
        private Button btnReset;
        private Label lblHighScore;
    }
}