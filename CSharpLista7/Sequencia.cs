// using System;
//
// public class Node
// {
//     private char item;
//     private Node next;
//
//     public Node(char item)
//     {
//         this.item = item;
//         this.next = null;
//     }
//
//     public Node()
//     {
//         this.item = ' ';
//         this.next = null;
//     }
//
//     public Node Next
//     {
//         get { return next; }
//         set { next = value; }
//     }
//
//     public char Item
//     {
//         get { return item; }
//         set { item = value; }
//     }
// }
//
// class Pilha
// {
//     private Node top;
//
//     public Pilha()
//     {
//         top = null;
//     }
//
//     public bool Vazio()
//     {
//         return top == null;
//     }
//
//     public void Empilhar(char x)
//     {
//         Node tmp = new Node(x);
//         tmp.Next = top;
//         top = tmp;
//         tmp = null;
//     }
//
//     public char Desempilhar()
//     {
//         if (Vazio())
//         {
//             return ' ';
//         }
//
//         char item = top.Item;
//         top = top.Next;
//         return item;
//     }
//
//     public bool Verificar(char x)
//     {
//         char tmp = Desempilhar();
//         if (x == ')' && tmp == '(')
//         {
//             return true;
//         }
//         else if ((x == ']' && tmp == '['))
//         {
//             return true;
//         }
//         else if ((x == '[' || x == '('))
//         {
//             return true;
//         }
//         else
//         {
//             return false;
//         }
//     }
// }
//
// class Sequencia
// {
//     public static void Exe()
//     {
//         Console.WriteLine("Informe a sequencia:");
//         string seq = Console.ReadLine().Replace(" ", "");
//         Pilha teste = new Pilha();
//         bool ok = true;
//         for (int i = 0; i < seq.Length; i++)
//         {
//             if (seq[0] == ']' || seq[0] == ')')
//             {
//                 ok = false;
//                 break;
//             }
//             else
//             {
//                 if (i == 0)
//                 {
//                     teste.Empilhar(seq[i]);
//                     continue;
//                 }
//                 else
//                 {
//                     if (seq[i] == '[' || seq[i] == '(')
//                     {
//                         teste.Empilhar(seq[i]);
//                     }
//                     else
//                     {
//                         ok = teste.Verificar(seq[i]);
//                         if (!ok)
//                         {
//                             break;
//                         }
//                     }
//                 }
//             }
//         }
//
//         if (ok && teste.Vazio())
//         {
//             Console.Write("Sequencia bem formada!");
//         }
//         else
//         {
//             Console.Write("Sequencia mal formada!");
//         }
//     }
// }