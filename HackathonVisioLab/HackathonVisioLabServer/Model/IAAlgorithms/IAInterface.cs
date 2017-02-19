using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HackathonVisioLabServer.Utils.EstuturasBase;

namespace HackathonVisioLabServer.Model.IAAlgorithms
{
    //Padrão Strategy para modularização do método de machine learning
    interface IAInterface
    {
        List<int>  buscaRecomendacao(Cliente cliente);

        List<int> buscaGrupo(Cliente cliente);// Retorna Lista de PK de clientes
    }
}
