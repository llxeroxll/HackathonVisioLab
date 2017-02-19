using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HackathonVisioLabServer.Utils.EstuturasBase;
using HackathonVisioLabServer.Control;

namespace HackathonVisioLab.View
{
    public partial class RecomendacoesView : UserControl
    {
        Cliente cliente;
        List<Produto> produtos;
        int cont;
        public RecomendacoesView(Cliente cliente)
        {
            InitializeComponent();
            cont = 0;

            this.cliente = cliente;

            produtos = new List<Produto>();

            produtos = IAControl.BuscaRecomendacao(cliente);
            exibeRecomendacoes();

            List<Cliente> clientes = IAControl.BuscaGrupo(cliente);

            foreach (var c in clientes)
            {
                var item1 = new ListViewItem(new[] { c.proximidade + "", c.nome });
                listView1.Items.Add(item1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cont = (cont + 1) % produtos.Count;
            exibeRecomendacoes();
        }

        private void exibeRecomendacoes()
        {
            label1.Text = produtos[cont].nome;
            label2.Text = produtos[cont].tag;

            pictureBox1.Image = new Bitmap("imagens\\" + produtos[cont].id + ".jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cont--;

            if (cont == -1)
                cont = produtos.Count - 1;
            exibeRecomendacoes();
        }
    }
}
