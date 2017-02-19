using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HackathonVisioLabServer.Utils.EstuturasBase;

namespace HackathonVisioLab.View
{
    public partial class Main : Form
    {
        Cliente cliente;

        ComprasClinteView comprasView;
        RecomendacoesView recomendacoes;

        public Main(Cliente cliente)
        {
           InitializeComponent();

            this.Text = cliente.nome;

            this.cliente = cliente;
        }

        private void minhasComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            comprasView = new ComprasClinteView(cliente);
            comprasView.Size = panel1.Size;

            panel1.Controls.Add(comprasView);
            comprasView.Dock = DockStyle.Fill;
        }

        private void recomendaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            recomendacoes = new RecomendacoesView(cliente);
            recomendacoes.Size = panel1.Size;

            panel1.Controls.Add(recomendacoes);
            recomendacoes.Dock = DockStyle.Fill;
        }
    }
}
