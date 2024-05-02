using System;

namespace CSharpLista7
{
    public class CelulaDupla
    {
        public string Musica { get; set; }
        public CelulaDupla Anterior { get; set; }
        public CelulaDupla Proximo { get; set; }

        public CelulaDupla(string musica)
        {
            Musica = musica;
            Anterior = null;
            Proximo = null;
        }
    }

    public class ListaDupla
    {
        private CelulaDupla inicio;
        private CelulaDupla fim;

        public ListaDupla()
        {
            inicio = fim = null;
        }

        public void InserirInicio(string musica)
        {
            CelulaDupla nova = new CelulaDupla(musica);
            if (inicio == null)
            {
                inicio = fim = nova;
            }
            else
            {
                nova.Proximo = inicio;
                inicio.Anterior = nova;
                inicio = nova;
            }
        }

        public void InserirFim(string musica)
        {
            CelulaDupla nova = new CelulaDupla(musica);
            if (inicio == null)
            {
                inicio = fim = nova;
            }
            else
            {
                fim.Proximo = nova;
                nova.Anterior = fim;
                fim = nova;
            }
        }

        public void InserirPosicao(string musica, int posicao)
        {
            if (posicao == 0)
            {
                InserirInicio(musica);
                return;
            }

            CelulaDupla atual = inicio;
            int i = 0;
            while (i < posicao - 1 && atual != null)
            {
                atual = atual.Proximo;
                i++;
            }

            if (atual == fim)
            {
                InserirFim(musica);
            }
            else if (atual != null)
            {
                CelulaDupla nova = new CelulaDupla(musica);
                nova.Proximo = atual.Proximo;
                atual.Proximo.Anterior = nova;
                nova.Anterior = atual;
                atual.Proximo = nova;
            }
        }

        public string RemoverInicio()
        {
            if (inicio == null) throw new Exception("Lista vazia");
            string musica = inicio.Musica;
            inicio = inicio.Proximo;
            if (inicio != null)
            {
                inicio.Anterior = null;
            }
            else
            {
                fim = null;
            }

            return musica;
        }

        public string RemoverFim()
        {
            if (fim == null) throw new Exception("Lista vazia");
            string musica = fim.Musica;
            fim = fim.Anterior;
            if (fim != null)
            {
                fim.Proximo = null;
            }
            else
            {
                inicio = null;
            }

            return musica;
        }

        public string RemoverPosicao(int posicao)
        {
            if (inicio == null) throw new Exception("Lista vazia");
            if (posicao == 0) return RemoverInicio();

            CelulaDupla atual = inicio;
            int i = 0;
            while (i < posicao && atual != null)
            {
                atual = atual.Proximo;
                i++;
            }

            if (atual == null) throw new Exception("Posição inválida");

            if (atual == fim) return RemoverFim();

            atual.Anterior.Proximo = atual.Proximo;
            atual.Proximo.Anterior = atual.Anterior;
            return atual.Musica;
        }

        public bool Remover(string musica)
        {
            CelulaDupla atual = inicio;
            while (atual != null)
            {
                if (atual.Musica.Equals(musica))
                {
                    if (atual == inicio)
                    {
                        RemoverInicio();
                    }
                    else if (atual == fim)
                    {
                        RemoverFim();
                    }
                    else
                    {
                        atual.Anterior.Proximo = atual.Proximo;
                        atual.Proximo.Anterior = atual.Anterior;
                    }

                    return true;
                }

                atual = atual.Proximo;
            }

            return false;
        }

        public void Mostrar()
        {
            CelulaDupla atual = inicio;
            while (atual != null)
            {
                Console.WriteLine(atual.Musica);
                atual = atual.Proximo;
            }
        }

        public void MostrarInverso()
        {
            CelulaDupla atual = fim;
            while (atual != null)
            {
                Console.WriteLine(atual.Musica);
                atual = atual.Anterior;
            }
        }

        public bool Pesquisar(string musica)
        {
            CelulaDupla atual = inicio;
            while (atual != null)
            {
                if (atual.Musica.Equals(musica))
                {
                    return true;
                }

                atual = atual.Proximo;
            }

            return false;
        }

        public string PesquisarAnterior(string musica)
        {
            CelulaDupla atual = inicio;
            while (atual != null && atual.Proximo != null)
            {
                if (atual.Proximo.Musica.Equals(musica))
                {
                    return atual.Musica;
                }

                atual = atual.Proximo;
            }

            return null;
        }

        public string PesquisarPosterior(string musica)
        {
            CelulaDupla atual = inicio;
            while (atual != null && atual.Proximo != null)
            {
                if (atual.Musica.Equals(musica))
                {
                    return atual.Proximo.Musica;
                }

                atual = atual.Proximo;
            }

            return null;
        }
    }


    public class GerenciadorMusica
    {
        public static void Main()
        {
            ListaDupla lista = new ListaDupla();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1)  Inserir uma musica no final da lista");
                Console.WriteLine("2)  Inserir uma musica no inicio da lista");
                Console.WriteLine("3)  Inserir uma musica numa posicao especifica da lista");
                Console.WriteLine("4)  Remover a musica do inicio da lista");
                Console.WriteLine("5)  Remover a musica do final da lista");
                Console.WriteLine("6)  Remover uma musica de uma posicao especifica da lista");
                Console.WriteLine("7)  Remover uma musica especifica");
                Console.WriteLine("8)  Listar todas as musicas da lista");
                Console.WriteLine("9)  Listar todas as musicas da lista na ordem inversa");
                Console.WriteLine("10) Pesquisar uma musica na lista");
                Console.WriteLine("11) Pesquisar musica anterior");
                Console.WriteLine("12) Pesquisar musica posterior");
                Console.WriteLine("13) Encerrar o programa");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe a musica");
                        string musica1 = Console.ReadLine();
                        lista.InserirFim(musica1);
                        break;
                    case 2:
                        Console.WriteLine("Informe a musica");
                        string musica2 = Console.ReadLine();
                        lista.InserirInicio(musica2);
                        break;
                    case 3:
                        Console.WriteLine("Informe a musica");
                        string musica3 = Console.ReadLine();
                        Console.WriteLine("Informe a posicao");
                        int pos3 = int.Parse(Console.ReadLine());
                        lista.InserirPosicao(musica3, pos3);
                        break;
                    case 4:
                        Console.WriteLine("Musica removida: " + lista.RemoverInicio());
                        break;
                    case 5:
                        Console.WriteLine("Musica removida: " + lista.RemoverFim());
                        break;
                    case 6:
                        Console.WriteLine("Informe a posicao");
                        int pos6 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Musica removida: " + lista.RemoverPosicao(pos6));
                        break;
                    case 7:
                        Console.WriteLine("Informe a musica");
                        string musica7 = Console.ReadLine();
                        if (lista.Remover(musica7))
                        {
                            Console.WriteLine("Musica removida");
                        }
                        else
                        {
                            Console.WriteLine("Musica nao encontrada");
                        }

                        break;
                    case 8:
                        Console.WriteLine("Lista:");
                        lista.Mostrar();
                        break;
                    case 9:
                        Console.WriteLine("Lista - ordem inversa:");
                        lista.MostrarInverso();
                        break;
                    case 10:
                        Console.WriteLine("Informe a musica");
                        string musica10 = Console.ReadLine();
                        if (lista.Pesquisar(musica10))
                        {
                            Console.WriteLine("A musica esta na lista");
                        }
                        else
                        {
                            Console.WriteLine("A musica nao consta na lista");
                        }

                        break;
                    case 11:
                        Console.WriteLine("Informe a musica");
                        string musica11 = Console.ReadLine();
                        string anterior = lista.PesquisarAnterior(musica11);
                        if (anterior != null)
                        {
                            Console.WriteLine("Musica anterior: " + anterior);
                        }
                        else
                        {
                            Console.WriteLine("Nao ha musica anterior");
                        }

                        break;
                    case 12:
                        Console.WriteLine("Informe a musica");
                        string musica12 = Console.ReadLine();
                        string posterior = lista.PesquisarPosterior(musica12);
                        if (posterior != null)
                        {
                            Console.WriteLine("Musica anterior: " + posterior);
                        }
                        else
                        {
                            Console.WriteLine("Nao ha musica posterior");
                        }

                        break;
                    case 13:
                        continuar = false;
                        Console.Write("O programa sera encerrado.");
                        break;
                    default:
                        Console.WriteLine("Opcao invalida.");
                        break;
                }
            }
        }
    }
}