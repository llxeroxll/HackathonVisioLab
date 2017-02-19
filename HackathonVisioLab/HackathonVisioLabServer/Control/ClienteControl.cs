﻿using HackathonVisioLabServer.Model.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HackathonVisioLabServer.Utils.EstuturasBase;

namespace HackathonVisioLabServer.Control
{
    public class ClienteControl
    {
        public static Cliente BuscaCliente(string cpf, string senha)
        {
            return ClienteSqlite.getCliente(cpf, senha);
        }
    }
}
