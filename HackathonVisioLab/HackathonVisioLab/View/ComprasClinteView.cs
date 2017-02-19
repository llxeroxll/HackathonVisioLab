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

namespace HackathonVisioLab.View
{
    public partial class ComprasClinteView : UserControl
    {

        private ListViewColumnSorter lvwColumnSorter;

        public ComprasClinteView()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            listView1.ListViewItemSorter = lvwColumnSorter;
        }
    }
}
