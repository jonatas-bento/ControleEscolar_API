using System.Collections.Generic;

namespace ControleEscolar.Domain
{
    public class Turma
    {
        public Turma() { }
        public Turma(int id, string nome, string serie, int escolaId)
        {
            this.Id = id;
            this.Nome = nome;
            this.Serie = serie;
            this.EscolaId = escolaId;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Serie { get; set; }
        public int EscolaId { get; set; }
        public List<Aluno> Alunos { get; }
    }
}