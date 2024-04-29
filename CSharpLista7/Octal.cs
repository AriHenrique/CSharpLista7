// using System;
//
// namespace CSharpLista7
// {
//     // public class Node
//     // {
//     //     private int numb;
//     //     private Node next;
//     //
//     //     public Node(int numb)
//     //     {
//     //         this.numb = numb;
//     //         this.next = null;
//     //     }
//     //
//     //     public Node()
//     //     {
//     //         this.numb = 0;
//     //         this.next = null;
//     //     }
//     //
//     //     public Node Next
//     //     {
//     //         get { return next; }
//     //         set { next = value; }
//     //     }
//     //
//     //     public int Item
//     //     {
//     //         get { return numb; }
//     //         set { numb = value; }
//     //     }
//     // }
//
//     public class Octal
//     {
//         private Node top;
//
//         public Octal()
//         {
//             top = null;
//         }
//
//         public void Empilhar(int x)
//         {
//             Node tmp = new Node(x);
//             tmp.Next = top;
//             top = tmp;
//             tmp = null;
//         }
//
//         public string Mostrar(Octal obj)
//         {
//             string ret = "";
//             for (Node i = obj.top; i != null; i = i.Next)
//             {
//                 ret += i.Item.ToString();
//             }
//
//             return ret;
//         }
//
//         public static void Exe()
//         {
//             Console.WriteLine("Informe um numero:");
//             int num = int.Parse(Console.ReadLine().Replace(" ", ""));
//             Octal teste = new Octal();
//             do
//             {
//                 teste.Empilhar(num % 8);
//                 num /= 8;
//             } while (num > 0);
//
//             Console.Write($"Octal: {teste.Mostrar(teste)}");
//         }
//     }
// }