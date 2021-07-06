using System.Linq;
using System.Threading.Tasks;
using ControleEscolar.Domain;
using Microsoft.EntityFrameworkCore;

namespace ControleEscolar.Repository
{
    public class ControleEscolarRepository : IControleEscolarRepository
    {
        public ControleEscolarContext _context;

        public ControleEscolarRepository(ControleEscolarContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Escola[]> GetAllEscolasAsync(bool includeTurmas = false)
        {
            IQueryable<Escola> query = _context.Escolas;

            if (includeTurmas)
            {
                query = query.Include(t => t.Turmas);
            }

            return await query.ToArrayAsync();
        }
        public async Task<Escola> GetEscolaAsyncById(int EscolaId, bool includeTurmas)
        {
            IQueryable<Escola> query = _context.Escolas;

            if (includeTurmas)
            {
                query = query.Include(t => t.Turmas);
            }

            query = query
            .OrderByDescending(c => c.Nome)
            .Where(e => e.Id == EscolaId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Escola[]> GetEscolaAsyncByName(string name, bool includeTurmas)
        {
            IQueryable<Escola> query = _context.Escolas;

            if (includeTurmas)
            {
                query.Include(t => t.Turmas);
            }

            query = query
            .OrderBy(n => n.Nome)
            .Where(n => n.Nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Turma[]> GetAllTurmasAsync(bool includeAlunos)
        {
            IQueryable<Turma> query = _context.Turmas;

            if (includeAlunos)
            {
                query.Include(a => a.Alunos);
            }

            return await query.ToArrayAsync();

        }
        public async Task<Turma> GetTurmaAsyncById(int TurmaId, bool includeAlunos)
        {
            IQueryable<Turma> query = _context.Turmas;

            if (includeAlunos)
            {
                query.Include(a => a.Alunos);
            }

            query = query
            .OrderByDescending(t => t.Nome)
            .Where(t => t.Id == TurmaId);

            return await query.FirstOrDefaultAsync();
        }


        public async Task<Aluno[]> GetAllAlunosAsync(bool includeTurmas)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeTurmas)
            {
                query.Include(a => a.TurmaId);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoAsyncById(int AlunoId, bool includeTurmas)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeTurmas)
            {
                query.Include(a => a.TurmaId);
            }

            query = query
            .OrderByDescending(t => t.Nome)
            .Where(t => t.Id == AlunoId);

            return await query.FirstOrDefaultAsync();
        }

    }


}

