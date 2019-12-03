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
            this.alertasTab = new System.Windows.Forms.TabPage();
            this.btnLimparAlertas = new System.Windows.Forms.Button();
            this.lvAlertas = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.criarTab = new System.Windows.Forms.TabPage();
            this.lvParametros = new System.Windows.Forms.ListView();
            this.nrValor = new System.Windows.Forms.NumericUpDown();
            this.lblValor = new System.Windows.Forms.Label();
            this.btnCriarAlerta = new System.Windows.Forms.Button();
            this.lblAdicionarParametro = new System.Windows.Forms.Label();
            this.lblParametros = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.lblDado = new System.Windows.Forms.Label();
            this.cbTipoDado = new System.Windows.Forms.ComboBox();
            this.lblCondicao = new System.Windows.Forms.Label();
            this.cbCondicao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDescricaoAlerta = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.tabAlertasGerados = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.alertasTab.SuspendLayout();
            this.criarTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrValor)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.alertasTab);
            this.tabControl1.Controls.Add(this.tabAlertasGerados);
            this.tabControl1.Controls.Add(this.criarTab);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1334, 711);
            this.tabControl1.TabIndex = 0;
            // 
            // alertasTab
            // 
            this.alertasTab.Controls.Add(this.btnLimparAlertas);
            this.alertasTab.Controls.Add(this.lvAlertas);
            this.alertasTab.Controls.Add(this.label2);
            this.alertasTab.Location = new System.Drawing.Point(4, 22);
            this.alertasTab.Name = "alertasTab";
            this.alertasTab.Padding = new System.Windows.Forms.Padding(3);
            this.alertasTab.Size = new System.Drawing.Size(1326, 685);
            this.alertasTab.TabIndex = 0;
            this.alertasTab.Text = "Alertas";
            this.alertasTab.UseVisualStyleBackColor = true;
            // 
            // btnLimparAlertas
            // 
            this.btnLimparAlertas.Location = new System.Drawing.Point(23, 79);
            this.btnLimparAlertas.Name = "btnLimparAlertas";
            this.btnLimparAlertas.Size = new System.Drawing.Size(125, 23);
            this.btnLimparAlertas.TabIndex = 19;
            this.btnLimparAlertas.Text = "LIMPAR ALERTAS";
            this.btnLimparAlertas.UseVisualStyleBackColor = true;
            this.btnLimparAlertas.Click += new System.EventHandler(this.btnLimparAlertas_Click);
            // 
            // lvAlertas
            // 
            this.lvAlertas.HideSelection = false;
            this.lvAlertas.Location = new System.Drawing.Point(23, 110);
            this.lvAlertas.Name = "lvAlertas";
            this.lvAlertas.Size = new System.Drawing.Size(1273, 531);
            this.lvAlertas.TabIndex = 18;
            this.lvAlertas.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 45);
            this.label2.TabIndex = 17;
            this.label2.Text = "LISTA DE ALERTAS";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // criarTab
            // 
            this.criarTab.Controls.Add(this.lvParametros);
            this.criarTab.Controls.Add(this.nrValor);
            this.criarTab.Controls.Add(this.lblValor);
            this.criarTab.Controls.Add(this.btnCriarAlerta);
            this.criarTab.Controls.Add(this.lblAdicionarParametro);
            this.criarTab.Controls.Add(this.lblParametros);
            this.criarTab.Controls.Add(this.btnAdicionar);
            this.criarTab.Controls.Add(this.lblDado);
            this.criarTab.Controls.Add(this.cbTipoDado);
            this.criarTab.Controls.Add(this.lblCondicao);
            this.criarTab.Controls.Add(this.cbCondicao);
            this.criarTab.Controls.Add(this.label1);
            this.criarTab.Controls.Add(this.lblDescricaoAlerta);
            this.criarTab.Controls.Add(this.txtDescricao);
            this.criarTab.Location = new System.Drawing.Point(4, 22);
            this.criarTab.Name = "criarTab";
            this.criarTab.Size = new System.Drawing.Size(1326, 685);
            this.criarTab.TabIndex = 1;
            this.criarTab.Text = "Criar";
            this.criarTab.UseVisualStyleBackColor = true;
            // 
            // lvParametros
            // 
            this.lvParametros.HideSelection = false;
            this.lvParametros.Location = new System.Drawing.Point(31, 317);
            this.lvParametros.Name = "lvParametros";
            this.lvParametros.Size = new System.Drawing.Size(1278, 284);
            this.lvParametros.TabIndex = 15;
            this.lvParametros.UseCompatibleStateImageBehavior = false;
            this.lvParametros.SelectedIndexChanged += new System.EventHandler(this.lvParametros_SelectedIndexChanged);
            // 
            // nrValor
            // 
            this.nrValor.DecimalPlaces = 2;
            this.nrValor.Location = new System.Drawing.Point(116, 233);
            this.nrValor.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nrValor.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nrValor.Name = "nrValor";
            this.nrValor.Size = new System.Drawing.Size(120, 20);
            this.nrValor.TabIndex = 14;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(28, 235);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(31, 13);
            this.lblValor.TabIndex = 13;
            this.lblValor.Text = "Valor";
            this.lblValor.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // btnCriarAlerta
            // 
            this.btnCriarAlerta.Location = new System.Drawing.Point(1077, 624);
            this.btnCriarAlerta.Name = "btnCriarAlerta";
            this.btnCriarAlerta.Size = new System.Drawing.Size(160, 40);
            this.btnCriarAlerta.TabIndex = 11;
            this.btnCriarAlerta.Text = "CRIAR ALERTA";
            this.btnCriarAlerta.UseVisualStyleBackColor = true;
            this.btnCriarAlerta.Click += new System.EventHandler(this.btnCriarAlerta_Click);
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
            // 
            // lblParametros
            // 
            this.lblParametros.AutoSize = true;
            this.lblParametros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParametros.Location = new System.Drawing.Point(24, 293);
            this.lblParametros.Name = "lblParametros";
            this.lblParametros.Size = new System.Drawing.Size(163, 20);
            this.lblParametros.TabIndex = 9;
            this.lblParametros.Text = "Pâmetros do Alerta";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(118, 267);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 7;
            this.btnAdicionar.Text = "ADICIONAR";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
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
            // cbTipoDado
            // 
            this.cbTipoDado.FormattingEnabled = true;
            this.cbTipoDado.Location = new System.Drawing.Point(118, 204);
            this.cbTipoDado.Name = "cbTipoDado";
            this.cbTipoDado.Size = new System.Drawing.Size(121, 21);
            this.cbTipoDado.TabIndex = 5;
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
            // lblDescricaoAlerta
            // 
            this.lblDescricaoAlerta.AutoSize = true;
            this.lblDescricaoAlerta.Location = new System.Drawing.Point(25, 89);
            this.lblDescricaoAlerta.Name = "lblDescricaoAlerta";
            this.lblDescricaoAlerta.Size = new System.Drawing.Size(55, 13);
            this.lblDescricaoAlerta.TabIndex = 1;
            this.lblDescricaoAlerta.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(118, 89);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(448, 20);
            this.txtDescricao.TabIndex = 0;
            // 
            // tabAlertasGerados
            // 
            this.tabAlertasGerados.Location = new System.Drawing.Point(4, 22);
            this.tabAlertasGerados.Name = "tabAlertasGerados";
            this.tabAlertasGerados.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlertasGerados.Size = new System.Drawing.Size(1326, 685);
            this.tabAlertasGerados.TabIndex = 2;
            this.tabAlertasGerados.Text = "Alertas Gerados";
            this.tabAlertasGerados.UseVisualStyleBackColor = true;
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
            this.alertasTab.ResumeLayout(false);
            this.alertasTab.PerformLayout();
            this.criarTab.ResumeLayout(false);
            this.criarTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrValor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage alertasTab;
        private System.Windows.Forms.TabPage criarTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDescricaoAlerta;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.ComboBox cbCondicao;
        private System.Windows.Forms.Label lblCondicao;
        private System.Windows.Forms.Label lblAdicionarParametro;
        private System.Windows.Forms.Label lblParametros;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label lblDado;
        private System.Windows.Forms.ComboBox cbTipoDado;
        private System.Windows.Forms.Button btnCriarAlerta;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.NumericUpDown nrValor;
        private System.Windows.Forms.ListView lvParametros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvAlertas;
        private System.Windows.Forms.Button btnLimparAlertas;
        private System.Windows.Forms.TabPage tabAlertasGerados;
    }
}

