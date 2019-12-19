namespace DataShowApplication {
    partial class DataShow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.flowLayoutPanelSensorsInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxFilterLocation = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBoxAlerts = new System.Windows.Forms.GroupBox();
            this.listBoxAlerts = new System.Windows.Forms.ListBox();
            this.ChartSensor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxFilterLocation.SuspendLayout();
            this.groupBoxAlerts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartSensor)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelSensorsInfo
            // 
            this.flowLayoutPanelSensorsInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelSensorsInfo.AutoScroll = true;
            this.flowLayoutPanelSensorsInfo.Location = new System.Drawing.Point(13, 115);
            this.flowLayoutPanelSensorsInfo.Name = "flowLayoutPanelSensorsInfo";
            this.flowLayoutPanelSensorsInfo.Size = new System.Drawing.Size(994, 361);
            this.flowLayoutPanelSensorsInfo.TabIndex = 0;
            // 
            // groupBoxFilterLocation
            // 
            this.groupBoxFilterLocation.Controls.Add(this.comboBox1);
            this.groupBoxFilterLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFilterLocation.Location = new System.Drawing.Point(33, 2);
            this.groupBoxFilterLocation.Name = "groupBoxFilterLocation";
            this.groupBoxFilterLocation.Size = new System.Drawing.Size(207, 78);
            this.groupBoxFilterLocation.TabIndex = 3;
            this.groupBoxFilterLocation.TabStop = false;
            this.groupBoxFilterLocation.Text = "Filter Location";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(24, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 28);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBoxAlerts
            // 
            this.groupBoxAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAlerts.Controls.Add(this.listBoxAlerts);
            this.groupBoxAlerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAlerts.Location = new System.Drawing.Point(295, 2);
            this.groupBoxAlerts.Name = "groupBoxAlerts";
            this.groupBoxAlerts.Size = new System.Drawing.Size(692, 107);
            this.groupBoxAlerts.TabIndex = 4;
            this.groupBoxAlerts.TabStop = false;
            this.groupBoxAlerts.Text = "Alerts";
            // 
            // listBoxAlerts
            // 
            this.listBoxAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxAlerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAlerts.FormattingEnabled = true;
            this.listBoxAlerts.ItemHeight = 16;
            this.listBoxAlerts.Location = new System.Drawing.Point(6, 27);
            this.listBoxAlerts.Name = "listBoxAlerts";
            this.listBoxAlerts.Size = new System.Drawing.Size(680, 68);
            this.listBoxAlerts.TabIndex = 0;
            // 
            // ChartSensor
            // 
            this.ChartSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.ChartSensor.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartSensor.Legends.Add(legend1);
            this.ChartSensor.Location = new System.Drawing.Point(13, 495);
            this.ChartSensor.Name = "ChartSensor";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Blue;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.LegendText = "Temperature";
            series1.Name = "Temperature";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.Legend = "Legend1";
            series2.LegendText = "Humidity";
            series2.Name = "Humidity";
            this.ChartSensor.Series.Add(series1);
            this.ChartSensor.Series.Add(series2);
            this.ChartSensor.Size = new System.Drawing.Size(994, 300);
            this.ChartSensor.TabIndex = 5;
            this.ChartSensor.Text = "Sensor Data";
            // 
            // DataShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1020, 808);
            this.Controls.Add(this.ChartSensor);
            this.Controls.Add(this.groupBoxAlerts);
            this.Controls.Add(this.groupBoxFilterLocation);
            this.Controls.Add(this.flowLayoutPanelSensorsInfo);
            this.Name = "DataShow";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Data Show";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxFilterLocation.ResumeLayout(false);
            this.groupBoxAlerts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartSensor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSensorsInfo;
        private System.Windows.Forms.GroupBox groupBoxFilterLocation;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBoxAlerts;
        private System.Windows.Forms.ListBox listBoxAlerts;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartSensor;
    }
}

