using System;
using System.Collections.Generic;

class Program
{
    class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public int Ano {get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }

        public Produto(int codigo, string nome, int quantidade, decimal valor, int ano, string autor, string genero)
        {
            Codigo = codigo;
            Nome = nome;
            Quantidade = quantidade;
            Valor = valor;
            Ano = ano;
            Autor = autor;
            Genero = genero;
            
        }
    }

    class Estoque
    {
        private List<Produto> produtos = new List<Produto>();

        public void NovoProduto(int codigo, string nome, int quantidade, decimal valor, int ano, string autor, string genero)
        {
            Produto produto = new Produto(codigo, nome, quantidade, valor, ano, autor, genero);
            produtos.Add(produto);
        }

        public void ListarProdutos()
        {
            foreach (var produto in produtos)
            {
                Console.WriteLine("====================");
                Console.WriteLine($"Código: {produto.Codigo}");
                Console.WriteLine($"Nome: {produto.Nome}");
                Console.WriteLine($"Quantidade: {produto.Quantidade}");
                Console.WriteLine($"Valor: {produto.Valor}");
                Console.WriteLine($"Ano: {produto.Ano}");
                Console.WriteLine($"Autor: {produto.Autor}");
                Console.WriteLine($"Gênero: {produto.Genero}");
                Console.WriteLine("====================\n");
            }
        }

        public void RemoverProduto(int codigo)
        {
            produtos.RemoveAll(produto => produto.Codigo == codigo);
        }

        public void EntradaEstoque(int codigo, int quantidade)
        {
            Produto produto = produtos.Find(p => p.Codigo == codigo);
            if (produto != null)
            {
                produto.Quantidade += quantidade;
            }
        }

        public void SaidaEstoque(int codigo, int quantidade)
        {
            Produto produto = produtos.Find(p => p.Codigo == codigo);
            if (produto != null)
            {
                if (produto.Quantidade >= quantidade)
                {
                    produto.Quantidade -= quantidade;
                }
                else
                {
                    Console.WriteLine("Quantidade insuficiente em estoque.");
                }
            }
        }
    }

    static void ExibirMenu()
    {
        Console.WriteLine("====================\n[1] Novo Produto\n[2] Listar Produtos\n[3] Remover Produto\n[4] Entrada de Estoque\n[5] Saída de Estoque\n[0] Sair da aplicação\n====================\n");
    }

    public static void Main(string[] args)
    {
        Estoque estoque = new Estoque();

        while (true)
        {
            ExibirMenu();
            Console.WriteLine("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Digite o código do produto: ");
                    int codigo = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o nome do produto: ");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Digite a quantidade em estoque: ");
                    int quantidade = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o valor: ");
                    decimal valor = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o ano da obra: ");
                    int ano = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o nome do autor: ");
                    string autor = Console.ReadLine();
                    Console.WriteLine("Digite o gênero literário: ");
                    string genero = Console.ReadLine();
                    estoque.NovoProduto(codigo, nome, quantidade, valor, ano, autor, genero);
                    Console.WriteLine("Livro adicionado!");
                    break;

                case "2":
                    Console.Clear();
                    estoque.ListarProdutos();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Digite o código do produto a ser removido: ");
                    int codigoRemover = int.Parse(Console.ReadLine());
                    estoque.RemoverProduto(codigoRemover);
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Digite o código do produto: ");
                    int codigoEntrada = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a quantidade a ser adicionada ao estoque: ");
                    int quantidadeEntrada = int.Parse(Console.ReadLine());
                    estoque.EntradaEstoque(codigoEntrada, quantidadeEntrada);
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("Digite o código do produto: ");
                    int codigoSaida = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a quantidade a ser retirada do estoque: ");
                    int quantidadeSaida = int.Parse(Console.ReadLine());
                    estoque.SaidaEstoque(codigoSaida, quantidadeSaida);
                    break;

                case "0":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção inválida. Escolha novamente.");
                    break;
            }
        }
    }
}