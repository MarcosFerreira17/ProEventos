using System;
using System.Threading.Tasks;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Repository.Interfaces;

namespace ProEventos.Application.Repository.Interfaces
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersistence _geralPersist;
        private readonly IEventosPersistence _eventoPersist;
        public EventoService(IGeralPersistence geralPersist, IEventosPersistence eventoPersist)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;
        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetByIdEventosAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEventos(int id, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetByIdEventosAsync(id, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetByIdEventosAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEventos(int id)
        {
            try
            {
                var evento = await _eventoPersist.GetByIdEventosAsync(id, false);

                if (evento == null) throw new Exception("Evento não encontrado.");

                _geralPersist.Delete<Evento>(evento);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrante);

                if (eventos == null) throw new Exception("Não há eventos para serem exibidos.");

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrante);

                if (eventos == null) throw new Exception("Este evento não existe, verifique o tema e tente novamente.");

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetByIdEventosAsync(int EventoId, bool includePalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetByIdEventosAsync(EventoId, includePalestrante);

                if (eventos == null) throw new Exception("Este evento não existe, verifique o id e tente novamente.");

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}