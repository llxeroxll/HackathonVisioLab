using GerenciadorExames.Model.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using static HackathonVisioLabServer.Utils.EstuturasBase;


namespace HackathonVisioLabServer.Model.Sqlite
{
    class ProdutoSqlite
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

        public static Produto getProduto(int id)
        {
            string query = string.Format("SELECT * FROM Produto WHERE ID = {0};", id);
            var dt = executeQuery(query);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            Produto produto = new Produto();

            produto.id = int.Parse(row[0].ToString());
            produto.nome = row[1].ToString();
            produto.tag = getTag(int.Parse(row[2].ToString()));
            produto.preco = double.Parse(row[3].ToString());


            return produto;
        }

        public static String getTag(int id)
        {
            string query = string.Format("SELECT * FROM Tag WHERE ID = {0};", id);
            var dt = executeQuery(query);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            String tag = row[1].ToString();

            return tag;
        }



    }
}
