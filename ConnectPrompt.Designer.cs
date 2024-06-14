using System.ComponentModel;

namespace FlashForgeMonitor
{
    partial class ConnectPrompt
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
            this.ipInput = new System.Windows.Forms.TextBox();
            this.topLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ipInput
            // 
            this.ipInput.Location = new System.Drawing.Point(45, 41);
            this.ipInput.Name = "ipInput";
            this.ipInput.Size = new System.Drawing.Size(256, 20);
            this.ipInput.TabIndex = 0;
            this.ipInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // topLabel
            // 
            this.topLabel.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLabel.Location = new System.Drawing.Point(45, 9);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(256, 23);
            this.topLabel.TabIndex = 1;
            this.topLabel.Text = "Enter Printer IP";
            this.topLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // connectButton
            // 
            this.connectButton.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton.Location = new System.Drawing.Point(101, 67);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(135, 34);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            // 
            // ConnectPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(343, 111);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.topLabel);
            this.Controls.Add(this.ipInput);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "ConnectPrompt";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button connectButton;


        private System.Windows.Forms.Label topLabel;
        private System.Windows.Forms.TextBox ipInput;

        #endregion
    }
}