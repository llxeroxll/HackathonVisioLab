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

        public Main(Cliente cliente)
        {
           InitializeComponent();

            this.cliente = cliente;
        }

        private void minhasComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            comprasView = new ComprasClinteView();
            comprasView.Size = panel1.Size;

            panel1.Controls.Add(comprasView);
            comprasView.Dock = DockStyle.Fill;
        }
    }
}
