namespace FlashForgeMonitor
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
            this.statusLabel = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.extTempLabel = new System.Windows.Forms.Label();
            this.bedTempLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.machineTypeLabel = new System.Windows.Forms.Label();
            this.fwVersionLabel = new System.Windows.Forms.Label();
            this.snLabel = new System.Windows.Forms.Label();
            this.macLabel = new System.Windows.Forms.Label();
            this.toolsLabel = new System.Windows.Forms.Label();
            this.previewButton = new System.Windows.Forms.Button();
            this.liveStreamButton = new System.Windows.Forms.Button();
            this.sendFileButton = new System.Windows.Forms.Button();
            this.sendCmdButton = new System.Windows.Forms.Button();
            this.pausePrintButton = new System.Windows.Forms.Button();
            this.stopPrintButton = new System.Windows.Forms.Button();
            this.homeMaxButton = new System.Windows.Forms.Button();
            this.homeMinButton = new System.Windows.Forms.Button();
            this.ledStatusLabel = new System.Windows.Forms.Label();
            this.ledOffButton = new System.Windows.Forms.Button();
            this.ledOnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(155, 9);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(382, 32);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Status:";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressLabel
            // 
            this.progressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel.Location = new System.Drawing.Point(12, 83);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(377, 28);
            this.progressLabel.TabIndex = 1;
            this.progressLabel.Text = "Print Progress: ";
            // 
            // extTempLabel
            // 
            this.extTempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extTempLabel.Location = new System.Drawing.Point(12, 111);
            this.extTempLabel.Name = "extTempLabel";
            this.extTempLabel.Size = new System.Drawing.Size(377, 28);
            this.extTempLabel.TabIndex = 2;
            this.extTempLabel.Text = "Extruder Temp: ";
            // 
            // bedTempLabel
            // 
            this.bedTempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bedTempLabel.Location = new System.Drawing.Point(12, 139);
            this.bedTempLabel.Name = "bedTempLabel";
            this.bedTempLabel.Size = new System.Drawing.Size(377, 28);
            this.bedTempLabel.TabIndex = 3;
            this.bedTempLabel.Text = "Print Bed Temp:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(182, 44);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(337, 27);
            this.progressBar1.TabIndex = 4;
            // 
            // machineTypeLabel
            // 
            this.machineTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.machineTypeLabel.Location = new System.Drawing.Point(12, 186);
            this.machineTypeLabel.Name = "machineTypeLabel";
            this.machineTypeLabel.Size = new System.Drawing.Size(377, 28);
            this.machineTypeLabel.TabIndex = 5;
            this.machineTypeLabel.Text = "Machine:";
            // 
            // fwVersionLabel
            // 
            this.fwVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fwVersionLabel.Location = new System.Drawing.Point(12, 242);
            this.fwVersionLabel.Name = "fwVersionLabel";
            this.fwVersionLabel.Size = new System.Drawing.Size(377, 28);
            this.fwVersionLabel.TabIndex = 6;
            this.fwVersionLabel.Text = "Firmware Version:";
            // 
            // snLabel
            // 
            this.snLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snLabel.Location = new System.Drawing.Point(12, 214);
            this.snLabel.Name = "snLabel";
            this.snLabel.Size = new System.Drawing.Size(377, 28);
            this.snLabel.TabIndex = 7;
            this.snLabel.Text = "Serial Number:";
            // 
            // macLabel
            // 
            this.macLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macLabel.Location = new System.Drawing.Point(12, 270);
            this.macLabel.Name = "macLabel";
            this.macLabel.Size = new System.Drawing.Size(377, 28);
            this.macLabel.TabIndex = 8;
            this.macLabel.Text = "MAC Address:";
            // 
            // toolsLabel
            // 
            this.toolsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolsLabel.Location = new System.Drawing.Point(12, 298);
            this.toolsLabel.Name = "toolsLabel";
            this.toolsLabel.Size = new System.Drawing.Size(382, 28);
            this.toolsLabel.TabIndex = 9;
            this.toolsLabel.Text = "Tool Heads:";
            // 
            // previewButton
            // 
            this.previewButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewButton.Location = new System.Drawing.Point(397, 102);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(140, 37);
            this.previewButton.TabIndex = 10;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            // 
            // liveStreamButton
            // 
            this.liveStreamButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liveStreamButton.Location = new System.Drawing.Point(543, 102);
            this.liveStreamButton.Name = "liveStreamButton";
            this.liveStreamButton.Size = new System.Drawing.Size(140, 37);
            this.liveStreamButton.TabIndex = 11;
            this.liveStreamButton.Text = "Live Feed";
            this.liveStreamButton.UseVisualStyleBackColor = true;
            // 
            // sendFileButton
            // 
            this.sendFileButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendFileButton.Location = new System.Drawing.Point(543, 188);
            this.sendFileButton.Name = "sendFileButton";
            this.sendFileButton.Size = new System.Drawing.Size(140, 37);
            this.sendFileButton.TabIndex = 12;
            this.sendFileButton.Text = "Send GCode File";
            this.sendFileButton.UseVisualStyleBackColor = true;
            // 
            // sendCmdButton
            // 
            this.sendCmdButton.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendCmdButton.Location = new System.Drawing.Point(397, 188);
            this.sendCmdButton.Name = "sendCmdButton";
            this.sendCmdButton.Size = new System.Drawing.Size(140, 37);
            this.sendCmdButton.TabIndex = 13;
            this.sendCmdButton.Text = "Send GCode CMD";
            this.sendCmdButton.UseVisualStyleBackColor = true;
            // 
            // pausePrintButton
            // 
            this.pausePrintButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pausePrintButton.Location = new System.Drawing.Point(397, 145);
            this.pausePrintButton.Name = "pausePrintButton";
            this.pausePrintButton.Size = new System.Drawing.Size(140, 37);
            this.pausePrintButton.TabIndex = 14;
            this.pausePrintButton.Text = "Pause Print";
            this.pausePrintButton.UseVisualStyleBackColor = true;
            // 
            // stopPrintButton
            // 
            this.stopPrintButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopPrintButton.Location = new System.Drawing.Point(543, 145);
            this.stopPrintButton.Name = "stopPrintButton";
            this.stopPrintButton.Size = new System.Drawing.Size(140, 37);
            this.stopPrintButton.TabIndex = 15;
            this.stopPrintButton.Text = "Stop Print";
            this.stopPrintButton.UseVisualStyleBackColor = true;
            // 
            // homeMaxButton
            // 
            this.homeMaxButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeMaxButton.Location = new System.Drawing.Point(543, 231);
            this.homeMaxButton.Name = "homeMaxButton";
            this.homeMaxButton.Size = new System.Drawing.Size(140, 37);
            this.homeMaxButton.TabIndex = 16;
            this.homeMaxButton.Text = "Home to Max";
            this.homeMaxButton.UseVisualStyleBackColor = true;
            // 
            // homeMinButton
            // 
            this.homeMinButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeMinButton.Location = new System.Drawing.Point(397, 231);
            this.homeMinButton.Name = "homeMinButton";
            this.homeMinButton.Size = new System.Drawing.Size(140, 37);
            this.homeMinButton.TabIndex = 17;
            this.homeMinButton.Text = "Home to Min";
            this.homeMinButton.UseVisualStyleBackColor = true;
            // 
            // ledStatusLabel
            // 
            this.ledStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ledStatusLabel.Location = new System.Drawing.Point(12, 326);
            this.ledStatusLabel.Name = "ledStatusLabel";
            this.ledStatusLabel.Size = new System.Drawing.Size(382, 28);
            this.ledStatusLabel.TabIndex = 18;
            this.ledStatusLabel.Text = "Interior Light:";
            // 
            // ledOffButton
            // 
            this.ledOffButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ledOffButton.Location = new System.Drawing.Point(397, 274);
            this.ledOffButton.Name = "ledOffButton";
            this.ledOffButton.Size = new System.Drawing.Size(140, 37);
            this.ledOffButton.TabIndex = 19;
            this.ledOffButton.Text = "Interior Light OFF";
            this.ledOffButton.UseVisualStyleBackColor = true;
            this.ledOffButton.Click += new System.EventHandler(this.ledOffButton_Click);
            // 
            // ledOnButton
            // 
            this.ledOnButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ledOnButton.Location = new System.Drawing.Point(541, 274);
            this.ledOnButton.Name = "ledOnButton";
            this.ledOnButton.Size = new System.Drawing.Size(140, 37);
            this.ledOnButton.TabIndex = 20;
            this.ledOnButton.Text = "Interior Light ON";
            this.ledOnButton.UseVisualStyleBackColor = true;
            this.ledOnButton.Click += new System.EventHandler(this.ledOnButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 385);
            this.Controls.Add(this.ledOnButton);
            this.Controls.Add(this.ledOffButton);
            this.Controls.Add(this.ledStatusLabel);
            this.Controls.Add(this.homeMinButton);
            this.Controls.Add(this.homeMaxButton);
            this.Controls.Add(this.stopPrintButton);
            this.Controls.Add(this.pausePrintButton);
            this.Controls.Add(this.sendCmdButton);
            this.Controls.Add(this.sendFileButton);
            this.Controls.Add(this.liveStreamButton);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.toolsLabel);
            this.Controls.Add(this.macLabel);
            this.Controls.Add(this.snLabel);
            this.Controls.Add(this.fwVersionLabel);
            this.Controls.Add(this.machineTypeLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.bedTempLabel);
            this.Controls.Add(this.extTempLabel);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.statusLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label ledStatusLabel;
        private System.Windows.Forms.Button ledOffButton;
        private System.Windows.Forms.Button ledOnButton;

        private System.Windows.Forms.Button homeMaxButton;
        private System.Windows.Forms.Button homeMinButton;

        private System.Windows.Forms.Button sendCmdButton;
        private System.Windows.Forms.Button pausePrintButton;
        private System.Windows.Forms.Button sendFileButton;

        private System.Windows.Forms.Button liveStreamButton;
        private System.Windows.Forms.Button stopPrintButton;

        private System.Windows.Forms.Button previewButton;

        private System.Windows.Forms.Label toolsLabel;

        private System.Windows.Forms.Label snLabel;

        private System.Windows.Forms.Label fwVersionLabel;
        private System.Windows.Forms.Label macLabel;

        private System.Windows.Forms.Label bedTempLabel;
        private System.Windows.Forms.Label machineTypeLabel;
        private System.Windows.Forms.ProgressBar progressBar1;

        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label progressLabel;

        private System.Windows.Forms.Label extTempLabel;

        #endregion
    }
}