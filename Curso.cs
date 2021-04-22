using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3
{
    [System.Serializable]

    class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas no curso {nome}");
            Console.WriteLine("Digite a quantidade de vagas quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());

            // Garantia que a entrada não é um valor menor ou igual a zero
            if (entrada > 0)
            {
                vagas += entrada;
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
            Console.WriteLine($"Consumir vagas no curso {nome}");
            Console.WriteLine("Digite a quantidade de vagas que quer consumir: ");
            int entrada = int.Parse(Console.ReadLine());

            // Garantia que a saída não é um valor menor ou igual a zero
            if (entrada > 0)
            {
                vagas -= entrada;
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
            Console.WriteLine($"Vagas restantes: {vagas}");
            Console.WriteLine("=============================");
        }
    }
}
