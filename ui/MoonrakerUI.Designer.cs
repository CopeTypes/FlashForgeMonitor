using System.ComponentModel;

namespace FlashForgeMonitor.ui
{
    partial class MoonrakerUI
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
            this.ProgressPanel = new System.Windows.Forms.Panel();
            this.FilamentUsedLabel = new System.Windows.Forms.Label();
            this.PrintProgressLabel = new System.Windows.Forms.Label();
            this.PrintProgressBar = new System.Windows.Forms.ProgressBar();
            this.PrintTimeLabel = new System.Windows.Forms.Label();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.SensorPanel = new System.Windows.Forms.Panel();
            this.TvocLabel = new System.Windows.Forms.Label();
            this.LoadCellLabel = new System.Windows.Forms.Label();
            this.ControllerFanLabel = new System.Windows.Forms.Label();
            this.ExternalFanLabel = new System.Windows.Forms.Label();
            this.InternalFanLabel = new System.Windows.Forms.Label();
            this.ChamberFanLabel = new System.Windows.Forms.Label();
            this.PartFanLabel = new System.Windows.Forms.Label();
            this.StatusPanel = new System.Windows.Forms.Panel();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.HostNameLabel = new System.Windows.Forms.Label();
            this.TempsPanel = new System.Windows.Forms.Panel();
            this.BedTempLabel = new System.Windows.Forms.Label();
            this.ExtruderTempLabel = new System.Windows.Forms.Label();
            this.EstopButton = new System.Windows.Forms.Button();
            this.ShutdownMachineButton = new System.Windows.Forms.Button();
            this.RebootMachineButton = new System.Windows.Forms.Button();
            this.RebootServerButton = new System.Windows.Forms.Button();
            this.RebootHostButton = new System.Windows.Forms.Button();
            this.RebootFwButton = new System.Windows.Forms.Button();
            this.ResumePrintButton = new System.Windows.Forms.Button();
            this.CancelPrintButton = new System.Windows.Forms.Button();
            this.PausePrintButton = new System.Windows.Forms.Button();
            this.HomeAxesButton = new System.Windows.Forms.Button();
            this.MotorsOffButton = new System.Windows.Forms.Button();
            this.LcdOffButton = new System.Windows.Forms.Button();
            this.LcdOnButton = new System.Windows.Forms.Button();
            this.RebootStockButton = new System.Windows.Forms.Button();
            this.QuickBedLevelButton = new System.Windows.Forms.Button();
            this.BedLevelButton = new System.Windows.Forms.Button();
            this.InternalFilteringButton = new System.Windows.Forms.Button();
            this.ExternalFilteringButton = new System.Windows.Forms.Button();
            this.FilteringOffButton = new System.Windows.Forms.Button();
            this.PrintFileButton = new System.Windows.Forms.Button();
            this.OpenTerminalButton = new System.Windows.Forms.Button();
            this.PrintPreviewButton = new System.Windows.Forms.Button();
            this.ViewWebcamButton = new System.Windows.Forms.Button();
            this.FilteringPanel = new System.Windows.Forms.Panel();
            this.ProgressPanel.SuspendLayout();
            this.SensorPanel.SuspendLayout();
            this.StatusPanel.SuspendLayout();
            this.TempsPanel.SuspendLayout();
            this.FilteringPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgressPanel
            // 
            this.ProgressPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProgressPanel.Controls.Add(this.FilamentUsedLabel);
            this.ProgressPanel.Controls.Add(this.PrintProgressLabel);
            this.ProgressPanel.Controls.Add(this.PrintProgressBar);
            this.ProgressPanel.Controls.Add(this.PrintTimeLabel);
            this.ProgressPanel.Controls.Add(this.FileNameLabel);
            this.ProgressPanel.Location = new System.Drawing.Point(21, 133);
            this.ProgressPanel.Name = "ProgressPanel";
            this.ProgressPanel.Size = new System.Drawing.Size(317, 175);
            this.ProgressPanel.TabIndex = 0;
            // 
            // FilamentUsedLabel
            // 
            this.FilamentUsedLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilamentUsedLabel.Location = new System.Drawing.Point(15, 76);
            this.FilamentUsedLabel.Name = "FilamentUsedLabel";
            this.FilamentUsedLabel.Size = new System.Drawing.Size(285, 27);
            this.FilamentUsedLabel.TabIndex = 4;
            this.FilamentUsedLabel.Text = "Filament Used: 0.123mm";
            this.FilamentUsedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrintProgressLabel
            // 
            this.PrintProgressLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintProgressLabel.Location = new System.Drawing.Point(168, 103);
            this.PrintProgressLabel.Name = "PrintProgressLabel";
            this.PrintProgressLabel.Size = new System.Drawing.Size(132, 27);
            this.PrintProgressLabel.TabIndex = 3;
            this.PrintProgressLabel.Text = "Progress: 36%";
            this.PrintProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PrintProgressBar
            // 
            this.PrintProgressBar.Location = new System.Drawing.Point(14, 142);
            this.PrintProgressBar.Name = "PrintProgressBar";
            this.PrintProgressBar.Size = new System.Drawing.Size(285, 19);
            this.PrintProgressBar.TabIndex = 2;
            // 
            // PrintTimeLabel
            // 
            this.PrintTimeLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintTimeLabel.Location = new System.Drawing.Point(14, 103);
            this.PrintTimeLabel.Name = "PrintTimeLabel";
            this.PrintTimeLabel.Size = new System.Drawing.Size(159, 27);
            this.PrintTimeLabel.TabIndex = 1;
            this.PrintTimeLabel.Text = "Print Time: 1h34m";
            this.PrintTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLabel.Location = new System.Drawing.Point(11, 18);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(289, 58);
            this.FileNameLabel.TabIndex = 0;
            this.FileNameLabel.Text = "Current file: ";
            this.FileNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SensorPanel
            // 
            this.SensorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SensorPanel.Controls.Add(this.TvocLabel);
            this.SensorPanel.Controls.Add(this.LoadCellLabel);
            this.SensorPanel.Controls.Add(this.ControllerFanLabel);
            this.SensorPanel.Controls.Add(this.ExternalFanLabel);
            this.SensorPanel.Controls.Add(this.InternalFanLabel);
            this.SensorPanel.Controls.Add(this.ChamberFanLabel);
            this.SensorPanel.Controls.Add(this.PartFanLabel);
            this.SensorPanel.Location = new System.Drawing.Point(22, 428);
            this.SensorPanel.Name = "SensorPanel";
            this.SensorPanel.Size = new System.Drawing.Size(317, 166);
            this.SensorPanel.TabIndex = 1;
            // 
            // TvocLabel
            // 
            this.TvocLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TvocLabel.Location = new System.Drawing.Point(172, 82);
            this.TvocLabel.Name = "TvocLabel";
            this.TvocLabel.Size = new System.Drawing.Size(128, 27);
            this.TvocLabel.TabIndex = 8;
            this.TvocLabel.Text = "TVOC: 1234";
            this.TvocLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoadCellLabel
            // 
            this.LoadCellLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadCellLabel.Location = new System.Drawing.Point(172, 55);
            this.LoadCellLabel.Name = "LoadCellLabel";
            this.LoadCellLabel.Size = new System.Drawing.Size(128, 27);
            this.LoadCellLabel.TabIndex = 7;
            this.LoadCellLabel.Text = "Load Cell: 1000";
            this.LoadCellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ControllerFanLabel
            // 
            this.ControllerFanLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControllerFanLabel.Location = new System.Drawing.Point(11, 120);
            this.ControllerFanLabel.Name = "ControllerFanLabel";
            this.ControllerFanLabel.Size = new System.Drawing.Size(174, 27);
            this.ControllerFanLabel.TabIndex = 6;
            this.ControllerFanLabel.Text = "Controller Fan: 100%";
            this.ControllerFanLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExternalFanLabel
            // 
            this.ExternalFanLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExternalFanLabel.Location = new System.Drawing.Point(11, 93);
            this.ExternalFanLabel.Name = "ExternalFanLabel";
            this.ExternalFanLabel.Size = new System.Drawing.Size(159, 27);
            this.ExternalFanLabel.TabIndex = 5;
            this.ExternalFanLabel.Text = "External Fan: 55%";
            this.ExternalFanLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InternalFanLabel
            // 
            this.InternalFanLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InternalFanLabel.Location = new System.Drawing.Point(11, 66);
            this.InternalFanLabel.Name = "InternalFanLabel";
            this.InternalFanLabel.Size = new System.Drawing.Size(159, 27);
            this.InternalFanLabel.TabIndex = 4;
            this.InternalFanLabel.Text = "Internal Fan: 80%";
            this.InternalFanLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChamberFanLabel
            // 
            this.ChamberFanLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChamberFanLabel.Location = new System.Drawing.Point(11, 39);
            this.ChamberFanLabel.Name = "ChamberFanLabel";
            this.ChamberFanLabel.Size = new System.Drawing.Size(169, 27);
            this.ChamberFanLabel.TabIndex = 3;
            this.ChamberFanLabel.Text = "Chamber Fan: 80%";
            this.ChamberFanLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PartFanLabel
            // 
            this.PartFanLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartFanLabel.Location = new System.Drawing.Point(11, 12);
            this.PartFanLabel.Name = "PartFanLabel";
            this.PartFanLabel.Size = new System.Drawing.Size(128, 27);
            this.PartFanLabel.TabIndex = 2;
            this.PartFanLabel.Text = "Part Fan: 50%";
            this.PartFanLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PartFanLabel.Click += new System.EventHandler(this.PartFanLabel_Click);
            // 
            // StatusPanel
            // 
            this.StatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusPanel.Controls.Add(this.StatusLabel);
            this.StatusPanel.Controls.Add(this.HostNameLabel);
            this.StatusPanel.Location = new System.Drawing.Point(21, 15);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(316, 101);
            this.StatusPanel.TabIndex = 2;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(15, 58);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(274, 27);
            this.StatusLabel.TabIndex = 3;
            this.StatusLabel.Text = "Status: Idk";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HostNameLabel
            // 
            this.HostNameLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostNameLabel.Location = new System.Drawing.Point(15, 21);
            this.HostNameLabel.Name = "HostNameLabel";
            this.HostNameLabel.Size = new System.Drawing.Size(274, 27);
            this.HostNameLabel.TabIndex = 2;
            this.HostNameLabel.Text = "HostName";
            this.HostNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TempsPanel
            // 
            this.TempsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TempsPanel.Controls.Add(this.BedTempLabel);
            this.TempsPanel.Controls.Add(this.ExtruderTempLabel);
            this.TempsPanel.Location = new System.Drawing.Point(22, 323);
            this.TempsPanel.Name = "TempsPanel";
            this.TempsPanel.Size = new System.Drawing.Size(316, 82);
            this.TempsPanel.TabIndex = 3;
            // 
            // BedTempLabel
            // 
            this.BedTempLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BedTempLabel.Location = new System.Drawing.Point(154, 26);
            this.BedTempLabel.Name = "BedTempLabel";
            this.BedTempLabel.Size = new System.Drawing.Size(145, 27);
            this.BedTempLabel.TabIndex = 4;
            this.BedTempLabel.Text = "Print Bed: 49/50C";
            this.BedTempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExtruderTempLabel
            // 
            this.ExtruderTempLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtruderTempLabel.Location = new System.Drawing.Point(10, 12);
            this.ExtruderTempLabel.Name = "ExtruderTempLabel";
            this.ExtruderTempLabel.Size = new System.Drawing.Size(144, 54);
            this.ExtruderTempLabel.TabIndex = 3;
            this.ExtruderTempLabel.Text = "Extruder: 123/156C";
            this.ExtruderTempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EstopButton
            // 
            this.EstopButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EstopButton.Location = new System.Drawing.Point(357, 15);
            this.EstopButton.Name = "EstopButton";
            this.EstopButton.Size = new System.Drawing.Size(156, 34);
            this.EstopButton.TabIndex = 4;
            this.EstopButton.Text = "Emergency Stop";
            this.EstopButton.UseVisualStyleBackColor = true;
            // 
            // ShutdownMachineButton
            // 
            this.ShutdownMachineButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShutdownMachineButton.Location = new System.Drawing.Point(519, 15);
            this.ShutdownMachineButton.Name = "ShutdownMachineButton";
            this.ShutdownMachineButton.Size = new System.Drawing.Size(156, 34);
            this.ShutdownMachineButton.TabIndex = 5;
            this.ShutdownMachineButton.Text = "Shutdown Machine";
            this.ShutdownMachineButton.UseVisualStyleBackColor = true;
            // 
            // RebootMachineButton
            // 
            this.RebootMachineButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RebootMachineButton.Location = new System.Drawing.Point(357, 256);
            this.RebootMachineButton.Name = "RebootMachineButton";
            this.RebootMachineButton.Size = new System.Drawing.Size(156, 34);
            this.RebootMachineButton.TabIndex = 6;
            this.RebootMachineButton.Text = "Reboot Machine";
            this.RebootMachineButton.UseVisualStyleBackColor = true;
            // 
            // RebootServerButton
            // 
            this.RebootServerButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RebootServerButton.Location = new System.Drawing.Point(357, 296);
            this.RebootServerButton.Name = "RebootServerButton";
            this.RebootServerButton.Size = new System.Drawing.Size(156, 34);
            this.RebootServerButton.TabIndex = 7;
            this.RebootServerButton.Text = "Reboot Server";
            this.RebootServerButton.UseVisualStyleBackColor = true;
            // 
            // RebootHostButton
            // 
            this.RebootHostButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RebootHostButton.Location = new System.Drawing.Point(519, 296);
            this.RebootHostButton.Name = "RebootHostButton";
            this.RebootHostButton.Size = new System.Drawing.Size(156, 34);
            this.RebootHostButton.TabIndex = 8;
            this.RebootHostButton.Text = "Reboot Host";
            this.RebootHostButton.UseVisualStyleBackColor = true;
            // 
            // RebootFwButton
            // 
            this.RebootFwButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RebootFwButton.Location = new System.Drawing.Point(519, 256);
            this.RebootFwButton.Name = "RebootFwButton";
            this.RebootFwButton.Size = new System.Drawing.Size(156, 34);
            this.RebootFwButton.TabIndex = 9;
            this.RebootFwButton.Text = "Reboot Firmware";
            this.RebootFwButton.UseVisualStyleBackColor = true;
            // 
            // ResumePrintButton
            // 
            this.ResumePrintButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResumePrintButton.Location = new System.Drawing.Point(519, 55);
            this.ResumePrintButton.Name = "ResumePrintButton";
            this.ResumePrintButton.Size = new System.Drawing.Size(156, 34);
            this.ResumePrintButton.TabIndex = 11;
            this.ResumePrintButton.Text = "Resume Print";
            this.ResumePrintButton.UseVisualStyleBackColor = true;
            // 
            // CancelPrintButton
            // 
            this.CancelPrintButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelPrintButton.Location = new System.Drawing.Point(519, 95);
            this.CancelPrintButton.Name = "CancelPrintButton";
            this.CancelPrintButton.Size = new System.Drawing.Size(156, 34);
            this.CancelPrintButton.TabIndex = 12;
            this.CancelPrintButton.Text = "Cancel Print";
            this.CancelPrintButton.UseVisualStyleBackColor = true;
            // 
            // PausePrintButton
            // 
            this.PausePrintButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PausePrintButton.Location = new System.Drawing.Point(357, 55);
            this.PausePrintButton.Name = "PausePrintButton";
            this.PausePrintButton.Size = new System.Drawing.Size(156, 34);
            this.PausePrintButton.TabIndex = 13;
            this.PausePrintButton.Text = "Pause Print";
            this.PausePrintButton.UseVisualStyleBackColor = true;
            // 
            // HomeAxesButton
            // 
            this.HomeAxesButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeAxesButton.Location = new System.Drawing.Point(357, 176);
            this.HomeAxesButton.Name = "HomeAxesButton";
            this.HomeAxesButton.Size = new System.Drawing.Size(156, 34);
            this.HomeAxesButton.TabIndex = 14;
            this.HomeAxesButton.Text = "Home Axes";
            this.HomeAxesButton.UseVisualStyleBackColor = true;
            // 
            // MotorsOffButton
            // 
            this.MotorsOffButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MotorsOffButton.Location = new System.Drawing.Point(519, 176);
            this.MotorsOffButton.Name = "MotorsOffButton";
            this.MotorsOffButton.Size = new System.Drawing.Size(156, 34);
            this.MotorsOffButton.TabIndex = 15;
            this.MotorsOffButton.Text = "Turn Motors Off";
            this.MotorsOffButton.UseVisualStyleBackColor = true;
            // 
            // LcdOffButton
            // 
            this.LcdOffButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LcdOffButton.Location = new System.Drawing.Point(357, 376);
            this.LcdOffButton.Name = "LcdOffButton";
            this.LcdOffButton.Size = new System.Drawing.Size(156, 34);
            this.LcdOffButton.TabIndex = 16;
            this.LcdOffButton.Text = "Turn LCD Off";
            this.LcdOffButton.UseVisualStyleBackColor = true;
            // 
            // LcdOnButton
            // 
            this.LcdOnButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LcdOnButton.Location = new System.Drawing.Point(519, 376);
            this.LcdOnButton.Name = "LcdOnButton";
            this.LcdOnButton.Size = new System.Drawing.Size(156, 34);
            this.LcdOnButton.TabIndex = 17;
            this.LcdOnButton.Text = "Turn LCD On";
            this.LcdOnButton.UseVisualStyleBackColor = true;
            // 
            // RebootStockButton
            // 
            this.RebootStockButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RebootStockButton.Location = new System.Drawing.Point(357, 336);
            this.RebootStockButton.Name = "RebootStockButton";
            this.RebootStockButton.Size = new System.Drawing.Size(156, 34);
            this.RebootStockButton.TabIndex = 18;
            this.RebootStockButton.Text = "Reboot Stock\r\n";
            this.RebootStockButton.UseVisualStyleBackColor = true;
            // 
            // QuickBedLevelButton
            // 
            this.QuickBedLevelButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuickBedLevelButton.Location = new System.Drawing.Point(357, 216);
            this.QuickBedLevelButton.Name = "QuickBedLevelButton";
            this.QuickBedLevelButton.Size = new System.Drawing.Size(156, 34);
            this.QuickBedLevelButton.TabIndex = 19;
            this.QuickBedLevelButton.Text = "Quick Bed Level";
            this.QuickBedLevelButton.UseVisualStyleBackColor = true;
            // 
            // BedLevelButton
            // 
            this.BedLevelButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BedLevelButton.Location = new System.Drawing.Point(519, 216);
            this.BedLevelButton.Name = "BedLevelButton";
            this.BedLevelButton.Size = new System.Drawing.Size(156, 34);
            this.BedLevelButton.TabIndex = 20;
            this.BedLevelButton.Text = "Full Bed Level";
            this.BedLevelButton.UseVisualStyleBackColor = true;
            // 
            // InternalFilteringButton
            // 
            this.InternalFilteringButton.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InternalFilteringButton.Location = new System.Drawing.Point(14, 10);
            this.InternalFilteringButton.Name = "InternalFilteringButton";
            this.InternalFilteringButton.Size = new System.Drawing.Size(156, 34);
            this.InternalFilteringButton.TabIndex = 21;
            this.InternalFilteringButton.Text = "Internal Filtering On";
            this.InternalFilteringButton.UseVisualStyleBackColor = true;
            // 
            // ExternalFilteringButton
            // 
            this.ExternalFilteringButton.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExternalFilteringButton.Location = new System.Drawing.Point(14, 59);
            this.ExternalFilteringButton.Name = "ExternalFilteringButton";
            this.ExternalFilteringButton.Size = new System.Drawing.Size(156, 34);
            this.ExternalFilteringButton.TabIndex = 22;
            this.ExternalFilteringButton.Text = "External Filtering On";
            this.ExternalFilteringButton.UseVisualStyleBackColor = true;
            // 
            // FilteringOffButton
            // 
            this.FilteringOffButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilteringOffButton.Location = new System.Drawing.Point(14, 113);
            this.FilteringOffButton.Name = "FilteringOffButton";
            this.FilteringOffButton.Size = new System.Drawing.Size(156, 34);
            this.FilteringOffButton.TabIndex = 23;
            this.FilteringOffButton.Text = "Turn Filtering Off";
            this.FilteringOffButton.UseVisualStyleBackColor = true;
            // 
            // PrintFileButton
            // 
            this.PrintFileButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintFileButton.Location = new System.Drawing.Point(357, 95);
            this.PrintFileButton.Name = "PrintFileButton";
            this.PrintFileButton.Size = new System.Drawing.Size(156, 34);
            this.PrintFileButton.TabIndex = 24;
            this.PrintFileButton.Text = "Print GCode File";
            this.PrintFileButton.UseVisualStyleBackColor = true;
            // 
            // OpenTerminalButton
            // 
            this.OpenTerminalButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenTerminalButton.Location = new System.Drawing.Point(519, 336);
            this.OpenTerminalButton.Name = "OpenTerminalButton";
            this.OpenTerminalButton.Size = new System.Drawing.Size(156, 34);
            this.OpenTerminalButton.TabIndex = 25;
            this.OpenTerminalButton.Text = "Open Terminal";
            this.OpenTerminalButton.UseVisualStyleBackColor = true;
            // 
            // PrintPreviewButton
            // 
            this.PrintPreviewButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintPreviewButton.Location = new System.Drawing.Point(357, 135);
            this.PrintPreviewButton.Name = "PrintPreviewButton";
            this.PrintPreviewButton.Size = new System.Drawing.Size(156, 34);
            this.PrintPreviewButton.TabIndex = 26;
            this.PrintPreviewButton.Text = "Print Preview";
            this.PrintPreviewButton.UseVisualStyleBackColor = true;
            // 
            // ViewWebcamButton
            // 
            this.ViewWebcamButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewWebcamButton.Location = new System.Drawing.Point(519, 135);
            this.ViewWebcamButton.Name = "ViewWebcamButton";
            this.ViewWebcamButton.Size = new System.Drawing.Size(156, 34);
            this.ViewWebcamButton.TabIndex = 27;
            this.ViewWebcamButton.Text = "View Webcam";
            this.ViewWebcamButton.UseVisualStyleBackColor = true;
            // 
            // FilteringPanel
            // 
            this.FilteringPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilteringPanel.Controls.Add(this.InternalFilteringButton);
            this.FilteringPanel.Controls.Add(this.ExternalFilteringButton);
            this.FilteringPanel.Controls.Add(this.FilteringOffButton);
            this.FilteringPanel.Location = new System.Drawing.Point(365, 428);
            this.FilteringPanel.Name = "FilteringPanel";
            this.FilteringPanel.Size = new System.Drawing.Size(186, 165);
            this.FilteringPanel.TabIndex = 28;
            // 
            // MoonrakerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 617);
            this.Controls.Add(this.FilteringPanel);
            this.Controls.Add(this.ViewWebcamButton);
            this.Controls.Add(this.PrintPreviewButton);
            this.Controls.Add(this.OpenTerminalButton);
            this.Controls.Add(this.PrintFileButton);
            this.Controls.Add(this.BedLevelButton);
            this.Controls.Add(this.QuickBedLevelButton);
            this.Controls.Add(this.RebootStockButton);
            this.Controls.Add(this.LcdOnButton);
            this.Controls.Add(this.LcdOffButton);
            this.Controls.Add(this.MotorsOffButton);
            this.Controls.Add(this.HomeAxesButton);
            this.Controls.Add(this.PausePrintButton);
            this.Controls.Add(this.CancelPrintButton);
            this.Controls.Add(this.ResumePrintButton);
            this.Controls.Add(this.RebootFwButton);
            this.Controls.Add(this.RebootHostButton);
            this.Controls.Add(this.RebootServerButton);
            this.Controls.Add(this.RebootMachineButton);
            this.Controls.Add(this.ShutdownMachineButton);
            this.Controls.Add(this.EstopButton);
            this.Controls.Add(this.TempsPanel);
            this.Controls.Add(this.StatusPanel);
            this.Controls.Add(this.SensorPanel);
            this.Controls.Add(this.ProgressPanel);
            this.Name = "MoonrakerUI";
            this.Text = "MoonrakerUI";
            this.Load += new System.EventHandler(this.MoonrakerUI_Load);
            this.ProgressPanel.ResumeLayout(false);
            this.SensorPanel.ResumeLayout(false);
            this.StatusPanel.ResumeLayout(false);
            this.TempsPanel.ResumeLayout(false);
            this.FilteringPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button OpenTerminalButton;
        private System.Windows.Forms.Button PrintPreviewButton;
        private System.Windows.Forms.Button ViewWebcamButton;
        private System.Windows.Forms.Panel FilteringPanel;

        private System.Windows.Forms.Button PrintFileButton;

        private System.Windows.Forms.Button InternalFilteringButton;
        private System.Windows.Forms.Button ExternalFilteringButton;

        private System.Windows.Forms.Button FilteringOffButton;

        private System.Windows.Forms.Button QuickBedLevelButton;
        private System.Windows.Forms.Button BedLevelButton;

        private System.Windows.Forms.Button RebootStockButton;

        private System.Windows.Forms.Button LcdOffButton;
        private System.Windows.Forms.Button LcdOnButton;

        private System.Windows.Forms.Button MotorsOffButton;

        private System.Windows.Forms.Button HomeAxesButton;

        private System.Windows.Forms.Button PausePrintButton;

        private System.Windows.Forms.Button ResumePrintButton;
        private System.Windows.Forms.Button CancelPrintButton;

        private System.Windows.Forms.Button RebootFwButton;

        private System.Windows.Forms.Button RebootHostButton;

        private System.Windows.Forms.Button RebootServerButton;

        private System.Windows.Forms.Button ShutdownMachineButton;

        private System.Windows.Forms.Button RebootMachineButton;

        private System.Windows.Forms.Button EstopButton;

        private System.Windows.Forms.Label ExtruderTempLabel;
        private System.Windows.Forms.Label BedTempLabel;

        private System.Windows.Forms.Panel TempsPanel;

        private System.Windows.Forms.Label StatusLabel;

        private System.Windows.Forms.Panel StatusPanel;
        private System.Windows.Forms.Label HostNameLabel;

        private System.Windows.Forms.Label FilamentUsedLabel;

        private System.Windows.Forms.Label ControllerFanLabel;
        private System.Windows.Forms.Label LoadCellLabel;

        private System.Windows.Forms.Label InternalFanLabel;
        private System.Windows.Forms.Label ExternalFanLabel;
        private System.Windows.Forms.Label TvocLabel;

        private System.Windows.Forms.Label PartFanLabel;

        private System.Windows.Forms.Label PrintProgressLabel;
        private System.Windows.Forms.Label ChamberFanLabel;

        private System.Windows.Forms.Panel SensorPanel;

        private System.Windows.Forms.ProgressBar PrintProgressBar;

        private System.Windows.Forms.Label FileNameLabel;

        private System.Windows.Forms.Label PrintTimeLabel;

        private System.Windows.Forms.Panel ProgressPanel;

        #endregion
    }
}