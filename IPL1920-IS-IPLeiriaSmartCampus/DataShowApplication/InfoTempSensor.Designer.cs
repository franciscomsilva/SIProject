namespace DataShowApplication {
    partial class InfoTempSensor {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutSensors = new System.Windows.Forms.TableLayoutPanel();
            this.lblSensor = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblInfoSensor = new System.Windows.Forms.Label();
            this.lblInfoTemperature = new System.Windows.Forms.Label();
            this.lblInfoDate = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lblInfoLocation = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.tableLayoutSensors.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutSensors
            // 
            this.tableLayoutSensors.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutSensors.ColumnCount = 2;
            this.tableLayoutSensors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutSensors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutSensors.Controls.Add(this.lblSensor, 0, 0);
            this.tableLayoutSensors.Controls.Add(this.lblUpdate, 0, 3);
            this.tableLayoutSensors.Controls.Add(this.lblInfoSensor, 1, 0);
            this.tableLayoutSensors.Controls.Add(this.lblInfoTemperature, 1, 2);
            this.tableLayoutSensors.Controls.Add(this.lblInfoDate, 1, 3);
            this.tableLayoutSensors.Controls.Add(this.lblTemperature, 0, 2);
            this.tableLayoutSensors.Controls.Add(this.lblInfoLocation, 1, 1);
            this.tableLayoutSensors.Controls.Add(this.lblLocation, 0, 1);
            this.tableLayoutSensors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSensors.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutSensors.Name = "tableLayoutSensors";
            this.tableLayoutSensors.RowCount = 4;
            this.tableLayoutSensors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutSensors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutSensors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutSensors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutSensors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSensors.Size = new System.Drawing.Size(285, 220);
            this.tableLayoutSensors.TabIndex = 1;
            // 
            // lblSensor
            // 
            this.lblSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSensor.AutoSize = true;
            this.lblSensor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSensor.Location = new System.Drawing.Point(3, 0);
            this.lblSensor.Name = "lblSensor";
            this.lblSensor.Size = new System.Drawing.Size(108, 55);
            this.lblSensor.TabIndex = 0;
            this.lblSensor.Text = "Sensor";
            this.lblSensor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpdate
            // 
            this.lblUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(3, 165);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(108, 55);
            this.lblUpdate.TabIndex = 4;
            this.lblUpdate.Text = "Last Update at";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInfoSensor
            // 
            this.lblInfoSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoSensor.AutoSize = true;
            this.lblInfoSensor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoSensor.Location = new System.Drawing.Point(117, 0);
            this.lblInfoSensor.Name = "lblInfoSensor";
            this.lblInfoSensor.Size = new System.Drawing.Size(165, 55);
            this.lblInfoSensor.TabIndex = 5;
            this.lblInfoSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfoTemperature
            // 
            this.lblInfoTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoTemperature.AutoSize = true;
            this.lblInfoTemperature.Location = new System.Drawing.Point(117, 110);
            this.lblInfoTemperature.Name = "lblInfoTemperature";
            this.lblInfoTemperature.Size = new System.Drawing.Size(165, 55);
            this.lblInfoTemperature.TabIndex = 8;
            this.lblInfoTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfoDate
            // 
            this.lblInfoDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoDate.AutoSize = true;
            this.lblInfoDate.Location = new System.Drawing.Point(117, 165);
            this.lblInfoDate.Name = "lblInfoDate";
            this.lblInfoDate.Size = new System.Drawing.Size(165, 55);
            this.lblInfoDate.TabIndex = 9;
            this.lblInfoDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTemperature
            // 
            this.lblTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Location = new System.Drawing.Point(3, 110);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(108, 55);
            this.lblTemperature.TabIndex = 1;
            this.lblTemperature.Text = "Temperature";
            this.lblTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInfoLocation
            // 
            this.lblInfoLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoLocation.AutoSize = true;
            this.lblInfoLocation.Location = new System.Drawing.Point(117, 55);
            this.lblInfoLocation.Name = "lblInfoLocation";
            this.lblInfoLocation.Size = new System.Drawing.Size(165, 55);
            this.lblInfoLocation.TabIndex = 6;
            this.lblInfoLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocation
            // 
            this.lblLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(3, 55);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(108, 55);
            this.lblLocation.TabIndex = 3;
            this.lblLocation.Text = "Location";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InfoTempSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutSensors);
            this.Name = "InfoTempSensor";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Size = new System.Drawing.Size(315, 250);
            this.tableLayoutSensors.ResumeLayout(false);
            this.tableLayoutSensors.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutSensors;
        private System.Windows.Forms.Label lblSensor;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label lblInfoSensor;
        private System.Windows.Forms.Label lblInfoLocation;
        private System.Windows.Forms.Label lblInfoTemperature;
        private System.Windows.Forms.Label lblInfoDate;
    }
}
