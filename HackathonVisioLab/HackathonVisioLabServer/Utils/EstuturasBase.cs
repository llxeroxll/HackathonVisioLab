using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonVisioLabServer.Utils
{
    public class EstuturasBase
    {
        public class Client
        {
            public int id;
            public string cpf;
            public string nome;


        }

        public class Produto
        {
            public int id;
            public string nome;
            public string tag;
            public double preco;
        }

        public class Compra
        {
            public int id;
            public DateTime horario;
            public Client cliente;
            public Produto produto;
        }
    }
}
