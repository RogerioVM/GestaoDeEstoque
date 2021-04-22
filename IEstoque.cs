using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3
{
    interface IEstoque
    {
        // Métodos globais para gerenciamento e exibição dos itens e seus status.
        void Exibir();
        void AdicionarEntrada();
        void AdicionarSaida();
    }
}
