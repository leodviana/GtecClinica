using GtecClinica.Abstrato.Servico.Interfaces;
using GtecClinica.Dados.Contexto;
using GtecClinica.Dados.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GtecClinica.Servico
{
    public class TesteServico : ITesteServico
    {
        private readonly GtecContexto _contexto;

        public TesteServico(GtecContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task ExcluirPorId(int id)
        {
            var model = await _contexto.Teste.FindAsync(id);

            if (model != null)
            {
                _contexto.Remove(model);
                await _contexto.SaveChangesAsync();
            }
        }

        public async Task<List<Teste>> ListarTodos()
        {
            return await _contexto.Teste.ToListAsync();
        }

        public async Task<Teste> ObterPorId(int id)
        {
            return await _contexto.Teste.FindAsync(id);
        }

        public async Task<Teste> SalvarOuEditar(Teste model)
        {
            if (model.Id == 0)
                await _contexto.Teste.AddAsync(model);
            else
                _contexto.Teste.Update(model);

            await _contexto.SaveChangesAsync();

            return model;
        }
    }
}
