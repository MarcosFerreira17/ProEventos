using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Data;
using ProEventos.Persistence.Repository.Interfaces;

namespace ProEventos.Persistence.Repository
{
    public class PalestrantesPersistence : IPalestrantesPersistence
    {

        private ProEventosContext _context;
        public PalestrantesPersistence(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(e => e.RedesSociais);

            if (includeEvento)
            {
                query = query.Include(e => e.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetByIdPalestranteAsync(int PalestranteId, bool includeEvento)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(e => e.RedesSociais);

            if (includeEvento)
            {
                query = query.Include(e => e.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                        .Where(e => e.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNameAsync(string nome, bool includeEvento)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(r => r.RedesSociais);

            if (includeEvento)
            {
                query = query.Include(p => p.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}