using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3
{
    [System.Serializable]
    abstract class Produto
    {
        // Classe modelo para as filhas utilizarem a herança.
        public string nome;
        public float preco;
    }
}
