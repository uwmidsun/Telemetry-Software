﻿namespace Telemetry
{
    partial class TelemetryGUI
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.LoggerTab = new System.Windows.Forms.TabPage();
            this.Button_Logger_Stop = new System.Windows.Forms.Button();
            this.Button_Logger_Start = new System.Windows.Forms.Button();
            this.Button_Logger_Clear = new System.Windows.Forms.Button();
            this.Logger_Status = new System.Windows.Forms.Label();
            this.Logger_StatusLabel = new System.Windows.Forms.Label();
            this.MessageList = new System.Windows.Forms.ListView();
            this.Column_GroupName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_EntryName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_Timestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MotorTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Motor_Status = new System.Windows.Forms.Label();
            this.Button_Motor_Clear = new System.Windows.Forms.Button();
            this.Button_Motor_Stop = new System.Windows.Forms.Button();
            this.Button_Motor_Start = new System.Windows.Forms.Button();
            this.Motor_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BUSTab = new System.Windows.Forms.TabPage();
            this.BUSChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BatteryTab = new System.Windows.Forms.TabPage();
            this.BatteryChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MiscTab = new System.Windows.Forms.TabPage();
            this.Misc_DCAmpPanel = new System.Windows.Forms.Panel();
            this.Misc_DCAmp = new System.Windows.Forms.Label();
            this.Misc_DCAmpReadingLabel = new System.Windows.Forms.Label();
            this.VehicleVelocityChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.Misc_OdometerPanel = new System.Windows.Forms.Panel();
            this.Misc_Odometer = new System.Windows.Forms.Label();
            this.Misc_OdometerLabel = new System.Windows.Forms.Label();
            this.Logger_OptimalVelocityPanel = new System.Windows.Forms.Panel();
            this.Logger_OptimalVelocity = new System.Windows.Forms.Label();
            this.Logger_OptimalVelocityLabel = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.LoggerTab.SuspendLayout();
            this.MotorTab.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Motor_Chart)).BeginInit();
            this.BUSTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BUSChart)).BeginInit();
            this.BatteryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BatteryChart)).BeginInit();
            this.MiscTab.SuspendLayout();
            this.Misc_DCAmpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VehicleVelocityChart)).BeginInit();
            this.Misc_OdometerPanel.SuspendLayout();
            this.Logger_OptimalVelocityPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.LoggerTab);
            this.TabControl.Controls.Add(this.MotorTab);
            this.TabControl.Controls.Add(this.BUSTab);
            this.TabControl.Controls.Add(this.BatteryTab);
            this.TabControl.Controls.Add(this.MiscTab);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(660, 463);
            this.TabControl.TabIndex = 0;
            // 
            // LoggerTab
            // 
            this.LoggerTab.Controls.Add(this.Button_Logger_Stop);
            this.LoggerTab.Controls.Add(this.Button_Logger_Start);
            this.LoggerTab.Controls.Add(this.Button_Logger_Clear);
            this.LoggerTab.Controls.Add(this.Logger_Status);
            this.LoggerTab.Controls.Add(this.Logger_StatusLabel);
            this.LoggerTab.Controls.Add(this.MessageList);
            this.LoggerTab.Location = new System.Drawing.Point(4, 22);
            this.LoggerTab.Name = "LoggerTab";
            this.LoggerTab.Padding = new System.Windows.Forms.Padding(3);
            this.LoggerTab.Size = new System.Drawing.Size(652, 437);
            this.LoggerTab.TabIndex = 0;
            this.LoggerTab.Text = "Logger";
            this.LoggerTab.UseVisualStyleBackColor = true;
            // 
            // Button_Logger_Stop
            // 
            this.Button_Logger_Stop.Location = new System.Drawing.Point(1, 51);
            this.Button_Logger_Stop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Button_Logger_Stop.Name = "Button_Logger_Stop";
            this.Button_Logger_Stop.Size = new System.Drawing.Size(172, 34);
            this.Button_Logger_Stop.TabIndex = 16;
            this.Button_Logger_Stop.Text = "Stop";
            this.Button_Logger_Stop.UseVisualStyleBackColor = true;
            this.Button_Logger_Stop.Click += new System.EventHandler(this.Button_Logger_Stop_Click);
            // 
            // Button_Logger_Start
            // 
            this.Button_Logger_Start.Location = new System.Drawing.Point(1, 14);
            this.Button_Logger_Start.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Button_Logger_Start.Name = "Button_Logger_Start";
            this.Button_Logger_Start.Size = new System.Drawing.Size(172, 33);
            this.Button_Logger_Start.TabIndex = 15;
            this.Button_Logger_Start.Text = "Start";
            this.Button_Logger_Start.UseVisualStyleBackColor = true;
            this.Button_Logger_Start.Click += new System.EventHandler(this.Button_Logger_Start_Click);
            // 
            // Button_Logger_Clear
            // 
            this.Button_Logger_Clear.Location = new System.Drawing.Point(530, 51);
            this.Button_Logger_Clear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Button_Logger_Clear.Name = "Button_Logger_Clear";
            this.Button_Logger_Clear.Size = new System.Drawing.Size(115, 34);
            this.Button_Logger_Clear.TabIndex = 14;
            this.Button_Logger_Clear.Text = "Clear";
            this.Button_Logger_Clear.UseVisualStyleBackColor = true;
            this.Button_Logger_Clear.Click += new System.EventHandler(this.Button_Logger_Clear_Click);
            // 
            // Logger_Status
            // 
            this.Logger_Status.AutoSize = true;
            this.Logger_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logger_Status.ForeColor = System.Drawing.Color.Red;
            this.Logger_Status.Location = new System.Drawing.Point(221, 14);
            this.Logger_Status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Logger_Status.Name = "Logger_Status";
            this.Logger_Status.Size = new System.Drawing.Size(92, 13);
            this.Logger_Status.TabIndex = 13;
            this.Logger_Status.Text = "Not Connected";
            // 
            // Logger_StatusLabel
            // 
            this.Logger_StatusLabel.AutoSize = true;
            this.Logger_StatusLabel.Location = new System.Drawing.Point(179, 14);
            this.Logger_StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Logger_StatusLabel.Name = "Logger_StatusLabel";
            this.Logger_StatusLabel.Size = new System.Drawing.Size(44, 12);
            this.Logger_StatusLabel.TabIndex = 12;
            this.Logger_StatusLabel.Text = "Status:";
            // 
            // MessageList
            // 
            this.MessageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column_GroupName,
            this.Column_EntryName,
            this.Column_ID,
            this.Column_Value,
            this.Column_Timestamp});
            this.MessageList.FullRowSelect = true;
            this.MessageList.GridLines = true;
            this.MessageList.Location = new System.Drawing.Point(0, 91);
            this.MessageList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MessageList.MultiSelect = false;
            this.MessageList.Name = "MessageList";
            this.MessageList.Size = new System.Drawing.Size(645, 340);
            this.MessageList.TabIndex = 11;
            this.MessageList.UseCompatibleStateImageBehavior = false;
            this.MessageList.View = System.Windows.Forms.View.Details;
            // 
            // Column_GroupName
            // 
            this.Column_GroupName.Text = "Group Name";
            this.Column_GroupName.Width = 121;
            // 
            // Column_EntryName
            // 
            this.Column_EntryName.Text = "Entry Name";
            this.Column_EntryName.Width = 271;
            // 
            // Column_ID
            // 
            this.Column_ID.Text = "ID";
            // 
            // Column_Value
            // 
            this.Column_Value.Text = "Value";
            this.Column_Value.Width = 84;
            // 
            // Column_Timestamp
            // 
            this.Column_Timestamp.Text = "Timestamp";
            this.Column_Timestamp.Width = 200;
            // 
            // MotorTab
            // 
            this.MotorTab.Controls.Add(this.panel1);
            this.MotorTab.Location = new System.Drawing.Point(4, 22);
            this.MotorTab.Name = "MotorTab";
            this.MotorTab.Padding = new System.Windows.Forms.Padding(3);
            this.MotorTab.Size = new System.Drawing.Size(652, 437);
            this.MotorTab.TabIndex = 1;
            this.MotorTab.Text = "Motor";
            this.MotorTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Logger_OptimalVelocityPanel);
            this.panel1.Controls.Add(this.Logger_OptimalVelocityLabel);
            this.panel1.Controls.Add(this.Motor_Status);
            this.panel1.Controls.Add(this.Button_Motor_Clear);
            this.panel1.Controls.Add(this.Button_Motor_Stop);
            this.panel1.Controls.Add(this.Button_Motor_Start);
            this.panel1.Controls.Add(this.Motor_Chart);
            this.panel1.Location = new System.Drawing.Point(36, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 397);
            this.panel1.TabIndex = 1;
            // 
            // Motor_Status
            // 
            this.Motor_Status.AutoSize = true;
            this.Motor_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Motor_Status.ForeColor = System.Drawing.Color.Red;
            this.Motor_Status.Location = new System.Drawing.Point(466, 61);
            this.Motor_Status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Motor_Status.Name = "Motor_Status";
            this.Motor_Status.Size = new System.Drawing.Size(92, 13);
            this.Motor_Status.TabIndex = 14;
            this.Motor_Status.Text = "Not Connected";
            // 
            // Button_Motor_Clear
            // 
            this.Button_Motor_Clear.Location = new System.Drawing.Point(457, 159);
            this.Button_Motor_Clear.Name = "Button_Motor_Clear";
            this.Button_Motor_Clear.Size = new System.Drawing.Size(119, 30);
            this.Button_Motor_Clear.TabIndex = 1;
            this.Button_Motor_Clear.Text = "Clear";
            this.Button_Motor_Clear.UseVisualStyleBackColor = true;
            this.Button_Motor_Clear.Click += new System.EventHandler(this.Button_Motor_Clear_Click);
            // 
            // Button_Motor_Stop
            // 
            this.Button_Motor_Stop.Location = new System.Drawing.Point(457, 123);
            this.Button_Motor_Stop.Name = "Button_Motor_Stop";
            this.Button_Motor_Stop.Size = new System.Drawing.Size(119, 30);
            this.Button_Motor_Stop.TabIndex = 1;
            this.Button_Motor_Stop.Text = "Stop";
            this.Button_Motor_Stop.UseVisualStyleBackColor = true;
            this.Button_Motor_Stop.Click += new System.EventHandler(this.Button_Motor_Stop_Click);
            // 
            // Button_Motor_Start
            // 
            this.Button_Motor_Start.Location = new System.Drawing.Point(457, 87);
            this.Button_Motor_Start.Name = "Button_Motor_Start";
            this.Button_Motor_Start.Size = new System.Drawing.Size(119, 30);
            this.Button_Motor_Start.TabIndex = 1;
            this.Button_Motor_Start.Text = "Start";
            this.Button_Motor_Start.UseVisualStyleBackColor = true;
            this.Button_Motor_Start.Click += new System.EventHandler(this.Button_Motor_Start_Click);
            // 
            // Motor_Chart
            // 
            chartArea1.Name = "MotorChartArea";
            this.Motor_Chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Motor_Chart.Legends.Add(legend1);
            this.Motor_Chart.Location = new System.Drawing.Point(-1, -1);
            this.Motor_Chart.Name = "Motor_Chart";
            series1.ChartArea = "MotorChartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Motor Current";
            series2.ChartArea = "MotorChartArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Motor Velocity";
            this.Motor_Chart.Series.Add(series1);
            this.Motor_Chart.Series.Add(series2);
            this.Motor_Chart.Size = new System.Drawing.Size(597, 397);
            this.Motor_Chart.TabIndex = 0;
            this.Motor_Chart.Text = "MotorChart";
            // 
            // BUSTab
            // 
            this.BUSTab.Controls.Add(this.BUSChart);
            this.BUSTab.Location = new System.Drawing.Point(4, 22);
            this.BUSTab.Name = "BUSTab";
            this.BUSTab.Size = new System.Drawing.Size(652, 437);
            this.BUSTab.TabIndex = 4;
            this.BUSTab.Text = "BUS";
            this.BUSTab.UseVisualStyleBackColor = true;
            // 
            // BUSChart
            // 
            chartArea2.Name = "MotorChartArea";
            this.BUSChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.BUSChart.Legends.Add(legend2);
            this.BUSChart.Location = new System.Drawing.Point(28, 20);
            this.BUSChart.Name = "BUSChart";
            series3.ChartArea = "MotorChartArea";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "BUSCurrent";
            this.BUSChart.Series.Add(series3);
            this.BUSChart.Size = new System.Drawing.Size(597, 397);
            this.BUSChart.TabIndex = 1;
            this.BUSChart.Text = "BUSChart";
            // 
            // BatteryTab
            // 
            this.BatteryTab.Controls.Add(this.BatteryChart);
            this.BatteryTab.Location = new System.Drawing.Point(4, 22);
            this.BatteryTab.Name = "BatteryTab";
            this.BatteryTab.Size = new System.Drawing.Size(652, 437);
            this.BatteryTab.TabIndex = 2;
            this.BatteryTab.Text = "Battery";
            this.BatteryTab.UseVisualStyleBackColor = true;
            // 
            // BatteryChart
            // 
            chartArea3.Name = "ChartArea1";
            this.BatteryChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.BatteryChart.Legends.Add(legend3);
            this.BatteryChart.Location = new System.Drawing.Point(3, 3);
            this.BatteryChart.Name = "BatteryChart";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "BatteryVoltage";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "BatteryTemperature";
            this.BatteryChart.Series.Add(series4);
            this.BatteryChart.Series.Add(series5);
            this.BatteryChart.Size = new System.Drawing.Size(646, 431);
            this.BatteryChart.TabIndex = 0;
            this.BatteryChart.Text = "BatteryChart";
            // 
            // MiscTab
            // 
            this.MiscTab.Controls.Add(this.Misc_DCAmpPanel);
            this.MiscTab.Controls.Add(this.Misc_DCAmpReadingLabel);
            this.MiscTab.Controls.Add(this.VehicleVelocityChart);
            this.MiscTab.Controls.Add(this.label1);
            this.MiscTab.Controls.Add(this.Misc_OdometerPanel);
            this.MiscTab.Controls.Add(this.Misc_OdometerLabel);
            this.MiscTab.Location = new System.Drawing.Point(4, 22);
            this.MiscTab.Name = "MiscTab";
            this.MiscTab.Size = new System.Drawing.Size(652, 437);
            this.MiscTab.TabIndex = 3;
            this.MiscTab.Text = "Misc";
            this.MiscTab.UseVisualStyleBackColor = true;
            // 
            // Misc_DCAmpPanel
            // 
            this.Misc_DCAmpPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Misc_DCAmpPanel.Controls.Add(this.Misc_DCAmp);
            this.Misc_DCAmpPanel.Location = new System.Drawing.Point(24, 126);
            this.Misc_DCAmpPanel.Name = "Misc_DCAmpPanel";
            this.Misc_DCAmpPanel.Size = new System.Drawing.Size(109, 27);
            this.Misc_DCAmpPanel.TabIndex = 6;
            // 
            // Misc_DCAmp
            // 
            this.Misc_DCAmp.AutoSize = true;
            this.Misc_DCAmp.Location = new System.Drawing.Point(3, 0);
            this.Misc_DCAmp.Name = "Misc_DCAmp";
            this.Misc_DCAmp.Size = new System.Drawing.Size(48, 12);
            this.Misc_DCAmp.TabIndex = 7;
            this.Misc_DCAmp.Text = "DCAmp";
            // 
            // Misc_DCAmpReadingLabel
            // 
            this.Misc_DCAmpReadingLabel.AutoSize = true;
            this.Misc_DCAmpReadingLabel.Location = new System.Drawing.Point(24, 101);
            this.Misc_DCAmpReadingLabel.Name = "Misc_DCAmpReadingLabel";
            this.Misc_DCAmpReadingLabel.Size = new System.Drawing.Size(94, 12);
            this.Misc_DCAmpReadingLabel.TabIndex = 5;
            this.Misc_DCAmpReadingLabel.Text = "DCAmpReading";
            // 
            // VehicleVelocityChart
            // 
            chartArea4.Name = "ChartArea1";
            this.VehicleVelocityChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.VehicleVelocityChart.Legends.Add(legend4);
            this.VehicleVelocityChart.Location = new System.Drawing.Point(238, 40);
            this.VehicleVelocityChart.Name = "VehicleVelocityChart";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.VehicleVelocityChart.Series.Add(series6);
            this.VehicleVelocityChart.Size = new System.Drawing.Size(384, 264);
            this.VehicleVelocityChart.TabIndex = 4;
            this.VehicleVelocityChart.Text = "VehicleVelocityChart";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vehicle Velocity";
            // 
            // Misc_OdometerPanel
            // 
            this.Misc_OdometerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Misc_OdometerPanel.Controls.Add(this.Misc_Odometer);
            this.Misc_OdometerPanel.Location = new System.Drawing.Point(24, 40);
            this.Misc_OdometerPanel.Name = "Misc_OdometerPanel";
            this.Misc_OdometerPanel.Size = new System.Drawing.Size(109, 27);
            this.Misc_OdometerPanel.TabIndex = 2;
            // 
            // Misc_Odometer
            // 
            this.Misc_Odometer.AutoSize = true;
            this.Misc_Odometer.Location = new System.Drawing.Point(3, 0);
            this.Misc_Odometer.Name = "Misc_Odometer";
            this.Misc_Odometer.Size = new System.Drawing.Size(60, 12);
            this.Misc_Odometer.TabIndex = 0;
            this.Misc_Odometer.Text = "Odometer";
            // 
            // Misc_OdometerLabel
            // 
            this.Misc_OdometerLabel.AutoSize = true;
            this.Misc_OdometerLabel.Location = new System.Drawing.Point(22, 17);
            this.Misc_OdometerLabel.Name = "Misc_OdometerLabel";
            this.Misc_OdometerLabel.Size = new System.Drawing.Size(110, 12);
            this.Misc_OdometerLabel.TabIndex = 0;
            this.Misc_OdometerLabel.Text = "Odometer Reading";
            // 
            // Logger_OptimalVelocityPanel
            // 
            this.Logger_OptimalVelocityPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Logger_OptimalVelocityPanel.Controls.Add(this.Logger_OptimalVelocity);
            this.Logger_OptimalVelocityPanel.Location = new System.Drawing.Point(457, 270);
            this.Logger_OptimalVelocityPanel.Name = "Logger_OptimalVelocityPanel";
            this.Logger_OptimalVelocityPanel.Size = new System.Drawing.Size(119, 27);
            this.Logger_OptimalVelocityPanel.TabIndex = 16;
            // 
            // Logger_OptimalVelocity
            // 
            this.Logger_OptimalVelocity.AutoSize = true;
            this.Logger_OptimalVelocity.Location = new System.Drawing.Point(9, 0);
            this.Logger_OptimalVelocity.Name = "Logger_OptimalVelocity";
            this.Logger_OptimalVelocity.Size = new System.Drawing.Size(50, 12);
            this.Logger_OptimalVelocity.TabIndex = 7;
            this.Logger_OptimalVelocity.Text = "Velocity";
            // 
            // Logger_OptimalVelocityLabel
            // 
            this.Logger_OptimalVelocityLabel.AutoSize = true;
            this.Logger_OptimalVelocityLabel.Location = new System.Drawing.Point(467, 245);
            this.Logger_OptimalVelocityLabel.Name = "Logger_OptimalVelocityLabel";
            this.Logger_OptimalVelocityLabel.Size = new System.Drawing.Size(97, 12);
            this.Logger_OptimalVelocityLabel.TabIndex = 15;
            this.Logger_OptimalVelocityLabel.Text = "Optimal Velocity";
            // 
            // TelemetryGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 487);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TelemetryGUI";
            this.Text = "Telemetry Software";
            this.TabControl.ResumeLayout(false);
            this.LoggerTab.ResumeLayout(false);
            this.LoggerTab.PerformLayout();
            this.MotorTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Motor_Chart)).EndInit();
            this.BUSTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BUSChart)).EndInit();
            this.BatteryTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BatteryChart)).EndInit();
            this.MiscTab.ResumeLayout(false);
            this.MiscTab.PerformLayout();
            this.Misc_DCAmpPanel.ResumeLayout(false);
            this.Misc_DCAmpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VehicleVelocityChart)).EndInit();
            this.Misc_OdometerPanel.ResumeLayout(false);
            this.Misc_OdometerPanel.PerformLayout();
            this.Logger_OptimalVelocityPanel.ResumeLayout(false);
            this.Logger_OptimalVelocityPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage LoggerTab;
        private System.Windows.Forms.Button Button_Logger_Stop;
        private System.Windows.Forms.Button Button_Logger_Start;
        private System.Windows.Forms.Button Button_Logger_Clear;
        private System.Windows.Forms.Label Logger_Status;
        private System.Windows.Forms.Label Logger_StatusLabel;
        private System.Windows.Forms.ListView MessageList;
        private System.Windows.Forms.ColumnHeader Column_GroupName;
        private System.Windows.Forms.ColumnHeader Column_EntryName;
        private System.Windows.Forms.ColumnHeader Column_ID;
        private System.Windows.Forms.ColumnHeader Column_Value;
        private System.Windows.Forms.ColumnHeader Column_Timestamp;
        private System.Windows.Forms.TabPage MotorTab;
        private System.Windows.Forms.TabPage BatteryTab;
        private System.Windows.Forms.TabPage MiscTab;
        private System.Windows.Forms.DataVisualization.Charting.Chart Motor_Chart;
        private System.Windows.Forms.Label Misc_OdometerLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart VehicleVelocityChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart BatteryChart;
        private System.Windows.Forms.Button Button_Motor_Clear;
        private System.Windows.Forms.Button Button_Motor_Stop;
        private System.Windows.Forms.Button Button_Motor_Start;
        private System.Windows.Forms.Label Motor_Status;
        private System.Windows.Forms.TabPage BUSTab;
        private System.Windows.Forms.DataVisualization.Charting.Chart BUSChart;
        private System.Windows.Forms.Panel Misc_OdometerPanel;
        private System.Windows.Forms.Label Misc_Odometer;
        private System.Windows.Forms.Panel Misc_DCAmpPanel;
        private System.Windows.Forms.Label Misc_DCAmp;
        private System.Windows.Forms.Label Misc_DCAmpReadingLabel;
        private System.Windows.Forms.Panel Logger_OptimalVelocityPanel;
        private System.Windows.Forms.Label Logger_OptimalVelocity;
        private System.Windows.Forms.Label Logger_OptimalVelocityLabel;

    }
}

