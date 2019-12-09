namespace DataShowApplication {
    partial class InfoHumiditySensor {
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
            this.lblHumidity = new System.Windows.Forms.Label();
            this.lblBattery = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblInfoSensor = new System.Windows.Forms.Label();
            this.lblInfoHumidity = new System.Windows.Forms.Label();
            this.lblInfoBaterry = new System.Windows.Forms.Label();
            this.lblInfoDate = new System.Windows.Forms.Label();
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
            this.tableLayoutSensors.Controls.Add(this.lblHumidity, 0, 1);
            this.tableLayoutSensors.Controls.Add(this.lblBattery, 0, 2);
            this.tableLayoutSensors.Controls.Add(this.lblUpdate, 0, 3);
            this.tableLayoutSensors.Controls.Add(this.lblInfoSensor, 1, 0);
            this.tableLayoutSensors.Controls.Add(this.lblInfoHumidity, 1, 1);
            this.tableLayoutSensors.Controls.Add(this.lblInfoBaterry, 1, 2);
            this.tableLayoutSensors.Controls.Add(this.lblInfoDate, 1, 3);
            this.tableLayoutSensors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSensors.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutSensors.Name = "tableLayoutSensors";
            this.tableLayoutSensors.RowCount = 4;
            this.tableLayoutSensors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutSensors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutSensors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutSensors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutSensors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSensors.Size = new System.Drawing.Size(285, 185);
            this.tableLayoutSensors.TabIndex = 2;
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
            this.lblSensor.Size = new System.Drawing.Size(108, 46);
            this.lblSensor.TabIndex = 0;
            this.lblSensor.Text = "Sensor";
            this.lblSensor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHumidity
            // 
            this.lblHumidity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHumidity.AutoSize = true;
            this.lblHumidity.Location = new System.Drawing.Point(3, 46);
            this.lblHumidity.Name = "lblHumidity";
            this.lblHumidity.Size = new System.Drawing.Size(108, 46);
            this.lblHumidity.TabIndex = 1;
            this.lblHumidity.Text = "Humidity";
            this.lblHumidity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBattery
            // 
            this.lblBattery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBattery.AutoSize = true;
            this.lblBattery.Location = new System.Drawing.Point(3, 92);
            this.lblBattery.Name = "lblBattery";
            this.lblBattery.Size = new System.Drawing.Size(108, 46);
            this.lblBattery.TabIndex = 3;
            this.lblBattery.Text = "Battery";
            this.lblBattery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpdate
            // 
            this.lblUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(3, 138);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(108, 47);
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
            this.lblInfoSensor.Size = new System.Drawing.Size(165, 46);
            this.lblInfoSensor.TabIndex = 5;
            this.lblInfoSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfoHumidity
            // 
            this.lblInfoHumidity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoHumidity.AutoSize = true;
            this.lblInfoHumidity.Location = new System.Drawing.Point(117, 46);
            this.lblInfoHumidity.Name = "lblInfoHumidity";
            this.lblInfoHumidity.Size = new System.Drawing.Size(165, 46);
            this.lblInfoHumidity.TabIndex = 6;
            this.lblInfoHumidity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfoBaterry
            // 
            this.lblInfoBaterry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoBaterry.AutoSize = true;
            this.lblInfoBaterry.Location = new System.Drawing.Point(117, 92);
            this.lblInfoBaterry.Name = "lblInfoBaterry";
            this.lblInfoBaterry.Size = new System.Drawing.Size(165, 46);
            this.lblInfoBaterry.TabIndex = 8;
            this.lblInfoBaterry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfoDate
            // 
            this.lblInfoDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoDate.AutoSize = true;
            this.lblInfoDate.Location = new System.Drawing.Point(117, 138);
            this.lblInfoDate.Name = "lblInfoDate";
            this.lblInfoDate.Size = new System.Drawing.Size(165, 47);
            this.lblInfoDate.TabIndex = 9;
            this.lblInfoDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoHumiditySensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutSensors);
            this.Name = "InfoHumiditySensor";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Size = new System.Drawing.Size(315, 215);
            this.tableLayoutSensors.ResumeLayout(false);
            this.tableLayoutSensors.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutSensors;
        private System.Windows.Forms.Label lblSensor;
        private System.Windows.Forms.Label lblHumidity;
        private System.Windows.Forms.Label lblBattery;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label lblInfoSensor;
        private System.Windows.Forms.Label lblInfoHumidity;
        private System.Windows.Forms.Label lblInfoBaterry;
        private System.Windows.Forms.Label lblInfoDate;
    }
}
