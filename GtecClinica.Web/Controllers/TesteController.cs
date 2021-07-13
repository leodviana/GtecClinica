using FastMapper.NetCore;
using GtecClinica.Abstrato.Servico.Interfaces;
using GtecClinica.Web.ViewModel.Teste;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GtecClinica.Web.Controllers
{
    public class TesteController : Controller
    {
        private readonly ITesteServico _testeServico;
        public TesteController(ITesteServico testeServico)
        {
            _testeServico = testeServico;
        }

        public async Task<IActionResult> Index(TesteFiltroVm model)
        {

            model.Lista = TypeAdapter.Adapt<List<TesteListaVm>>(await _testeServico.ListarTodos());

            return View("Index", model);
        }

    }
}
