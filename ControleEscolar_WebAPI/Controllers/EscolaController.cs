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
    public class EscolaController : ControllerBase
    {
        private readonly IControleEscolarRepository _repo;

        public EscolaController(IControleEscolarRepository repo)
        {
            _repo = repo;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllEscolasAsync(true);

                return Ok(results);
            }

            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }

        }
        [HttpGet("{EscolaId}")]
        public async Task<IActionResult> Get(int EscolaId)
        {
            try
            {
                var results = await _repo.GetEscolaAsyncById(EscolaId, true);

                return Ok(results);
            }

            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }

        }
         
     [HttpGet("getByNome/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var results = await _repo.GetEscolaAsyncByName(name, true);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }


        }

        [HttpPost]
        public async Task<IActionResult> Post(Escola model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/escola/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }

            return BadRequest();

        }

        [HttpPut]
        public async Task<IActionResult> Put(int EscolaId, Escola model)
        {
            try
            {
                var escola = await _repo.GetEscolaAsyncById(EscolaId, false);
                if(escola == null) return NotFound();
                
                _repo.Update(model);


                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/escola/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }

            return BadRequest();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int EscolaId)
        {
            try
            {
                var escola = await _repo.GetEscolaAsyncById(EscolaId, false);
                if(escola == null) return NotFound();
                
                _repo.Delete(escola);


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