using System.ComponentModel;

namespace FlashForgeMonitor.ui
{
    partial class FanSpeedUI
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
            this.FanNameLabel = new System.Windows.Forms.Label();
            this.SpeedInputBox = new System.Windows.Forms.TextBox();
            this.SetSpeedButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FanNameLabel
            // 
            this.FanNameLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FanNameLabel.Location = new System.Drawing.Point(12, 9);
            this.FanNameLabel.Name = "FanNameLabel";
            this.FanNameLabel.Size = new System.Drawing.Size(211, 27);
            this.FanNameLabel.TabIndex = 3;
            this.FanNameLabel.Text = "Part Fan : 10%";
            this.FanNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SpeedInputBox
            // 
            this.SpeedInputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SpeedInputBox.Location = new System.Drawing.Point(9, 57);
            this.SpeedInputBox.Name = "SpeedInputBox";
            this.SpeedInputBox.Size = new System.Drawing.Size(118, 20);
            this.SpeedInputBox.TabIndex = 4;
            // 
            // SetSpeedButton
            // 
            this.SetSpeedButton.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetSpeedButton.Location = new System.Drawing.Point(146, 50);
            this.SetSpeedButton.Name = "SetSpeedButton";
            this.SetSpeedButton.Size = new System.Drawing.Size(76, 39);
            this.SetSpeedButton.TabIndex = 5;
            this.SetSpeedButton.Text = "Set";
            this.SetSpeedButton.UseVisualStyleBackColor = true;
            this.SetSpeedButton.Click += new System.EventHandler(this.SetSpeedButton_Click);
            // 
            // FanSpeedUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(235, 101);
            this.Controls.Add(this.SetSpeedButton);
            this.Controls.Add(this.SpeedInputBox);
            this.Controls.Add(this.FanNameLabel);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "FanSpeedUI";
            this.Load += new System.EventHandler(this.FanSpeedUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button SetSpeedButton;

        private System.Windows.Forms.TextBox SpeedInputBox;

        private System.Windows.Forms.Label FanNameLabel;

        #endregion
    }
}