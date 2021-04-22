using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3
{
    [System.Serializable]
    class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no estoque do produto {nome}");
            Console.WriteLine("Digite a quantidade que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());

            // Garantir que seja um valor positivo para entrar no estoque.
            if(entrada > 0)
            {
                estoque += entrada;
                Console.WriteLine("Entrada registrada");
                Console.ReadLine();
            } else
            {
                Console.WriteLine("Valor inválido, aperte ENTER para retornar!");
                Console.ReadLine();
            }
            
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saída no estoque do produto {nome}");
            Console.WriteLine("Digite a quantidade que você quer dar baixa: ");
            int saida = int.Parse(Console.ReadLine());

            // Garantir que seja um número positivo para sair o produto do estoque
            if (saida > 0)
            {
                estoque -= saida;
                Console.WriteLine("Saída registrada");
                Console.ReadLine();
            } else
            {
                Console.WriteLine("Valor inválido, aperte ENTER para retornar!");
                Console.ReadLine();
            }

        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Estoque: {estoque}");
            Console.WriteLine("=============================");
        }
    }
}
