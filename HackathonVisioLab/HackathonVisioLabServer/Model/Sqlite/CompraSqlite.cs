using GerenciadorExames.Model.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using static HackathonVisioLabServer.Utils.EstuturasBase;

namespace HackathonVisioLabServer.Model.Sqlite
{
    class CompraSqlite
    {
        private static int executeNonQuery(string query)
        {
            DatabaseSqlite db = DatabaseSqlite.Instance;

            db.openConnection();
            db.beginTransaction();
            int ret = db.executeNonQuery(query);
            db.commit();
            db.closeConnection();
            return ret;
        }

        private static DataTable executeQuery(string query)
        {
            DatabaseSqlite db = DatabaseSqlite.Instance;

            db.openConnection();
            var ret = db.executeQuery(query);
            db.closeConnection();
            return ret;
        }

        public static List<Compra> getByClient(Client client)
        {
            string query = string.Format("SELECT * FROM Compra WHERE ID_cliente = {0};", client.id);
            var dt = executeQuery(query);

            List<Compra> compras = new List<Compra>();

            foreach (DataRow row in dt.Rows)
            {
                Compra compra = new Compra();

                compra.id = int.Parse(row[0].ToString());
                compra.cliente = ClientSqlite.getCliente(int.Parse(row[1].ToString()));
                compra.produto = ProdutoSqlite.getProduto(int.Parse(row[2].ToString()));
                DateTime.TryParse(row[3].ToString(), out compra.horario);
            }

            return compras;
        }
    }
}
