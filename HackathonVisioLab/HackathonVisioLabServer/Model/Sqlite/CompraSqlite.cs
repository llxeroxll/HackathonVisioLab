using GerenciadorExames.Model.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using static HackathonVisioLabServer.Utils.EstuturasBase;

namespace HackathonVisioLabServer.Model.Sqlite
{
    class CompraSqlite
    {
        #region executeQuery/NonQuery


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
        #endregion

        //Busca todas as compras do clinte pelo objeto cliente
        public static List<Compra> getByClient(Cliente client)
        {
            string query = string.Format("SELECT * FROM Compra WHERE ID_cliente = {0};", client.id);
            var dt = executeQuery(query);

            List<Compra> compras = new List<Compra>();

            foreach (DataRow row in dt.Rows)
            {
                Compra compra = new Compra();

                compra.id = int.Parse(row[0].ToString());
                compra.cliente = ClienteSqlite.getCliente(int.Parse(row[1].ToString()));
                compra.produto = ProdutoSqlite.getProduto(int.Parse(row[2].ToString()));
                DateTime.TryParse(row[3].ToString(), out compra.horario);
            }

            return compras;
        }

        //Busca todas as compras do cliente pela PK id
        public static List<Compra> getByClient(int clientId)
        {
            string query = string.Format("SELECT * FROM Compra WHERE ID_cliente = {0};", clientId);
            var dt = executeQuery(query);

            List<Compra> compras = new List<Compra>();

            foreach (DataRow row in dt.Rows)
            {
                Compra compra = new Compra();

                compra.id = int.Parse(row[0].ToString());
                compra.cliente = ClienteSqlite.getCliente(int.Parse(row[1].ToString()));
                compra.produto = ProdutoSqlite.getProduto(int.Parse(row[2].ToString()));
                DateTime.TryParse(row[3].ToString(), out compra.horario);
            }

            return compras;
        }

        //Retorna todos os clientes que compraram o produto parâmetro de entrada
        public static List<int> getClientsByCompra(Produto pro)
        {
            string query = string.Format("SELECT * FROM Compra WHERE ID_produto = {0};", pro.id);
            var dt = executeQuery(query);

            List<int> clientes = new List<int>();

            foreach (DataRow row in dt.Rows)
            {
                clientes.Add(int.Parse(row[1].ToString());
            }

            return clientes;
        }
    }
}
