namespace ControleEscolar.Domain
{
    public class Aluno
    {
        public Aluno() { }
        public Aluno(int id, string nome, int turmaId)
        {
            this.Id = id;
            this.Nome = nome;
            this.TurmaId = turmaId;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TurmaId { get; set; }
    }
}