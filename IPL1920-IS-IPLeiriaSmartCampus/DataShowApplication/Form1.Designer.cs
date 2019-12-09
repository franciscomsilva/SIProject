namespace DataShowApplication {
    partial class Form1 {
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
            this.flowLayoutPanelSensorsInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBoxAlerts = new System.Windows.Forms.GroupBox();
            this.listBoxAlerts = new System.Windows.Forms.ListBox();
            this.groupBoxFilters.SuspendLayout();
            this.groupBoxAlerts.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelSensorsInfo
            // 
            this.flowLayoutPanelSensorsInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelSensorsInfo.AutoScroll = true;
            this.flowLayoutPanelSensorsInfo.Location = new System.Drawing.Point(10, 115);
            this.flowLayoutPanelSensorsInfo.Name = "flowLayoutPanelSensorsInfo";
            this.flowLayoutPanelSensorsInfo.Size = new System.Drawing.Size(1000, 452);
            this.flowLayoutPanelSensorsInfo.TabIndex = 0;
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Controls.Add(this.comboBox1);
            this.groupBoxFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBoxFilters.Location = new System.Drawing.Point(10, 10);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new System.Drawing.Size(1000, 85);
            this.groupBoxFilters.TabIndex = 3;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Filters";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(57, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 28);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBoxAlerts
            // 
            this.groupBoxAlerts.Controls.Add(this.listBoxAlerts);
            this.groupBoxAlerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAlerts.Location = new System.Drawing.Point(10, 589);
            this.groupBoxAlerts.Name = "groupBoxAlerts";
            this.groupBoxAlerts.Size = new System.Drawing.Size(1000, 173);
            this.groupBoxAlerts.TabIndex = 4;
            this.groupBoxAlerts.TabStop = false;
            this.groupBoxAlerts.Text = "Alerts";
            // 
            // listBoxAlerts
            // 
            this.listBoxAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxAlerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAlerts.FormattingEnabled = true;
            this.listBoxAlerts.ItemHeight = 16;
            this.listBoxAlerts.Location = new System.Drawing.Point(0, 27);
            this.listBoxAlerts.Name = "listBoxAlerts";
            this.listBoxAlerts.Size = new System.Drawing.Size(1000, 132);
            this.listBoxAlerts.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1020, 775);
            this.Controls.Add(this.groupBoxAlerts);
            this.Controls.Add(this.groupBoxFilters);
            this.Controls.Add(this.flowLayoutPanelSensorsInfo);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Data Show";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxFilters.ResumeLayout(false);
            this.groupBoxAlerts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSensorsInfo;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBoxAlerts;
        private System.Windows.Forms.ListBox listBoxAlerts;
    }
}

