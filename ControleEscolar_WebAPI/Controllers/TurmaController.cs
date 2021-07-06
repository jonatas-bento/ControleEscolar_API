using System;
using System.Threading.Tasks;
using ControleEscolar.Domain;
using ControleEscolar.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace ControleEscolar_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly IControleEscolarRepository _repo;

        public TurmaController(IControleEscolarRepository repo)
        {
            _repo = repo;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllTurmasAsync(true);

                return Ok(results);
            }

            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }

        }
        [HttpGet("{TurmaId}")]
        public async Task<IActionResult> Get(int TurmaId)
        {
            try
            {
                var results = await _repo.GetTurmaAsyncById(TurmaId, true);

                return Ok(results);
            }

            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }

        }



        [HttpPost]
        public async Task<IActionResult> Post(Turma model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/turma/{model.Id}", model);
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }

            return BadRequest();

        }

        [HttpPut]
        public async Task<IActionResult> Put(int TurmaId, Turma model)
        {
            try
            {
                var turma = await _repo.GetEscolaAsyncById(TurmaId, false);
                if (turma == null) return NotFound();

                _repo.Update(model);


                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/turma/{model.Id}", model);
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }

            return BadRequest();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int TurmaId)
        {
            try
            {
                var turma = await _repo.GetTurmaAsyncById(TurmaId, false);
                if (turma == null) return NotFound();

                _repo.Delete(turma);


                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }

            return BadRequest();

        }

}
}