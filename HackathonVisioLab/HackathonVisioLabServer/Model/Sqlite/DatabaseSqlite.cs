using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace GerenciadorExames.Model.Sqlite
{
    class DatabaseSqlite
    {
        SQLiteCommand command;
        SQLiteTransaction tra;
        SQLiteConnection cnn;

        string fileDir;

        private static DatabaseSqlite instance;

        private DatabaseSqlite()
        {
            beginConnection(new FileInfo("db.sqlite3").FullName);
        }

        public static DatabaseSqlite Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseSqlite();
                }
                return instance;
            }
        }

        #region Abrir\fechar banco
        public void beginConnection(string fileName)
        {
            fileDir = fileName;
            cnn = new SQLiteConnection("Data Source = " + fileName);
        }

        public void endConnection()
        {
            cnn.Dispose();
            //cnn.Close();
            cnn = null;
            command = null;
        }
        #endregion

        #region iniciar\finalizar conexão
        public void openConnection()
        {
            cnn.Open();
            command = cnn.CreateCommand();
        }

        public void closeConnection()
        {
            command.Dispose();
            cnn.Close();
        }
        #endregion

        #region inicia\executar\finalizar operações

        public void beginTransaction()
        {
            tra = cnn.BeginTransaction();
        }

        public int executeNonQuery(string sql)
        {
            command.CommandText = sql;
            return command.ExecuteNonQuery();
        }

        public void commit()
        {
            tra.Commit();
            tra.Dispose();
        }

        #endregion

        public DataTable executeQuery(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                SQLiteCommand command = cnn.CreateCommand();
                command.CommandText = sql;
                SQLiteDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                command.Dispose();
                reader.Dispose();
                reader.Close();
                reader = null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dt;
        }
    }
}
