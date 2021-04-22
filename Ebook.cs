using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3
{
    [System.Serializable]

    class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;
        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Não é possível dar entrada física no estoque de um E-book !");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar venda no E-book {nome}");
            Console.WriteLine("Digite a quantidade de vendas que você quer dar entrada: ");
            int saida = int.Parse(Console.ReadLine());

            // Garantia que a quantidade de vendas não seja um valor menor ou igual a zero
            if(saida > 0)
            {
            vendas += saida;
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
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vendas: {vendas}");
            Console.WriteLine("=============================");
        }
    }
}
