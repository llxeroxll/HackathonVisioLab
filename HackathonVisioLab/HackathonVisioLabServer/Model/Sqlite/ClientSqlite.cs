﻿using GerenciadorExames.Model.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HackathonVisioLabServer.Utils.EstuturasBase;

namespace HackathonVisioLabServer.Model.Sqlite
{
    class ClientSqlite
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
        
        public static Client getClient(string cpf, string senha)
        {
            string query = string.Format("SELECT * FROM Cliente WHERE CPF LIKE \'{0}\' AND Senha LIKE \'{1}\';", cpf, senha);
            var dt = executeQuery(query);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];            

            Client cliente = new Client();

            cliente.id = int.Parse(row[0].ToString());
            cliente.cpf = row[1].ToString();
            cliente.nome = row[2].ToString();

            return cliente;
        }

        public static Client getCliente(int id)
        {
            string query = string.Format("SELECT * FROM Cliente WHERE ID = {0};", id);
            var dt = executeQuery(query);
            
            DataRow row = dt.Rows[0];

            Client client = new Client();

            client.id = int.Parse(row[0].ToString());
            client.cpf = row[1].ToString();
            client.nome = row[2].ToString();

            return client;
        }
    }
}