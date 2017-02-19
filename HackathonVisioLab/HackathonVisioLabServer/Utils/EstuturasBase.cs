using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonVisioLabServer.Utils
{
    public class EstuturasBase
    {
        public class Cliente
        {
            public int id;
            public string cpf;
            public string nome;

            public int proximidade;
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
            public Cliente cliente;
            public Produto produto;
        }
    }
}
