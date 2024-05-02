// using System;
//
// namespace CSharpLista7
// {
//     public class Node
//     {
//         private string aluno;
//         private Node next;
//
//         public Node(string aluno)
//         {
//             this.aluno = aluno;
//             this.next = null;
//         }
//
//         public Node()
//         {
//             this.aluno = "";
//             this.next = null;
//         }
//
//         public Node Next
//         {
//             get { return next; }
//             set { next = value; }
//         }
//
//         public string Aluno
//         {
//             get { return aluno; }
//             set { aluno = value; }
//         }
//     }
//
//     public class Aluno
//     {
//         
//         private Node init, end;
//         
//         public Aluno()
//         {
//             init = new Node();
//             end = init;
//         }
//
//         public void Inserir()
//         {
//             Console.WriteLine("Informe o nome do aluno:");
//             string aluno = Console.ReadLine();
//             end.Next = new Node(aluno);
//             end = end.Next;
//         }
//
//         public string Remover()
//         {
//             if (init.Next == null)
//             {
//                 throw new Exception("Lista de alunos vazia");
//             }
//             Node tmp = init.Next;
//             if (tmp == end)
//             {
//                 end = init;
//             }
//             init.Next = tmp.Next;
//             string ret = tmp.Aluno;
//             return ret;
//         }
//
//         public void Mostrar()
//         {
//             // Console.WriteLine(init.Aluno);
//             for (Node i = init; i.Next != null; i = i.Next)
//             {
//                 Console.WriteLine(i.Aluno);
//             }
//             Console.WriteLine(end.Aluno);
//         }
//
//         public bool Pesquisar()
//         {
//             Console.WriteLine("Informe o nome do aluno:");
//             string tmp = Console.ReadLine();
//             bool encontrado = tmp == end.Aluno;
//             for (Node i = init; !encontrado && i.Next != null; i = i.Next)
//             {
//                 if (i.Aluno == tmp)
//                 {
//                     return true;
//                 }
//             }
//             return encontrado;
//         }
//         
//         public static void Exe()
//          {
//              Aluno ic = new Aluno();
//              Aluno mestrado = new Aluno();
//              bool continuar = true;
//
//              while (continuar)
//              {
//                  Console.WriteLine("Menu:");
//                  Console.WriteLine("1. Inserir um aluno na fila de espera de bolsas de IC");
//                  Console.WriteLine("2. Inserir um aluno na fila de espera de bolsas de Mestrado");
//                  Console.WriteLine("3. Remover um aluno da fila de bolsas de IC");
//                  Console.WriteLine("4. Remover um aluno da fila de bolsas de Mestrado");
//                  Console.WriteLine("5. Mostrar fila de espera de bolsas de IC");
//                  Console.WriteLine("6. Mostrar fila de espera de bolsas de Mestrado");
//                  Console.WriteLine("7. Pesquisar aluno na fila de espera de bolsas de IC");
//                  Console.WriteLine("8. Pesquisar aluno na fila de espera de bolsas de Mestrado");
//                  Console.WriteLine("9. Sair");
//                  int opcao = Convert.ToInt32(Console.ReadLine());
//
//                  switch (opcao)
//                  {
//                      case 1:
//                          ic.Inserir();
//                          break;
//                      case 2:
//                          mestrado.Inserir();
//                          break;
//                      case 3:
//                          Console.WriteLine($"Aluno removido: {ic.Remover()}");
//                          break;
//                      case 4:
//                          Console.WriteLine($"Aluno removido: {mestrado.Remover()}");
//                          break;
//                      case 5:
//                          Console.Write("Fila de Espera IC:");
//                          ic.Mostrar();
//                          break;
//                      case 6:
//                          Console.Write("Fila de Espera Mestrado:");
//                          mestrado.Mostrar();
//                          break;
//                      case 7:
//                          bool okIc = ic.Pesquisar();
//                          if (okIc)
//                          {
//                              Console.WriteLine("Aluno ja consta na fila de IC");
//                          }else
//                          {
//                              Console.WriteLine("Aluno nao consta na fila de IC");
//                          }
//                          break;
//                      case 8:
//                          bool okM = mestrado.Pesquisar();
//                          if (okM)
//                          {
//                              Console.WriteLine("Aluno ja consta na fila de Mestrado");
//                          }
//                          else
//                          {
//                              Console.WriteLine("Aluno nao consta na fila de Mestrado");
//                          }
//                          break;
//                      case 9:
//                          Console.Write("O programa sera encerrado");
//                          continuar = false;
//                          break;
//                      default:
//                          Console.WriteLine("Opção inválida.");
//                          break;
//                  }
//              }
//          }
//      
//     }
// }