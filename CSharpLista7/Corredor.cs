using System;

namespace CSharpLista7
{
    public class DobleNode
    {
        private int tempo;
        private DobleNode next;
        private DobleNode previous;

        public DobleNode(int tempo)
        {
            this.tempo = tempo;
            this.next = null;
            this.previous = null;
        }

        public DobleNode()
        {
            this.tempo = 0;
            this.next = null;
            this.previous = null;
        }

        public DobleNode Next
        {
            get { return next; }
            set { next = value; }
        }

        public DobleNode Previeous
        {
            get { return previous; }
            set { previous = value; }
        }

        public int Tempo
        {
            get { return tempo; }
            set { tempo = value; }
        }
    }

    public class Corredor
    {
        private DobleNode init, end;

        public Corredor()
        {
            init = new DobleNode();
            end = init;
        }


        public void InserirInit(int x)
        {
            DobleNode tmp = new DobleNode(x);
            tmp.Previeous = init;
            tmp.Next = init.Next;
            //
            if (init.Next != null)
            {
                init.Next.Previeous = tmp;
            }
            else
            {
                end = tmp;
            }

            init.Next = tmp;
        }


        public void InserirEnd(int x)
        {
            DobleNode tmp = new DobleNode(x);
            tmp.Previeous = end;
            end.Next = tmp;
            end = tmp;
        }


        public void Inserir(int pos, int x)
        {
            if (pos < 0)
            {
                Console.WriteLine("Posição inválida");
                return;
            }

            DobleNode tmp = new DobleNode(x);
            DobleNode current = init;
            int currentIndex = 0;

            while (current.Next != null && currentIndex < pos)
            {
                current = current.Next;
                currentIndex++;
            }

            if (currentIndex == pos)
            {
                tmp.Next = current.Next;
                if (current.Next != null)
                {
                    current.Next.Previeous = tmp;
                }

                tmp.Previeous = current;
                current.Next = tmp;

                if (tmp.Next == null)
                {
                    end = tmp;
                }
            }
            else
            {
                Console.WriteLine("Posição maior que o tamanho da lista");
            }
        }

        public void Mostrar()
        {
            Console.Write("[");
            DobleNode current = init.Next;
            while (current != null)
            {
                Console.Write($"{current.Tempo} ");
                current = current.Next;
            }

            Console.WriteLine("]");
        }

        public int RemoverInit()
        {
            if (init == end)
            {
                throw new Exception("Lista vazia");
            }

            DobleNode rem = init.Next;
            int tmp = rem.Tempo;
            init.Next = rem.Next;
            if (rem.Next != null)
            {
                rem.Next.Previeous = init;
            }

            rem = null;
            return tmp;
        }


        public int RemoverEnd()
        {
            if (init == end)
            {
                throw new Exception("Lista vazia");
            }

            DobleNode rem = end;
            int tmp = rem.Tempo;
            end = end.Previeous;
            if (end != null)
            {
                end.Next = null;
            }
            else
            {
                init.Next = null;
            }

            rem = null;
            return tmp;
        }


        public int Remover(int pos)
        {
            if (init.Next == null)
            {
                throw new Exception("Lista vazia");
            }

            if (pos == 0)
            {
                return RemoverInit();
            }

            DobleNode current = init.Next;
            int count = 0;

            while (current != null && count < pos)
            {
                if (count + 1 == pos)
                {
                    if (current.Next == end)
                    {
                        return RemoverEnd();
                    }

                    int temp = current.Next.Tempo;
                    current.Next = current.Next.Next;
                    if (current.Next != null)
                    {
                        current.Next.Previeous = current;
                    }

                    return temp;
                }

                current = current.Next;
                count++;
            }

            throw new Exception("Posição não encontrada");
        }


        public void RemoverItem(int x)
        {
            if (init.Next == null)
            {
                Console.WriteLine("Lista vazia");
                return;
            }

            int count = 0;
            for (DobleNode i = init.Next; i != null; i = i.Next, count++)
            {
                if (i.Tempo == x)
                {
                    Remover(count);
                    return;
                }
            }

            Console.WriteLine("Item não encontrado");
        }

        public int CountItens(int x)
        {
            int count = 0;
            for (DobleNode i = init.Next; i != null; i = i.Next)
            {
                if (i.Tempo == x)
                {
                    count++;
                }
            }

            return count;
        }

        public static void Exe()
        {
            Corredor teste = new Corredor();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Inserir um tempo no inicio da lista.");
                Console.WriteLine("2) Inserir um tempo no final da lista.");
                Console.WriteLine("3) Inserir um tempo numa posicao especifica da lista.");
                Console.WriteLine("4) Remover o primeiro tempo da lista.");
                Console.WriteLine("5) Remover o ultimo tempo da lista.");
                Console.WriteLine("6) Remover um tempo de uma posicao especifica na lista.");
                Console.WriteLine("7) Remover um tempo especifico da lista.");
                Console.WriteLine("8) Pesquisar quantas vezes um determinado tempo consta na lista.");
                Console.WriteLine("9) Mostrar todos os tempos da lista.");
                Console.WriteLine("10) Encerrar o programa.");
                int input = Convert.ToInt32(Console.ReadLine());
                
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Informe o tempo:");
                        int tempoInit = Convert.ToInt32(Console.ReadLine());
                        teste.InserirInit(tempoInit);
                        break;
                    case 2:
                        Console.WriteLine("Informe o tempo:");
                        int tempoEnd = Convert.ToInt32(Console.ReadLine());
                        teste.InserirEnd(tempoEnd);
                        break;
                    case 3:
                        Console.WriteLine("Informe o tempo:");
                        int tempoPos = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Informe a posicao:");
                        int pos = Convert.ToInt32(Console.ReadLine());
                        teste.Inserir(pos, tempoPos);
                        break;
                    case 4:
                        Console.WriteLine($"Tempo removido: {teste.RemoverInit()}.");
                        break;
                    case 5:
                        Console.WriteLine($"Tempo removido: {teste.RemoverEnd()}.");
                        break;
                    case 6:
                        Console.WriteLine("Informe a posicao:");
                        int posRemove = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Tempo removido: {teste.Remover(posRemove)}.");
                        break;
                    case 7:
                        Console.WriteLine("Informe o tempo a remover:");
                        int tempoRemove = Convert.ToInt32(Console.ReadLine());
                        teste.RemoverItem(tempoRemove);
                        break;
                    case 8:
                        Console.WriteLine("Informe o tempo:");
                        int tempoCount = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Quantidade: {teste.CountItens(tempoCount)}");
                        break;
                    case 9:
                        teste.Mostrar();
                        break;
                    default:
                        Console.Write("O programa sera encerrado.");
                        continuar = false;
                        break;
                }
                
                
            }
        }
    }
}