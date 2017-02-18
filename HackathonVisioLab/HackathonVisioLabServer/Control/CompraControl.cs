using HackathonVisioLabServer.Model.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HackathonVisioLabServer.Utils.EstuturasBase;

namespace HackathonVisioLabServer.Control
{
    public class CompraControl
    {
        public static List<Compra> BuscaPorCliente(Client cliente)
        {
            return CompraSqlite.getByClient(cliente);
        }
    }
}
