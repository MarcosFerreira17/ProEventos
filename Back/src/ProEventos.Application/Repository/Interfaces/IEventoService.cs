using System.Threading.Tasks;
using ProEventos.Domain.Models;

namespace ProEventos.Application.Repository.Interfaces
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEventos(int id, Evento model);
        Task<bool> DeleteEventos(int id, Evento model);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false);
        Task<Evento> GetByIdEventosAsync(int EventoId, bool includePalestrante = false);
    }
}