using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Projeto3
{
    [System.Serializable]
    class Program
    {
        enum Menu
        {
            Adicionar = 1,
            Listar,
            Entrada,
            Saida,
            Remover,
            Sair
        }

        static List<IEstoque> produtos = new List<IEstoque>(); // variavel global para armazenar os produtos.
        static void Main(string[] args)
        {
            Carregar();

            bool escolheuSair = false;
            while (!escolheuSair)
            {
                Console.WriteLine("------------- Gerenciamento de estoque (fictício) ------------------\n");
                Console.WriteLine("Escolha uma das opções abaixo: \n");
                Console.WriteLine("1-Adicionar\n2-Listar\n3-Entrada\n4-Saída\n5-Remover\n6-Sair\n");

                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);

                if (opInt > 0 || opInt < 7)
                {

                    Menu escolha = (Menu)opInt;
                    switch (escolha)
                    {
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }

                }
                else
                {
                    escolheuSair = true;
                }
                Console.Clear();
            }
        }

        static void Listagem()
        {
            Console.WriteLine("Lista de produtos:");

            // id dos produtos.
            int id = 1;

            foreach (IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + id);
                produto.Exibir();
                id++;
            }
            Console.ReadLine();
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer remover:");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }

        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer dar entrada:");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }

        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer dar baixa:");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }
        static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produto ");
            Console.WriteLine("1-Produto Físico\n2-E-book\n3-Curso\n");

            string opStr = Console.ReadLine();
            int escolhaInt = int.Parse(opStr);

            switch (escolhaInt)
            {
                case 1:
                    CadastrarPFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }
        }

        static void CadastrarPFisico()
        {
            Console.WriteLine("Cadastrando Produto Físico.");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());

            if (nome == "" || preco <= 0 || frete <= 0)
            {
                Console.WriteLine("Valor(es) invalidos!");
                Console.ReadLine();
            }
            else
            {
                ProdutoFisico pfisico = new ProdutoFisico(nome, preco, frete);
                produtos.Add(pfisico);
                Salvar();

            }
        }

        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando Ebook: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            if (nome == "" || preco <= 0 || autor == "")
            {
                Console.WriteLine("Valor(es) invalidos!");
                Console.ReadLine();
            }
            else
            {
                Ebook ebook = new Ebook(nome, preco, autor);
                produtos.Add(ebook);
                Salvar();
            }
        }

        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando Ebook: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            if (nome == "" || preco <= 0 || autor == "")
            {
                Console.WriteLine("Valor(es) invalidos!");
                Console.ReadLine();
            }
            else
            {
                Curso curso = new Curso(nome, preco, autor);
                produtos.Add(curso);
                Salvar();
            }

        }

        static void Salvar()
        {
            // Gerando um arquivo binário para salvar os dados.

            FileStream stream = new FileStream("produtos.txt", FileMode.OpenOrCreate);

            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();
        }

        static void Carregar()
        {
            //Carregando arquivos do salvos do método Salvar.

            FileStream stream = new FileStream("produtos.txt", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);

                if (produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch (Exception)
            {
                produtos = new List<IEstoque>();
            }

            stream.Close();
        }
    }
}
