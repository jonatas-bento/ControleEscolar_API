using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ControleEscolar.Domain;

namespace ControleEscolar.Repository
{
    public class ControleEscolarContext : DbContext
    {
        public ControleEscolarContext(DbContextOptions<ControleEscolarContext> options) : base(options) { }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TurmaEscola>()
                .HasKey(TE => new { TE.TurmaId, TE.EscolaId });
    }
}
}