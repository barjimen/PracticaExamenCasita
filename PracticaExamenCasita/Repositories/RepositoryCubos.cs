using Microsoft.EntityFrameworkCore;
using PracticaExamenCasita.Data;
using PracticaExamenCasita.Models;

namespace PracticaExamenCasita.Repositories
{
    public class RepositoryCubos
    {
        private CubosContext context;
        public RepositoryCubos(CubosContext context)
        {
            this.context = context;
        }
        
        public async Task<List<Cubos>> GetCubosAsync()
        {
            return await this.context.Cubos.ToListAsync();
        }
        public async Task<Cubos> FindCuboAsync(int id)
        {
            return await this.context.Cubos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Cubos>> GetCubosModelo(string modelo)
        {
            return await this.context.Cubos.Where(x => x.Modelo == modelo).ToListAsync();
        }
        public async Task<Cubos> AddCuboAsync(Cubos cubo)
        {
            this.context.Cubos.Add(cubo);
            await this.context.SaveChangesAsync();
            return cubo;
        }
        public async Task<Cubos> UpdateCuboAsync(Cubos cubo)
        {
            this.context.Cubos.Update(cubo);
            await this.context.SaveChangesAsync();
            return cubo;
        }
        public async Task<Cubos> DeleteCuboAsync(int id)
        {
            var cubo = await this.FindCuboAsync(id);
            if (cubo != null)
            {
                this.context.Cubos.Remove(cubo);
                await this.context.SaveChangesAsync();
            }
            return cubo;
        }
    }
}
