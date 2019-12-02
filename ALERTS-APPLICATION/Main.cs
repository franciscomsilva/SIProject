using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALERTS_APPLICATION
{
    public partial class Main : Form
    {
        private LinkedList<Parametro> parametros;
        private ErrorProvider errorProvider;
        private LinkedList<Alerta> alertas;

        private static string FILE_PATH = "FICHEIRO_CONFIGURACOES_ALERTAS.data";


        public Main()
        {
            InitializeComponent();



        }

        private void Main_Load(object sender, EventArgs e)
        {

            parametros = new LinkedList<Parametro>();
            alertas = new LinkedList<Alerta>();



            cbTipoDado.DataSource = Enum.GetValues(typeof(TipoDado));
            cbTipoDado.SelectedItem = TipoDado.TEMPERATURA;

            cbCondicao.SelectedIndex = 0;

            lvParametros.View = View.Details;
            lvParametros.Columns.Add("Condição");
            lvParametros.Columns.Add("Tipo de Dado");
            lvParametros.Columns.Add("Valor");

            lvAlertas.View = View.Details;
            lvAlertas.Columns.Add("Número de Paramêtros");
            lvAlertas.Columns.Add("Descrição");
            lvAlertas.Columns.Add("Data de Criação");
            lvAlertas.Columns.Add("Ativado");



            errorProvider = new ErrorProvider();

            errorProvider.SetIconAlignment(txtDescricao, ErrorIconAlignment.MiddleRight);
            errorProvider.SetIconPadding(txtDescricao, 3);
            errorProvider.SetIconAlignment(nrValor, ErrorIconAlignment.MiddleRight);
            errorProvider.SetIconPadding(nrValor, 3);
            errorProvider.SetIconAlignment(btnAdicionar, ErrorIconAlignment.MiddleRight);
            errorProvider.SetIconPadding(btnAdicionar, 3);



            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError;


            /*VERIFICA SE O FICHEIRO COM AS CONFIGURAÇÕES DOS ALERTAS EXISTEM*/
            if (File.Exists(FILE_PATH))
            {
                try
                {
                    string json = File.ReadAllText(FILE_PATH);
                    alertas = JsonConvert.DeserializeObject<LinkedList<Alerta>>(json);

                    Console.WriteLine("Leitura do ficheiro de alertas");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error reading file => " + ex.Message);
                }

                ListViewItem item = null;


                /*CARREGA O ALERTAS NA LISTA*/
                foreach (Alerta alertaI in alertas)
                {
                    item = new ListViewItem(new string[] { alertaI.Parametros.Count.ToString(), alertaI.Descricao, alertaI.DataCriacao.ToShortDateString(), alertaI.Ativado.ToString() });
                    lvAlertas.Items.Add(item);
                }


            }
        }



        private void btnAdicionar_Click(object sender, EventArgs e)
        {


            string condicao = cbCondicao.SelectedItem.ToString();

            TipoDado tipoDado = (TipoDado)cbTipoDado.SelectedItem;



            decimal valor = nrValor.Value;

            Parametro parametro = new Parametro
            {
                Condicao = condicao,

                TipoDado = tipoDado,
                Valor = valor
            };

            parametros.AddLast(parametro);

            ListViewItem item = null;



            lvParametros.Items.Clear();
            foreach (Parametro parametroI in parametros)
            {
                item = new ListViewItem(new string[] { parametroI.Condicao, parametroI.TipoDado.ToString(), parametroI.Valor.ToString() });
                lvParametros.Items.Add(item);
            }



        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCriarAlerta_Click(object sender, EventArgs e)
        {
            errorProvider.SetError(btnAdicionar, "");
            errorProvider.SetError(txtDescricao, "");


            if (txtDescricao.Text.Length <= 0)
            {
                errorProvider.SetError(txtDescricao, "Descrição obrigatória!");
                return;
            }

            if (parametros.Count <= 0)
            {
                errorProvider.SetError(btnAdicionar, "É necessário pelo menos 1 parâmetro para criar um alerta!");
                return;
            }



            /*CRIAR O ALERTA*/
            Alerta alerta = new Alerta
            {
                Parametros = parametros,
                Descricao = txtDescricao.Text,
                UserID = 1,
                Ativado = 1,
                DataCriacao = DateTime.UtcNow
            };

            guardarAlerta(alerta);


            /*LIMPA OS DADOS*/
            txtDescricao.Clear();
            nrValor.Value = 0;
            cbTipoDado.SelectedIndex = 0;
            cbCondicao.SelectedIndex = 0;

            lvParametros.Items.Clear();

            parametros.Clear();



        }


        private void guardarAlerta(Alerta alerta)
        {
            if (alerta == null)
            {
                return;
            }

            alertas.AddLast(alerta);

            /*ATUALIZA LISTA*/
            ListViewItem item = null;

            lvAlertas.Items.Clear();
            /*CARREGA O ALERTAS NA LISTA*/
            foreach (Alerta alertaI in alertas)
            {
                item = new ListViewItem(new string[] { alertaI.Parametros.Count.ToString(), alertaI.Descricao, alertaI.DataCriacao.ToShortDateString(), alertaI.Ativado.ToString() });
                lvAlertas.Items.Add(item);
            }



            /*SERIALIZAR E GUARDAR NUM FICHEIRO*/
            string json = JsonConvert.SerializeObject(alertas);

            try
            {
                File.WriteAllText(FILE_PATH, json);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void lvParametros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLimparAlertas_Click(object sender, EventArgs e)
        {
            alertas.Clear();
            lvAlertas.Items.Clear();

            /*APAGA O FICHEIRO QUE GUARDA OS ALERTAS*/

            if (File.Exists(FILE_PATH))
            {
                try
                {
                    File.Delete(FILE_PATH);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting file => " + ex.Message);
                }
            }
        }
    }
}