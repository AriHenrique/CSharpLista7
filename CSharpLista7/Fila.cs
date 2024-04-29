using System;

namespace CSharpLista7
{
    public class Node
    {
        private string arq;
        private int qtd;
        private Node next;

        public Node(string arq, int qtd)
        {
            this.arq = arq;
            this.qtd = qtd;
            this.next = null;
        }

        public Node()
        {
            this.arq = "";
            this.qtd = 0;
            this.next = null;
        }

        public Node Next
        {
            get { return next; }
            set { next = value; }
        }

        public string Arq
        {
            get { return arq; }
            set { arq = value; }
        }
        
        public int Qtd
        {
            get { return qtd; }
            set { qtd = value; }
        }
    }

    public class Fila
    {
        private Node init, end;
        
        public Fila()
        {
            init = new Node();
            end = init;
        }
        
        public void Inserir()
        {
            Console.WriteLine("Digite o nome do arquivo:");
            string x = Console.ReadLine();
            Console.WriteLine("Digite a quantidade de paginas:");
            int y = Convert.ToInt32(Console.ReadLine());
            end.Next = new Node(x, y);
            end = end.Next;
        }
        
        public (string, int) Imprimir()
        {
            if (init == end)
            {
                throw new Exception("Fila de impressao esta vazia");
            }

            Node tmp = init;
            init = init.Next;
            string _aqr = init.Arq;
            int _qtd = init.Qtd;
            tmp.Next = null;
            tmp = null;
            return (_aqr, _qtd);
        }
        
        public static void Exe()
        {
            
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("1. Inserir arquivo na fila de impressao");
                Console.WriteLine("2. Executar impressao");
                Console.WriteLine("3. Exibir fila de impressao");
                Console.WriteLine("4. Sair");
                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        
                        break;
                    case 2:
                        

                        break;
                    case 3:
                       
                        break;
                    case 4:
                        
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}