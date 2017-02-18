using HackathonVisioLabServer.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackathonVisioLab.View
{
    public partial class ClientLogin : Form
    {
        public ClientLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(textBox2.Text);

            //validar com o servidor
            var isClient = ClienteControl.BuscaCliente(textBox1.Text, textBox2.Text);
            if(isClient != null)
            {
                this.Visible = false;
                new Main(isClient).ShowDialog();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("CPF ou senha incorretos", "Falha no login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
