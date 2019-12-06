using System;

namespace ALERTS_APPLICATION
{
    partial class Main
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.alertsTab = new System.Windows.Forms.TabPage();
            this.btnCleanAlerts = new System.Windows.Forms.Button();
            this.lvAlerts = new System.Windows.Forms.ListView();
            this.lblConfiguredAlerts = new System.Windows.Forms.Label();
            this.generatedAlertsTab = new System.Windows.Forms.TabPage();
            this.addAlertTab = new System.Windows.Forms.TabPage();
            this.lvParameters = new System.Windows.Forms.ListView();
            this.nrParameterValue = new System.Windows.Forms.NumericUpDown();
            this.lblParameterValue = new System.Windows.Forms.Label();
            this.btnCreateAlert = new System.Windows.Forms.Button();
            this.lblAddParameter = new System.Windows.Forms.Label();
            this.lblAlertsParameters = new System.Windows.Forms.Label();
            this.btnAddParameter = new System.Windows.Forms.Button();
            this.lblParameterDataType = new System.Windows.Forms.Label();
            this.cbDataType = new System.Windows.Forms.ComboBox();
            this.lblParameterCondition = new System.Windows.Forms.Label();
            this.cbParameterCondition = new System.Windows.Forms.ComboBox();
            this.lblConfigureAlert = new System.Windows.Forms.Label();
            this.lblAlertDescription = new System.Windows.Forms.Label();
            this.txtAlertDescription = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.alertsTab.SuspendLayout();
            this.addAlertTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrParameterValue)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.alertsTab);
            this.tabControl1.Controls.Add(this.generatedAlertsTab);
            this.tabControl1.Controls.Add(this.addAlertTab);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1334, 711);
            this.tabControl1.TabIndex = 0;
            // 
            // alertsTab
            // 
            this.alertsTab.Controls.Add(this.btnCleanAlerts);
            this.alertsTab.Controls.Add(this.lvAlerts);
            this.alertsTab.Controls.Add(this.lblConfiguredAlerts);
            this.alertsTab.Location = new System.Drawing.Point(4, 22);
            this.alertsTab.Name = "alertsTab";
            this.alertsTab.Padding = new System.Windows.Forms.Padding(3);
            this.alertsTab.Size = new System.Drawing.Size(1326, 685);
            this.alertsTab.TabIndex = 0;
            this.alertsTab.Text = "Alerts";
            this.alertsTab.UseVisualStyleBackColor = true;
            // 
            // btnCleanAlerts
            // 
            this.btnCleanAlerts.Location = new System.Drawing.Point(23, 79);
            this.btnCleanAlerts.Name = "btnCleanAlerts";
            this.btnCleanAlerts.Size = new System.Drawing.Size(125, 23);
            this.btnCleanAlerts.TabIndex = 19;
            this.btnCleanAlerts.Text = "CLEAN ALERTS";
            this.btnCleanAlerts.UseVisualStyleBackColor = true;
            this.btnCleanAlerts.Click += new System.EventHandler(this.btnLimparAlertas_Click);
            // 
            // lvAlerts
            // 
            this.lvAlerts.HideSelection = false;
            this.lvAlerts.Location = new System.Drawing.Point(23, 110);
            this.lvAlerts.Name = "lvAlerts";
            this.lvAlerts.Size = new System.Drawing.Size(1273, 531);
            this.lvAlerts.TabIndex = 18;
            this.lvAlerts.UseCompatibleStateImageBehavior = false;
            // 
            // lblConfiguredAlerts
            // 
            this.lblConfiguredAlerts.AutoSize = true;
            this.lblConfiguredAlerts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblConfiguredAlerts.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfiguredAlerts.Location = new System.Drawing.Point(15, 18);
            this.lblConfiguredAlerts.Name = "lblConfiguredAlerts";
            this.lblConfiguredAlerts.Size = new System.Drawing.Size(346, 45);
            this.lblConfiguredAlerts.TabIndex = 17;
            this.lblConfiguredAlerts.Text = "CONFIGURED ALERTS";
            this.lblConfiguredAlerts.Click += new System.EventHandler(this.label2_Click);
            // 
            // generatedAlertsTab
            // 
            this.generatedAlertsTab.Location = new System.Drawing.Point(4, 22);
            this.generatedAlertsTab.Name = "generatedAlertsTab";
            this.generatedAlertsTab.Padding = new System.Windows.Forms.Padding(3);
            this.generatedAlertsTab.Size = new System.Drawing.Size(1326, 685);
            this.generatedAlertsTab.TabIndex = 2;
            this.generatedAlertsTab.Text = "Generated Alerts";
            this.generatedAlertsTab.UseVisualStyleBackColor = true;
            // 
            // addAlertTab
            // 
            this.addAlertTab.Controls.Add(this.lvParameters);
            this.addAlertTab.Controls.Add(this.nrParameterValue);
            this.addAlertTab.Controls.Add(this.lblParameterValue);
            this.addAlertTab.Controls.Add(this.btnCreateAlert);
            this.addAlertTab.Controls.Add(this.lblAddParameter);
            this.addAlertTab.Controls.Add(this.lblAlertsParameters);
            this.addAlertTab.Controls.Add(this.btnAddParameter);
            this.addAlertTab.Controls.Add(this.lblParameterDataType);
            this.addAlertTab.Controls.Add(this.cbDataType);
            this.addAlertTab.Controls.Add(this.lblParameterCondition);
            this.addAlertTab.Controls.Add(this.cbParameterCondition);
            this.addAlertTab.Controls.Add(this.lblConfigureAlert);
            this.addAlertTab.Controls.Add(this.lblAlertDescription);
            this.addAlertTab.Controls.Add(this.txtAlertDescription);
            this.addAlertTab.Location = new System.Drawing.Point(4, 22);
            this.addAlertTab.Name = "addAlertTab";
            this.addAlertTab.Size = new System.Drawing.Size(1326, 685);
            this.addAlertTab.TabIndex = 1;
            this.addAlertTab.Text = "Add";
            this.addAlertTab.UseVisualStyleBackColor = true;
            // 
            // lvParameters
            // 
            this.lvParameters.HideSelection = false;
            this.lvParameters.Location = new System.Drawing.Point(31, 317);
            this.lvParameters.Name = "lvParameters";
            this.lvParameters.Size = new System.Drawing.Size(1278, 284);
            this.lvParameters.TabIndex = 15;
            this.lvParameters.UseCompatibleStateImageBehavior = false;
            // 
            // nrParameterValue
            // 
            this.nrParameterValue.DecimalPlaces = 2;
            this.nrParameterValue.Location = new System.Drawing.Point(116, 233);
            this.nrParameterValue.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nrParameterValue.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nrParameterValue.Name = "nrParameterValue";
            this.nrParameterValue.Size = new System.Drawing.Size(120, 20);
            this.nrParameterValue.TabIndex = 14;
            // 
            // lblParameterValue
            // 
            this.lblParameterValue.AutoSize = true;
            this.lblParameterValue.Location = new System.Drawing.Point(28, 235);
            this.lblParameterValue.Name = "lblParameterValue";
            this.lblParameterValue.Size = new System.Drawing.Size(31, 13);
            this.lblParameterValue.TabIndex = 13;
            this.lblParameterValue.Text = "Valor";
            this.lblParameterValue.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // btnCreateAlert
            // 
            this.btnCreateAlert.Location = new System.Drawing.Point(1077, 624);
            this.btnCreateAlert.Name = "btnCreateAlert";
            this.btnCreateAlert.Size = new System.Drawing.Size(160, 40);
            this.btnCreateAlert.TabIndex = 11;
            this.btnCreateAlert.Text = "CREATE ALERT";
            this.btnCreateAlert.UseVisualStyleBackColor = true;
            this.btnCreateAlert.Click += new System.EventHandler(this.btnCriarAlerta_Click);
            // 
            // lblAddParameter
            // 
            this.lblAddParameter.AutoSize = true;
            this.lblAddParameter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAddParameter.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddParameter.Location = new System.Drawing.Point(110, 122);
            this.lblAddParameter.Name = "lblAddParameter";
            this.lblAddParameter.Size = new System.Drawing.Size(197, 36);
            this.lblAddParameter.TabIndex = 10;
            this.lblAddParameter.Text = "Add Parameter";
            // 
            // lblAlertsParameters
            // 
            this.lblAlertsParameters.AutoSize = true;
            this.lblAlertsParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertsParameters.Location = new System.Drawing.Point(24, 293);
            this.lblAlertsParameters.Name = "lblAlertsParameters";
            this.lblAlertsParameters.Size = new System.Drawing.Size(157, 20);
            this.lblAlertsParameters.TabIndex = 9;
            this.lblAlertsParameters.Text = "Alert\'s Parameters";
            // 
            // btnAddParameter
            // 
            this.btnAddParameter.Location = new System.Drawing.Point(118, 267);
            this.btnAddParameter.Name = "btnAddParameter";
            this.btnAddParameter.Size = new System.Drawing.Size(75, 23);
            this.btnAddParameter.TabIndex = 7;
            this.btnAddParameter.Text = "ADD";
            this.btnAddParameter.UseVisualStyleBackColor = true;
            this.btnAddParameter.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // lblParameterDataType
            // 
            this.lblParameterDataType.AutoSize = true;
            this.lblParameterDataType.Location = new System.Drawing.Point(25, 212);
            this.lblParameterDataType.Name = "lblParameterDataType";
            this.lblParameterDataType.Size = new System.Drawing.Size(57, 13);
            this.lblParameterDataType.TabIndex = 6;
            this.lblParameterDataType.Text = "Data Type";
            // 
            // cbDataType
            // 
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Location = new System.Drawing.Point(118, 204);
            this.cbDataType.Name = "cbDataType";
            this.cbDataType.Size = new System.Drawing.Size(121, 21);
            this.cbDataType.TabIndex = 5;
            // 
            // lblParameterCondition
            // 
            this.lblParameterCondition.AutoSize = true;
            this.lblParameterCondition.Location = new System.Drawing.Point(28, 178);
            this.lblParameterCondition.Name = "lblParameterCondition";
            this.lblParameterCondition.Size = new System.Drawing.Size(51, 13);
            this.lblParameterCondition.TabIndex = 4;
            this.lblParameterCondition.Tag = "as";
            this.lblParameterCondition.Text = "Condition";
            // 
            // cbParameterCondition
            // 
            this.cbParameterCondition.FormattingEnabled = true;
            this.cbParameterCondition.Items.AddRange(new object[] {
            "=",
            "<",
            ">"});
            this.cbParameterCondition.Location = new System.Drawing.Point(118, 170);
            this.cbParameterCondition.Name = "cbParameterCondition";
            this.cbParameterCondition.Size = new System.Drawing.Size(121, 21);
            this.cbParameterCondition.TabIndex = 3;
            // 
            // lblConfigureAlert
            // 
            this.lblConfigureAlert.AutoSize = true;
            this.lblConfigureAlert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblConfigureAlert.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigureAlert.Location = new System.Drawing.Point(110, 10);
            this.lblConfigureAlert.Name = "lblConfigureAlert";
            this.lblConfigureAlert.Size = new System.Drawing.Size(166, 45);
            this.lblConfigureAlert.TabIndex = 2;
            this.lblConfigureAlert.Text = "Add Alert";
            // 
            // lblAlertDescription
            // 
            this.lblAlertDescription.AutoSize = true;
            this.lblAlertDescription.Location = new System.Drawing.Point(25, 89);
            this.lblAlertDescription.Name = "lblAlertDescription";
            this.lblAlertDescription.Size = new System.Drawing.Size(60, 13);
            this.lblAlertDescription.TabIndex = 1;
            this.lblAlertDescription.Text = "Description";
            // 
            // txtAlertDescription
            // 
            this.txtAlertDescription.Location = new System.Drawing.Point(118, 89);
            this.txtAlertDescription.Name = "txtAlertDescription";
            this.txtAlertDescription.Size = new System.Drawing.Size(448, 20);
            this.txtAlertDescription.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 714);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "Alerts Application";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.alertsTab.ResumeLayout(false);
            this.alertsTab.PerformLayout();
            this.addAlertTab.ResumeLayout(false);
            this.addAlertTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrParameterValue)).EndInit();
            this.ResumeLayout(false);

        }

        private void btnCriarAlerta_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage alertsTab;
        private System.Windows.Forms.TabPage addAlertTab;
        private System.Windows.Forms.Label lblConfigureAlert;
        private System.Windows.Forms.Label lblAlertDescription;
        private System.Windows.Forms.TextBox txtAlertDescription;
        private System.Windows.Forms.ComboBox cbParameterCondition;
        private System.Windows.Forms.Label lblParameterCondition;
        private System.Windows.Forms.Label lblAddParameter;
        private System.Windows.Forms.Label lblAlertsParameters;
        private System.Windows.Forms.Button btnAddParameter;
        private System.Windows.Forms.Label lblParameterDataType;
        private System.Windows.Forms.ComboBox cbDataType;
        private System.Windows.Forms.Button btnCreateAlert;
        private System.Windows.Forms.Label lblParameterValue;
        private System.Windows.Forms.NumericUpDown nrParameterValue;
        private System.Windows.Forms.ListView lvParameters;
        private System.Windows.Forms.Label lblConfiguredAlerts;
        private System.Windows.Forms.ListView lvAlerts;
        private System.Windows.Forms.Button btnCleanAlerts;
        private System.Windows.Forms.TabPage generatedAlertsTab;
    }
}

