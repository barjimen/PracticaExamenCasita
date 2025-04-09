using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaExamenCasita.Models;
using PracticaExamenCasita.Repositories;

namespace PracticaExamenCasita.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubosController : ControllerBase
    {
        private RepositoryCubos repo;
        public CubosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Cubos>>> GetCubos()
        {
            return await this.repo.GetCubosAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCubo(int id)
        {
            var cubo = await this.repo.FindCuboAsync(id);
            return Ok(cubo);
        }
        [HttpGet("modelo/{modelo}")]
        public async Task<ActionResult> GetCubosModelo(string modelo)
        {
            var cubos = await this.repo.GetCubosModelo(modelo);
            return Ok(cubos);
        }
        [HttpPost]
        public async Task<ActionResult> AddCubo([FromBody] Models.Cubos cubo)
        {
            var nuevoCubo = await this.repo.AddCuboAsync(cubo);
            return Ok(nuevoCubo);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCubo(int id)
        {
            var cubo = await this.repo.DeleteCuboAsync(id);
            if (cubo == null)
            {
                return NotFound();
            }
            return Ok(cubo);
        }
    }
}
