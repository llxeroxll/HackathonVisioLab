using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HackathonVisioLab.Utils;
using static HackathonVisioLabServer.Utils.EstuturasBase;
using HackathonVisioLabServer.Utils;
using HackathonVisioLabServer.Control;

namespace HackathonVisioLab.View
{
    public partial class ComprasClinteView : UserControl
    {

        private ListViewColumnSorter lvwColumnSorter;
        private Cliente cliente;
        

        public ComprasClinteView(Cliente cliente)
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            listView1.ListViewItemSorter = lvwColumnSorter;
            this.cliente = cliente;

            initList();
        }

        private void initList()
        {
            List<Compra> compras = CompraControl.BuscaPorCliente(cliente);

            foreach(var compra in compras)
            {
                string data = compra.horario.ToString("dd-MM-yyyy HH:MM");
                var item1 = new ListViewItem(new[] { data, compra.produto.nome, compra.produto.tag, compra.produto.preco.ToString("F2") });
                listView1.Items.Add(item1);
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView myListView = (ListView)sender;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            myListView.Sort();
        }
    }
}
