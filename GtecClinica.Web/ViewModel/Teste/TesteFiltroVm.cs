using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GtecClinica.Web.ViewModel.Teste
{
    public class TesteFiltroVm : TesteLabelVm
    {
        public TesteFiltroVm()
        {
            Lista = new List<TesteListaVm>();
        }

        [MaxLength(50)]

        public string Nome { get; set; }

        public List<TesteListaVm> Lista { get; set; }
    }
}
