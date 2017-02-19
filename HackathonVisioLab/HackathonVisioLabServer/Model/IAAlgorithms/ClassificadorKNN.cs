using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackathonVisioLabServer.Utils;
using static HackathonVisioLabServer.Utils.EstuturasBase;
using HackathonVisioLabServer.Model.Sqlite;

namespace HackathonVisioLabServer.Model.IAAlgorithms
{
    //Strategy para a interface IAInterface
    class ClassificadorKNN : IAInterface
    {
        public static ClassificadorKNN INSTANCE = new ClassificadorKNN();

        private ClassificadorKNN() { }

        public int calculaSimilaridade(Cliente c1, Cliente c2)
        { // Cakcula Escore de proximidade
            List<Compra> comprasC1 = CompraSqlite.getByClient(c1);
            List<Compra> comprasC2 = CompraSqlite.getByClient(c2);
            int score = 0;

            foreach (Compra com1 in comprasC1)
            {
                foreach (Compra com2 in comprasC2)
                {
                    if (com1.produto.id == com2.produto.id)
                    {
                        score++;
                        break;
                    }
                }
            }
            return score;
        }

        public List<int> buscaGrupo(Cliente cliente)//qtdMax = Quantidade máxima de pessoas no grupo
        {
            Dictionary<int, int> dic = new Dictionary<int, int>(); // Dicionario de Escores x Clientes
            List<Compra> comprasCliente = CompraSqlite.getByClient(cliente);

            foreach (Compra c in comprasCliente)
            {
                List<int> clientesMesmaCompra = CompraSqlite.getClientsByCompra(c.produto);
                foreach (int ids in clientesMesmaCompra)
                {
                    if (dic.ContainsKey(ids))
                    {
                        dic[ids]++;
                    }
                    else
                    {
                        dic.Add(ids, 1);
                    }
                }

            }
            dic.Remove(cliente.id);//Remover o proprio cliente da lista de mais proximos dele

            //Ordenar Clientes por escore comprasCliente
            //Dictionary<int, int> sortedDict = (Dictionary<int, int>)from entry in dic orderby entry.Value ascending select entry;
            var sortedDict = from pair in dic orderby pair.Value descending select pair;

            List<int> users = sortedDict.Select(kvp => kvp.Key).ToList();

            //retorna usuários mais próximos ordenados
            return users;

        }

        public List<int> buscaRecomendacao(Cliente cliente)
        {
            // Listar recomendações baseado no grupo de usuário.
            // As recomendações serão os produtos que os usuários mais próximos, ordenadamente, possuem e o usuário não possui.
            List<int> grupoCliente = buscaGrupo(cliente);
            List<Compra> comprasCliente = CompraSqlite.getByClient(cliente);
            List<int> conjuntoRecomendacoes = new List<int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();

            foreach (int i in grupoCliente) { // Listar produtos mais comprados pelo grupo e ordenalos
                List<Compra> listaProdutos = CompraSqlite.getByClient(i);
                foreach (Compra c in listaProdutos) {
                    if (dic.ContainsKey(c.produto.id))
                    {
                        dic[c.produto.id]++;
                    }
                    else {
                        dic.Add(c.produto.id, 1);
                    }
                }
            }

            //Dictionary<int, int> sortedDict = (Dictionary<int, int>)from entry in dic orderby entry.Value ascending select entry;

            //List<int> recomendationsSorted = sortedDict.Select(kvp => kvp.Value).ToList();

            var sortedDict = from pair in dic orderby pair.Value descending select pair;

            List<int> recomendationsSorted = sortedDict.Select(kvp => kvp.Key).ToList();

            for (int i = 0; i < recomendationsSorted.Count; i++) { //Verifica se o usuário já tem o produto que seria recomendado
                int neighborProd= recomendationsSorted.ElementAt(i);
                foreach (Compra c in comprasCliente) {
                    if (c.produto.id == neighborProd)
                    {
                        recomendationsSorted.Remove(i);
                        break;
                    }
                }
            }
            return recomendationsSorted;
        }

    }
}
