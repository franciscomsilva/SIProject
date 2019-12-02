using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALERTS_APPLICATION
{
    public partial class Main : Form
    {
        private LinkedList<Parametro> parametros;


        public Main()
        {
            InitializeComponent();


        }

        private void Main_Load(object sender, EventArgs e)
        {

            parametros = new LinkedList<Parametro>();



            cbTipoDado.DataSource = Enum.GetValues(typeof(TipoDado));
            cbTipoDado.SelectedItem = TipoDado.TEMPERATURA;

            cbCondicao.SelectedIndex = 0;

            lvParametros.View = View.Details;
            lvParametros.Columns.Add("Condição");
            lvParametros.Columns.Add("Tipo de Dado");
            lvParametros.Columns.Add("Valor");

        }



        private void btnAdicionar_Click(object sender, EventArgs e)
        {
         

            string condicao = cbCondicao.SelectedItem.ToString();

            TipoDado tipoDado =(TipoDado) cbTipoDado.SelectedItem;


            if(nrValor.Value == 0)
            {
                MessageBox.Show("Valor obrigatório!", "Valor obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            foreach(Parametro parametroI in parametros)
            {
                item = new ListViewItem(new string[] { parametroI.Condicao, parametroI.TipoDado.ToString(), parametroI.Valor.ToString() });
                lvParametros.Items.Add(item);
            }
         

            MessageBox.Show("Parametro Adicionado com sucesso!");

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}