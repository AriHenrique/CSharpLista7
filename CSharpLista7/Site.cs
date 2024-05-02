using System;

namespace CSharpLista7
{
    public class Site
    {
        public string Nome { get; set; }
        public string Link { get; set; }

        public Site(string nome, string link)
        {
            Nome = nome;
            Link = link;
        }
    }

    public class Celula
    {
        public Site Elemento { get; set; }
        public Celula Proximo { get; set; }

        public Celula(Site elemento)
        {
            Elemento = elemento;
            Proximo = null;
        }
    }

    public class Lista
    {
        private Celula inicio;

        public Lista()
        {
            inicio = null;
        }

        public void InserirInicio(Site site)
        {
            Celula nova = new Celula(site) { Proximo = inicio };
            inicio = nova;
        }

        public void InserirFim(Site site)
        {
            Celula nova = new Celula(site);
            if (inicio == null)
            {
                inicio = nova;
            }
            else
            {
                Celula atual = inicio;
                while (atual.Proximo != null)
                {
                    atual = atual.Proximo;
                }

                atual.Proximo = nova;
            }
        }

        public void InserirPosicao(Site site, int posicao)
        {
            Celula nova = new Celula(site);
            if (posicao == 0)
            {
                nova.Proximo = inicio;
                inicio = nova;
            }
            else
            {
                Celula atual = inicio;
                for (int i = 0; i < posicao - 1 && atual != null; i++)
                {
                    atual = atual.Proximo;
                }

                if (atual != null)
                {
                    nova.Proximo = atual.Proximo;
                    atual.Proximo = nova;
                }
            }
        }

        public string RemoverInicio()
        {
            if (inicio == null)
            {
                throw new Exception("Lista vazia");
            }

            string nome = inicio.Elemento.Nome;
            inicio = inicio.Proximo;
            return nome;
        }

        public string RemoverFim()
        {
            if (inicio == null)
            {
                throw new Exception("Lista vazia");
            }

            if (inicio.Proximo == null)
            {
                string nome = inicio.Elemento.Nome;
                inicio = null;
                return nome;
            }

            Celula atual = inicio;
            while (atual.Proximo.Proximo != null)
            {
                atual = atual.Proximo;
            }

            string nomeRemovido = atual.Proximo.Elemento.Nome;
            atual.Proximo = null;
            return nomeRemovido;
        }

        public string RemoverPosicao(int posicao)
        {
            if (inicio == null)
            {
                throw new Exception("Lista vazia");
            }

            if (posicao == 0)
            {
                return RemoverInicio();
            }

            Celula atual = inicio;
            Celula anterior = null;
            for (int i = 0; i < posicao && atual != null; i++)
            {
                anterior = atual;
                atual = atual.Proximo;
            }

            if (atual == null)
            {
                throw new Exception("Posição inválida");
            }

            anterior.Proximo = atual.Proximo;
            return atual.Elemento.Nome;
        }

        public void Mostrar()
        {
            Celula atual = inicio;
            while (atual != null)
            {
                Console.WriteLine($"{atual.Elemento.Nome}: {atual.Elemento.Link}");
                atual = atual.Proximo;
            }
        }

        public string PesquisarLink(string nomeSite)
        {
            Celula atual = inicio;
            while (atual != null)
            {
                if (atual.Elemento.Nome.Equals(nomeSite, StringComparison.OrdinalIgnoreCase))
                {
                    return atual.Elemento.Link;
                }

                atual = atual.Proximo;
            }

            return "Site não encontrado";
        }

        public static void Exe()
        {
            Lista teste = new Lista();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Inserir um Site no inicio da lista");
                Console.WriteLine("2) Inserir um Site no final da lista");
                Console.WriteLine("3) Inserir um Site numa posicao especifica da lista");
                Console.WriteLine("4) Remover o primeiro Site da lista");
                Console.WriteLine("5) Remover o ultimo Site da lista");
                Console.WriteLine("6) Remover um Site de uma posicao especifica da lista");
                Console.WriteLine("7) Mostrar o nome e o link de todos os sites da lista");
                Console.WriteLine("8) Pesquisar o link de um site");
                Console.WriteLine("9) Encerrar o programa");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Informe o nome do site:");
                        string nome1 = Console.ReadLine();
                        Console.WriteLine("Informe o link do site:");
                        string link1 = Console.ReadLine();
                        teste.InserirInicio(new Site(nome1, link1));
                        break;
                    case 2:
                        Console.WriteLine("Informe o nome do site:");
                        string nome2 = Console.ReadLine();
                        Console.WriteLine("Informe o link do site:");
                        string link2 = Console.ReadLine();
                        teste.InserirFim(new Site(nome2, link2));
                        break;
                    case 3:
                        Console.WriteLine("Informe o nome do site:");
                        string nome3 = Console.ReadLine();
                        Console.WriteLine("Informe o link do site:");
                        string link3 = Console.ReadLine();
                        Console.WriteLine("Informe a posicao:");
                        int posicao3 = Convert.ToInt32(Console.ReadLine());
                        teste.InserirPosicao(new Site(nome3, link3), posicao3);
                        break;
                    case 4:
                        try
                        {
                            string removido4 = teste.RemoverInicio();
                            Console.WriteLine($"Site removido: {removido4}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 5:
                        try
                        {
                            string removido5 = teste.RemoverFim();
                            Console.WriteLine($"Site removido: {removido5}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 6:
                        Console.WriteLine("Informe a posicao:");
                        int posicao6 = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            string removido6 = teste.RemoverPosicao(posicao6);
                            Console.WriteLine($"Site removido: {removido6}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 7:
                        teste.Mostrar();
                        break;
                    case 8:
                        Console.WriteLine("Informe o nome do site:");
                        string nomePesquisa = Console.ReadLine();
                        string linkEncontrado = teste.PesquisarLink(nomePesquisa);
                        Console.WriteLine($"Link: {linkEncontrado}");
                        break;
                    case 9:
                        Console.Write("O programa sera encerrado.");
                        continuar = false;
                        break;
                    default:
                        continuar = false;
                        break;
                }
            }
        }
    }
}