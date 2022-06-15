using System.Threading.Tasks;
using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Repository.Interfaces
{
    public interface IPalestrantesPersistence
    {
        Task<Palestrante[]> GetAllPalestrantesByNameAsync(string nome, bool includeEvento);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEvento);
        Task<Palestrante> GetByIdPalestranteAsync(int PalestranteId, bool includeEvento);

    }
}