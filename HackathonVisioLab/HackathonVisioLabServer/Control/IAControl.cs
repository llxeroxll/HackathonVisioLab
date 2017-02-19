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
        public static List<Cliente> BuscaGrupo(Cliente cliente)
        {

            var id_clientes = ClassificadorKNN.INSTANCE.buscaGrupo(cliente);

            List<Cliente> clientes = new List<Cliente>();

            foreach (var c in id_clientes)
            {
                var aux = ClienteSqlite.getCliente(c);

                aux.proximidade = ClassificadorKNN.INSTANCE.calculaSimilaridade(cliente, aux);

                clientes.Add(aux);
            }
            
            return clientes;
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
