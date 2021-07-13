using GtecClinica.Dados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtecClinica.Abstrato.Servico.Interfaces
{
    public interface ITesteServico
    {
        Task<Teste> ObterPorId(int id);
        Task<List<Teste>> ListarTodos();
        Task<Teste> SalvarOuEditar(Teste model);
        Task ExcluirPorId(int id);
    }
}
