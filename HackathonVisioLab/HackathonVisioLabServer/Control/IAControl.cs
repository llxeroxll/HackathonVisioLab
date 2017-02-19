using HackathonVisioLabServer.Model.IAAlgorithms;
using HackathonVisioLabServer.Model.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HackathonVisioLabServer.Utils.EstuturasBase;

namespace HackathonVisioLabServer.Control
{
    public class IAControl
    {
        public static List<int> BuscaGrupo(Cliente cliente)
        {
            return ClassificadorKNN.INSTANCE.buscaGrupo(cliente);
        }

        public static List<Produto> BuscaRecomendacao(Cliente cliente)
        {

            var produto_id = ClassificadorKNN.INSTANCE.buscaRecomendacao(cliente);

            List<Produto> produtos = new List<Produto>();

            foreach(var p in produto_id)
            {
                produtos.Add(ProdutoSqlite.getProduto(p));
            }

            return produtos;
        }
    }
}
