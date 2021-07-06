using System.Threading.Tasks;
using ControleEscolar.Domain;

namespace ControleEscolar.Repository
{
    public interface IControleEscolarRepository
    {
         //Geral
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveChangesAsync();


         //Escolas
         Task<Escola[]> GetAllEscolasAsync(bool includeTurmas);
         Task<Escola[]> GetEscolaAsyncByName(string name, bool includeTurmas);
         Task<Escola> GetEscolaAsyncById(int EscolaId, bool includeTurmas);

         //Turmas
         Task<Turma[]> GetAllTurmasAsync(bool includeAlunos);
         Task<Turma> GetTurmaAsyncById(int TurmaId, bool includeAlunos);

         //Alunos
         Task<Aluno[]> GetAllAlunosAsync(bool includeTurmas);
         Task<Aluno> GetAlunoAsyncById(int AlunoId, bool includeTurmas);
    }
}