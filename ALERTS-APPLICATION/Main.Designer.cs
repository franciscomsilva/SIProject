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
            this.viewTab = new System.Windows.Forms.TabPage();
            this.configureTab = new System.Windows.Forms.TabPage();
            this.listAlerts = new System.Windows.Forms.ListView();
            this.txtBoxNomeAlerta = new System.Windows.Forms.TextBox();
            this.lblDescricaoAlerta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCondicao = new System.Windows.Forms.ComboBox();
            this.lblCondicao = new System.Windows.Forms.Label();
            this.cbTipoDado = new System.Windows.Forms.ComboBox();
            this.lblDado = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lblParametros = new System.Windows.Forms.Label();
            this.lblAdicionarParametro = new System.Windows.Forms.Label();
            this.btnCriarAlerta = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.viewTab.SuspendLayout();
            this.configureTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.viewTab);
            this.tabControl1.Controls.Add(this.configureTab);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1334, 711);
            this.tabControl1.TabIndex = 0;
            // 
            // viewTab
            // 
            this.viewTab.Controls.Add(this.listAlerts);
            this.viewTab.Location = new System.Drawing.Point(4, 22);
            this.viewTab.Name = "viewTab";
            this.viewTab.Padding = new System.Windows.Forms.Padding(3);
            this.viewTab.Size = new System.Drawing.Size(1326, 685);
            this.viewTab.TabIndex = 0;
            this.viewTab.Text = "View";
            this.viewTab.UseVisualStyleBackColor = true;
            // 
            // configureTab
            // 
            this.configureTab.Controls.Add(this.btnCriarAlerta);
            this.configureTab.Controls.Add(this.lblAdicionarParametro);
            this.configureTab.Controls.Add(this.lblParametros);
            this.configureTab.Controls.Add(this.listView1);
            this.configureTab.Controls.Add(this.btnAdicionar);
            this.configureTab.Controls.Add(this.lblDado);
            this.configureTab.Controls.Add(this.cbTipoDado);
            this.configureTab.Controls.Add(this.lblCondicao);
            this.configureTab.Controls.Add(this.cbCondicao);
            this.configureTab.Controls.Add(this.label1);
            this.configureTab.Controls.Add(this.lblDescricaoAlerta);
            this.configureTab.Controls.Add(this.txtBoxNomeAlerta);
            this.configureTab.Location = new System.Drawing.Point(4, 22);
            this.configureTab.Name = "configureTab";
            this.configureTab.Size = new System.Drawing.Size(1326, 685);
            this.configureTab.TabIndex = 1;
            this.configureTab.Text = "Configure";
            this.configureTab.UseVisualStyleBackColor = true;
            this.configureTab.Click += new System.EventHandler(this.configureTab_Click);
            // 
            // listAlerts
            // 
            this.listAlerts.HideSelection = false;
            this.listAlerts.Location = new System.Drawing.Point(20, 39);
            this.listAlerts.Name = "listAlerts";
            this.listAlerts.Size = new System.Drawing.Size(1285, 629);
            this.listAlerts.TabIndex = 0;
            this.listAlerts.UseCompatibleStateImageBehavior = false;
            // 
            // txtBoxNomeAlerta
            // 
            this.txtBoxNomeAlerta.Location = new System.Drawing.Point(118, 89);
            this.txtBoxNomeAlerta.Name = "txtBoxNomeAlerta";
            this.txtBoxNomeAlerta.Size = new System.Drawing.Size(448, 20);
            this.txtBoxNomeAlerta.TabIndex = 0;
            // 
            // lblDescricaoAlerta
            // 
            this.lblDescricaoAlerta.AutoSize = true;
            this.lblDescricaoAlerta.Location = new System.Drawing.Point(25, 89);
            this.lblDescricaoAlerta.Name = "lblDescricaoAlerta";
            this.lblDescricaoAlerta.Size = new System.Drawing.Size(55, 13);
            this.lblDescricaoAlerta.TabIndex = 1;
            this.lblDescricaoAlerta.Text = "Descrição";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "Configurar alerta";
            // 
            // cbCondicao
            // 
            this.cbCondicao.FormattingEnabled = true;
            this.cbCondicao.Items.AddRange(new object[] {
            "=",
            "<",
            ">"});
            this.cbCondicao.Location = new System.Drawing.Point(118, 170);
            this.cbCondicao.Name = "cbCondicao";
            this.cbCondicao.Size = new System.Drawing.Size(121, 21);
            this.cbCondicao.TabIndex = 3;
            this.cbCondicao.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblCondicao
            // 
            this.lblCondicao.AutoSize = true;
            this.lblCondicao.Location = new System.Drawing.Point(28, 178);
            this.lblCondicao.Name = "lblCondicao";
            this.lblCondicao.Size = new System.Drawing.Size(52, 13);
            this.lblCondicao.TabIndex = 4;
            this.lblCondicao.Tag = "as";
            this.lblCondicao.Text = "Condição";
            // 
            // cbTipoDado
            // 
            this.cbTipoDado.FormattingEnabled = true;
            this.cbTipoDado.Items.AddRange(new object[] {
            "Humidade",
            "Temperature"});
            this.cbTipoDado.Location = new System.Drawing.Point(118, 204);
            this.cbTipoDado.Name = "cbTipoDado";
            this.cbTipoDado.Size = new System.Drawing.Size(121, 21);
            this.cbTipoDado.TabIndex = 5;
            // 
            // lblDado
            // 
            this.lblDado.AutoSize = true;
            this.lblDado.Location = new System.Drawing.Point(25, 212);
            this.lblDado.Name = "lblDado";
            this.lblDado.Size = new System.Drawing.Size(77, 13);
            this.lblDado.TabIndex = 6;
            this.lblDado.Text = "Tipo de Dados";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(118, 244);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 7;
            this.btnAdicionar.Text = "ADICIONAR";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(28, 303);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1248, 301);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // lblParametros
            // 
            this.lblParametros.AutoSize = true;
            this.lblParametros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParametros.Location = new System.Drawing.Point(30, 280);
            this.lblParametros.Name = "lblParametros";
            this.lblParametros.Size = new System.Drawing.Size(163, 20);
            this.lblParametros.TabIndex = 9;
            this.lblParametros.Text = "Pâmetros do Alerta";
            // 
            // lblAdicionarParametro
            // 
            this.lblAdicionarParametro.AutoSize = true;
            this.lblAdicionarParametro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAdicionarParametro.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdicionarParametro.Location = new System.Drawing.Point(110, 122);
            this.lblAdicionarParametro.Name = "lblAdicionarParametro";
            this.lblAdicionarParametro.Size = new System.Drawing.Size(266, 36);
            this.lblAdicionarParametro.TabIndex = 10;
            this.lblAdicionarParametro.Text = "Adicionar parâmetro";
            this.lblAdicionarParametro.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnCriarAlerta
            // 
            this.btnCriarAlerta.Location = new System.Drawing.Point(1077, 624);
            this.btnCriarAlerta.Name = "btnCriarAlerta";
            this.btnCriarAlerta.Size = new System.Drawing.Size(160, 40);
            this.btnCriarAlerta.TabIndex = 11;
            this.btnCriarAlerta.Text = "CRIAR ALERTA";
            this.btnCriarAlerta.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 714);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "Alerts Application";
            this.tabControl1.ResumeLayout(false);
            this.viewTab.ResumeLayout(false);
            this.configureTab.ResumeLayout(false);
            this.configureTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage viewTab;
        private System.Windows.Forms.ListView listAlerts;
        private System.Windows.Forms.TabPage configureTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDescricaoAlerta;
        private System.Windows.Forms.TextBox txtBoxNomeAlerta;
        private System.Windows.Forms.ComboBox cbCondicao;
        private System.Windows.Forms.Label lblCondicao;
        private System.Windows.Forms.Label lblAdicionarParametro;
        private System.Windows.Forms.Label lblParametros;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label lblDado;
        private System.Windows.Forms.ComboBox cbTipoDado;
        private System.Windows.Forms.Button btnCriarAlerta;
    }
}

