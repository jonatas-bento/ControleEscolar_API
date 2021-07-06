namespace ControleEscolar.Domain
{
    public class TurmaEscola
    {
        public TurmaEscola() { }

        public TurmaEscola(int turmaId, string turma, int escolaId)
        {
            this.TurmaId = turmaId;
            this.EscolaId = escolaId;
        }
        public int TurmaId { get; set; }
        public Turma Turma { get; }
        public int EscolaId { get; set; }
        public Escola Escolas { get; }
    }
}