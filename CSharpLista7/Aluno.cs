namespace CSharpLista7
{
    public class Node
    {
        private string aluno;
        private Node next;

        public Node(string aluno)
        {
            this.aluno = aluno;
            this.next = null;
        }

        public Node()
        {
            this.aluno = "";
            this.next = null;
        }

        public Node Next
        {
            get { return next; }
            set { next = value; }
        }

        public string Arq
        {
            get { return aluno; }
            set { aluno = value; }
        }
    }

    public class Aluno
    {
        
        private Node init, end;
        public Aluno()
        {
            init = new Node();
            end = init;
        }
    }
}